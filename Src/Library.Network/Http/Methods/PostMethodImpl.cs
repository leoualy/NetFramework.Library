using System;
using System.Text;
using System.Net;
using System.IO;

namespace Library.Network.Http.Methods
{
    internal class PostMethodImpl : AbMethod
    {
        public override async void AsyncFun(HttpPkg pack)
        {
            if (pack == null)
            {
                throw new Exception("要发送的http结构包为null");
            }
            HttpWebRequest req = PrepareHttpWebRequest(pack);
            byte[] buffer = GetContentBytes(pack.Content, pack.EncodingName);

            try
            {
                // 有要提交的数据时通过Post方法提交，需要添加没有需要提交的数据时的处理
                using (Stream s = await req.GetRequestStreamAsync())
                {
                    await s.WriteAsync(buffer, 0, buffer.Length);
                }
                using(HttpWebResponse response = await req.GetResponseAsync() as HttpWebResponse)
                {
                    OnResponseCallback(await req.GetResponseAsync() as HttpWebResponse, pack.ResponseCallback);
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
                throw new Exception("要发送的http结构包为null");
            }

            HttpWebRequest req = PrepareHttpWebRequest(pack);
            byte[] buffer = GetContentBytes(pack.Content, pack.EncodingName);
            
            try
            {
                // 有要提交的数据时通过Post方法提交，需要添加没有需要提交的数据时的处理
                using (Stream s = req.GetRequestStream())
                {
                    s.Write(buffer,0,buffer.Length);
                }
                using(HttpWebResponse response = req.GetResponse() as HttpWebResponse)
                {
                    OnResponseCallback(response, pack.ResponseCallback);
                }
                req.Abort();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private byte[] GetContentBytes(string content,string encodingName)
        {
            return Encoding.GetEncoding(encodingName).GetBytes(content);
        }

        private HttpWebRequest PrepareHttpWebRequest(HttpPkg pkg)
        {
            HttpWebRequest req = WebRequest.Create(pkg.Url) as HttpWebRequest;
            req.Method = pkg.Method;
            req.ContentType = pkg.ContentType;
            req.Accept = pkg.AcceptType;
            return req;
        }

    }
}
