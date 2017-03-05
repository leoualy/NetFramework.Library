using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Library.Network.Http.Methods;

namespace Library.Network.Http
{
    public class Httper : HttperImpl
    {
        public Httper()
        {
            mGetMethod = new GetMethodImpl();
            mPostMethod = new PostMethodImpl();
        }
        private IMethod mGetMethod, mPostMethod;

        public override void SendRequestByGet(string url, string content, string contentType, string acceptType, 
            string encodingName, Action<Stream, HttpStatusCode> responseHandler)
        {
            mGetMethod.SyncFun(
                CreateHttpPkg(url, content, "Get", contentType, acceptType, encodingName, responseHandler)
                );
        }

        public override void SendRequestByPost(string url, string content, string contentType, string acceptType, 
            string encodingName, Action<Stream, HttpStatusCode> responseHandler)
        {
            mPostMethod.SyncFun(
                CreateHttpPkg(url, content, "Get", contentType, acceptType, encodingName, responseHandler)
                );
        }
    }
}
