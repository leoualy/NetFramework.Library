using System;
using System.IO;
using System.Net;

namespace Library.Network.Http
{
    public abstract class HttperImpl : IHttper
    {
        public abstract void SendRequestByGet(string url, string content,
            string contentType, string acceptType, string encodingName,
            Action<Stream, HttpStatusCode> responseHandler);

        public abstract void SendRequestByPost(string url, string content, 
            string contentType, string acceptType, string encodingName, 
            Action<Stream, HttpStatusCode> responseHandler);

        protected HttpPkg CreateHttpPkg(string url,string content,string method,
            string contentType,string acceptType,
            string encodingName, Action<System.IO.Stream, System.Net.HttpStatusCode> responseHandler)
        {
            return new HttpPkg()
            {
                Url = url,
                Content = content,
                Method = method,
                ContentType = contentType,
                AcceptType = acceptType,
                EncodingName = encodingName,
                ResponseCallback = responseHandler
            };
        }
    }
}
