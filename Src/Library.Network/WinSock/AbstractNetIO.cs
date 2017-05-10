using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.WinSock
{
    public abstract class AbstractNetIO : INetIO
    {
        public void Accept(Socket socketListen)
        {
            throw new NotImplementedException();
        }
    }
}
