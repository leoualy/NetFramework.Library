using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Library.Network.Http.Methods
{
    internal class GetMethodImpl : AbMethod
    {
        public override void AsyncFun(HttpPkg pack)
        {
            throw new NotImplementedException();
        }

        public override void SyncFun(HttpPkg pack)
        {
            HttpWebRequest req = GetRequestInstance(pack);
            try
            {
                using(WebResponse resp = req.GetResponse())
                {
                    HttpWebResponse httpResp = resp as HttpWebResponse;
                    if (pack.ResponseCallback != null)
                    {
                        // pack.ResponseCallback(httpResp.GetResponseStream());
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private HttpWebRequest GetRequestInstance(HttpPkg pack)
        {
            if (pack == null)
            {
                throw new Exception("自定义Http包结构对象为null");
            }
            string content = pack.Content;
            if (!string.IsNullOrEmpty(content))
            {
                content = string.Format("{0}?{1}", pack.Url, pack.Content);
            }
            HttpWebRequest req = WebRequest.Create(content) as HttpWebRequest;
            PrepareHttpHead(ref req, pack.Method, pack.ContentType, pack.AcceptType);
            return req;
        }

    }
}
