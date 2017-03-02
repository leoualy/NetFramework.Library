using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.WinSock
{
    public class TcpServer : ServerBase
    {
        public TcpServer() : this(9000,10)
        {
            
        }
        public TcpServer(int port) : this(port, 10) 
        {
        
        }
        public TcpServer(int port,int backlog)
        {
            handler = new AsyncTcpHandler(port, backlog);
            handler.OnAcceptCallback += handler_OnAcceptCallback;
            handler.OnRecvCallback += handler_OnRecvCallback;
            handler.OnSendCallback += handler_OnSendCallback;
        }

        void handler_OnSendCallback(AsyCmpPkg obj)
        {
            throw new NotImplementedException();
        }

        void handler_OnRecvCallback(AsyCmpPkg obj)
        {
            throw new NotImplementedException();
        }

        void handler_OnAcceptCallback(AsyCmpPkg obj)
        {
            throw new NotImplementedException();
        }

        public override void StartServer()
        {
            handler.StartHandler();
        }

        public override void SendHandler()
        {
            throw new NotImplementedException();
        }
    }
}
