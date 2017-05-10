using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.WinSock
{
    public interface IServer<TData>
    {
        void Start(string ip,int port);
        void Close();

        event Action<TData> OnRecv;
        event Action<TData> OnSend;

        
    }
}
