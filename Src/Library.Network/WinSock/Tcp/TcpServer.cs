using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.WinSock.Tcp
{
    public class TcpServer :AbstractServer<string>
    {
        public TcpServer()
        {
            mSocketCreator = new TcpSocket();
        }
    }
}
