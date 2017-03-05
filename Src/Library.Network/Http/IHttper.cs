using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.Http
{
    public interface IHttper
    {
        void SendRequestByGet(string url, string content, string contentType, string acceptType, string encodingName, Action<System.IO.Stream, System.Net.HttpStatusCode> responseHandler);
        void SendRequestByPost(string url, string content, string contentType, string acceptType, string encodingName, Action<System.IO.Stream, System.Net.HttpStatusCode> responseHandler);

    }
}
