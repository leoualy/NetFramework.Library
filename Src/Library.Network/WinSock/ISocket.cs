﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Library.Network.WinSock
{
    public  interface ISocket
    {
        Socket CreateSocketListen(string ipString, int port);

    }
}
