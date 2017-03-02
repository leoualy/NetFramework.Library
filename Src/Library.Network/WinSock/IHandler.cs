using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Library.Network.WinSock
{
    internal interface IHandler
    {
        event Action<AsyCmpPkg> OnAcceptCallback;
        event Action<AsyCmpPkg> OnRecvCallback;
        event Action<AsyCmpPkg> OnSendCallback;


        void StartHandler();
        void PostAccept(Socket sListen);
        /// <summary>
        /// 投递一个Send操作
        /// </summary>
        /// <param name="sClient"></param>
        void PostSend(Socket sClient);
        /// <summary>
        /// 投递一个Recv请求
        /// </summary>
        /// <param name="sClient"></param>
        void PostRecv(Socket sClient);
    }
}
