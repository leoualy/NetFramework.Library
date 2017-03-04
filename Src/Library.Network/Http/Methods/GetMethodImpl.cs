using System;
using System.Net;

namespace Library.Network.Http.Methods
{
    internal class GetMethodImpl : AbMethod
    {
        public override async void AsyncFun(HttpPkg pack)
        {
            if (pack == null)
            {
                throw new Exception("自定义Http包结构对象为null");
            }
            HttpWebRequest req = GetHttpRequest(pack);
            try
            {
                using (HttpWebResponse resp = await req.GetResponseAsync() as HttpWebResponse)
                {
                    OnResponseCallback(resp, pack.ResponseCallback);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void SyncFun(HttpPkg pack)
        {
            if (pack == null)
            {
                throw new Exception("自定义Http包结构对象为null");
            }
            HttpWebRequest req = GetHttpRequest(pack);
            try
            {
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    OnResponseCallback(resp, pack.ResponseCallback);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private HttpWebRequest GetHttpRequest(HttpPkg pkg)
        {
            string content = pkg.Content;
            if (!string.IsNullOrEmpty(content))
            {
                content = string.Format("{0}?{1}", pkg.Url, pkg.Content);
            }
            return WebRequest.Create(content) as HttpWebRequest;
        }

    }
}
