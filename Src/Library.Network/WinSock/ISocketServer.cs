using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.WinSock
{
    public interface ISocketServer
    {
        event Action<Socket_AL_IRP> OnAcceptCallback;
        event Action<Socket_AL_IRP> OnRecvCallback;
        event Action<Socket_AL_IRP> OnSendCallback;
        void StartServer();
        void SendHandler();
    }
}
