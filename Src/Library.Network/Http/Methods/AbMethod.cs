using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Library.Network.Http.Methods
{
    internal abstract  class AbMethod : IMethod
    {
        public abstract void AsyncFun(HttpPkg pack);
        public abstract void SyncFun(HttpPkg pack);

        protected HttpWebRequest GetHttpRequest(string url, string method, string contentType, string acceptType)
        {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.Method = method;
            req.ContentType = contentType;
            req.Accept = acceptType;
            return req;
        }
        
    }
}
