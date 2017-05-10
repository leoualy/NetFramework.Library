using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Library.Network.WinSock
{
    public interface INetIO
    {
        void Accept(Socket socketListen);

    }
}
