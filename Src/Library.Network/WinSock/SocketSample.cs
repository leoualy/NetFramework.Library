using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Library.Network.WinSock
{
    public class SocketSample
    {
        public SocketSample(int port)
        {
            mSocketListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mSocketListen.Bind((EndPoint)(new IPEndPoint(IPAddress.Any, port)));
            mSocketListen.Listen(10);
            Ioctrl.OpenKeepAlive(mSocketListen, 1000, 3000);
        }
        private int mIntCount = 0;
        private Socket mSocketListen;

        public void Start(Action<int> action)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Socket socket = mSocketListen.Accept();
                   
                    mIntCount += 1;
                    if (action != null)
                    {
                        action(mIntCount);
                    }
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            int len = socket.Receive(new byte[1024]);
                            if (len <= 0)
                            {
                                mIntCount -= 1;
                                action(mIntCount);
                            }
                        }
                        catch(Exception e)
                        {
                            mIntCount -= 1;
                            action(mIntCount);
                        }
                        
                    });
                }


            });
        }



    }
}
