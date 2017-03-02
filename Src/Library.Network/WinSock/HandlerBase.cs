using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Library.Network.WinSock
{
    internal abstract class HandlerBase : IHandler
    {
        public HandlerBase() : this(9000, 10) { }
        public HandlerBase(int port) : this(port, 10) { }
        public HandlerBase(int port,int backlog)
        {
            this.iPort = port;
            this.iBacklog = backlog;
        }

        protected int iPort=0;
        protected int iBacklog=0;
        // 当前Socket的数目（不包含监听的Socket）
        protected long SocketCount = 0;
        protected Dictionary<long, Socket> dicSocketNode = new Dictionary<long, Socket>();


        public abstract void PostAccept(Socket sListen);
        /// <summary>
        /// 投递一个Send操作
        /// </summary>
        /// <param name="sClient"></param>
        public abstract void PostSend(Socket sClient);

        /// <summary>
        /// 投递一个Recv请求
        /// </summary>
        /// <param name="sClient"></param>
        public abstract void PostRecv(Socket sClient);

        /// <summary>
        /// 创建派生类中给定协议类型的Socket
        /// </summary>
        /// <returns></returns>
        protected abstract Socket CreateSocket();

        /// <summary>
        /// 开始以不同的方式获取数据，在派生类中实现
        /// </summary>
        /// <param name="sServer">服务Socket</param>
        protected abstract void StartFetch(Socket sServer);


        public void StartHandler()
        {
            Socket sServer = CreateSocket();
            sServer.Bind(new IPEndPoint(IPAddress.Any, iPort));
            StartFetch(sServer);
        }

        ///// <summary>
        ///// 开始处理
        ///// </summary>
        //public virtual void StartHandler()
        //{
        //    Socket sServer = CreateSocket();
        //    sServer.Bind(new IPEndPoint(IPAddress.Any, iPort));
        //    StartFetch(sServer);
        //}



        //public void AttachAcceptCallback(Action<AsyCmpPkg> acceptCallback)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AttachRecvCallback(Action<AsyCmpPkg> recvCallback)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AttachSendCallback(Action<AsyCmpPkg> sendCallback)
        //{
        //    throw new NotImplementedException();
        //}

        public event Action<AsyCmpPkg> OnAcceptCallback;


        public event Action<AsyCmpPkg> OnRecvCallback;

        public event Action<AsyCmpPkg> OnSendCallback;

        protected virtual void AcceptHandler(AsyCmpPkg pkg)
        {
            if(OnAcceptCallback!=null)
            {
                OnAcceptCallback(pkg);
            }
        }
        protected virtual void RecvHandler(AsyCmpPkg pkg)
        {
            if(OnRecvCallback!=null)
            {
                OnRecvCallback(pkg);
            }
        }
        protected virtual void SendHandler(AsyCmpPkg pkg)
        {
            if(OnSendCallback!=null)
            {
                OnSendCallback(pkg);
            }
        }





        
    }
}
