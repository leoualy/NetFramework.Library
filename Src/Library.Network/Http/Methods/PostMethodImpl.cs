using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;

namespace Library.Network.Http.Methods
{
    internal class PostMethodImpl : AbMethod
    {
        public override void AsyncFun(HttpPkg pack)
        {
            
        }

        public override void SyncFun(HttpPkg pack)
        {
            HttpWebRequest req = GetHttpRequest(pack.Url, pack.Method, pack.ContentType, pack.AcceptType);
            byte[] buffer = GetContentBytes(pack.Content, pack.EncodingName);
            req.ContentLength = buffer.Length;

            try
            {
                // 有要提交的数据时通过Post方法提交，需要添加没有需要提交的数据时的处理
                using (Stream s = req.GetRequestStream())
                {
                    s.Write(buffer,0,buffer.Length);
                }
                HttpWebResponse response = req.GetResponse() as HttpWebResponse;
                if (pack.ResponseCallback != null)
                {
                    pack.ResponseCallback(response.GetResponseStream(), response.StatusCode);
                }
                response.Close();
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


    }
}
