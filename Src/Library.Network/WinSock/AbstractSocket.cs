using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Library.Network.WinSock
{
    public abstract class AbstractSocket : ISocket
    {
        internal AbstractSocket(AddressFamily addressFamily,SocketType socketType,ProtocolType protocolType)
        {
            mSocketListen = new Socket(addressFamily, socketType, protocolType);
        }

        public Socket CreateSocketListen(string ipString,int port)
        {
            IPEndPoint endPointServer = new IPEndPoint(IPAddress.Parse(ipString), port);
            try
            {
                mSocketListen.Bind((EndPoint)endPointServer);
            }
            catch(Exception e)
            {
                throw new Exception(string.Format("监听Socket绑定本地端口时异常，异常消息{0}", e.Message));
            }
            
            return mSocketListen;
        }

        private Socket mSocketListen;
    }
}
