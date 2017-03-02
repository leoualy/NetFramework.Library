using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Library.Network.WinSock
{
    internal class AsyCmpPkg
    {
        private const int BUFLEN = 4096;
        public AsyCmpPkg()
        {
            ByteBuffer = new byte[BUFLEN];
            BufferLen = BUFLEN;
        }
        public Socket SocketClient { get; set; }
        public byte[] ByteBuffer { get; set; }
        public int BufferLen { get; set; }
        public long ConnID { get; set; }

    }

    internal class AsyncTcpHandler : HandlerBase
    {
        public AsyncTcpHandler() : base() { }
        public AsyncTcpHandler(int port) : base(port) { }
        public AsyncTcpHandler(int port, int backlog) : base(port, backlog) { }

        ///// <summary>
        ///// 完成一个AcceptIO时的回调函数
        ///// </summary>
        //public event Action<Socket_AL_IRP> OnAcceptCallback = null;
        ///// <summary>
        ///// 完成一个接收IO时的回调函数
        ///// </summary>
        //public event Action<Socket_AL_IRP> OnRecvCallback = null;
        //public event Action<Socket_AL_IRP> OnSendCallback = null;

        
        public override void PostAccept(Socket sListen)
        {
            if (sListen == null)
            {
                throw new ObjectDisposedException("用于监听的套接字为空");
            }
            try
            {
                sListen.BeginAccept(AcceptCompleted, sListen);
                
            }
            catch (Exception eAccept)
            {
                // PostExceptionHandler(eAccept, "PostAsynImpl.PostAccept", "异步提交Accetp时错误");
            }
        }

        private object lockAccept = new object();
        /// <summary>
        /// 完成Accept操作
        /// </summary>
        /// <param name="ar"></param>
        private void AcceptCompleted(IAsyncResult ar)
        {
            Socket sListen = ar.AsyncState as Socket;
            Socket sAccept = sListen.EndAccept(ar);
            
            if (sAccept == null)
            {
                return;
            }
            try
            {
                Monitor.Enter(lockAccept);
                SocketCount += 1;
                dicSocketNode.Add(SocketCount, sAccept);
                Socket_AL_IRP irp = new Socket_AL_IRP();
                irp.ConnID = SocketCount;
                
                //if (OnAcceptCallback != null)
                //{
                //    OnAcceptCallback.BeginInvoke(irp, null, null);
                //}
            }
            catch (Exception inEx)
            {

            }
            finally
            {
                Monitor.Exit(lockAccept);
            }
            
            PostRecv(sAccept);
            // 提取下一个完成握手的Socket
            PostAccept(sListen);
        }

        public override void PostSend(Socket sClient)
        {

            // throw new NotImplementedException();
            // sClient.BeginSend()
        }

        public override void PostRecv(Socket sClient)
        {
            AsyCmpPkg pkg = new AsyCmpPkg();
            pkg.SocketClient = sClient;
            sClient.BeginReceive(pkg.ByteBuffer, 0, pkg.BufferLen, SocketFlags.None, RecvCompleted, pkg);
        }

        /// <summary>
        /// 完成接收操作
        /// </summary>
        /// <param name="ar"></param>
        private void RecvCompleted(IAsyncResult ar)
        {
            AsyCmpPkg pkg = ar.AsyncState as AsyCmpPkg;
            Socket sClient = pkg.SocketClient;
            int readLen = 0;
            try
            {
                readLen = sClient.EndReceive(ar);
                if (readLen!=0)
                {
                    Socket_AL_IRP irp = new Socket_AL_IRP();
                    irp.Buffer = pkg.ByteBuffer;
                    irp.TransferredLen = readLen;
                    RecvHandler(null);
                    PostRecv(sClient);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        protected override Socket CreateSocket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        protected override void StartFetch(Socket sServer)
        {
            sServer.Listen(iBacklog);
            PostAccept(sServer);
        }

    }
}
