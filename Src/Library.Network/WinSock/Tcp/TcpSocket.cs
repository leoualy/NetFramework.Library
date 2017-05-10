using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Library.Network.WinSock.Tcp
{
    public class TcpSocket : AbstractSocket
    {
        internal TcpSocket() : base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) { }
    }
}
