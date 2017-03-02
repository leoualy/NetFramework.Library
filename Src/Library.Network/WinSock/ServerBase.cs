using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.WinSock
{
    public abstract class ServerBase : ISocketServer
    {
       
        void handler_OnSendCallback(AsyCmpPkg obj)
        {
            // throw new NotImplementedException();
            if(OnSendCallback!=null)
            {
                OnSendCallback(null);
            }
        }

        void handler_OnRecvCallback(AsyCmpPkg obj)
        {
            //throw new NotImplementedException();
            if(OnRecvCallback!=null)
            {
                OnRecvCallback(null);
            }
        }

        void handler_OnAcceptCallback(AsyCmpPkg obj)
        {
            if(OnAcceptCallback!=null)
            {
                OnAcceptCallback(null);
            }
        }

        internal IHandler handler;
        public abstract void StartServer();
        public abstract void SendHandler();
        
        protected void HandleIO(Socket_AL_IRP irp)
        {
            if(irp==null)
            {
                return;
            }
            switch(irp.OperType)
            {
                case OperationType.SOCK_ACCEPT:
                    {
                        // handler.PostAccept()
                    }
                    break;
            }


        }



        public event Action<Socket_AL_IRP> OnAcceptCallback;
        

        public event Action<Socket_AL_IRP> OnRecvCallback;

        public event Action<Socket_AL_IRP> OnSendCallback;
    }
}
