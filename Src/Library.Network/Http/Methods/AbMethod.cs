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

        protected HttpWebRequest mHttpRequest;

        /// <summary>
        /// 设置Http头
        /// </summary>
        /// <param name="req">传入的请求对象</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">请求内容格式</param>
        /// <param name="acceptType">可接受的内容格式</param>
        protected void PrepareHttpHead(ref HttpWebRequest req,
            string method,string contentType,string acceptType)
        {
            if (req == null)
            {
                throw new Exception("在设置请求对象头时请求对象为null");
            }
            req.Method = method;
            req.ContentType = contentType;
            req.Accept = acceptType;
        }
        
    }
}
