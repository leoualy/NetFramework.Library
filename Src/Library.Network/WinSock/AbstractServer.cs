using System;
using System.Net.Sockets;

{
    public abstract class AbstractServer<TData> : IServer<TData>
    {
        public void Start(string ip,int port)
        {
            if (mSocketListen == null)
            {
                mSocketListen = mSocketCreator.CreateSocketListen(ip, port);
            }
            
            Ioctrl.OpenKeepAlive(mSocketListen, 3000, 3000);
            mSocketListen.Listen(10);
            mNetIO.Accept(mSocketListen);
        }

        public void Close()
        {
            mSocketListen.Close();
        }

        public event Action<TData> OnRecv;
        public event Action<TData> OnSend;

        protected ISocket mSocketCreator;
        protected INetIO mNetIO;
        private Socket mSocketListen;

    }
}
