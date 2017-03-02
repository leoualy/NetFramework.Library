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
            HttpWebRequest req;
            byte[] buffer = GetUserBytes(pack);
            // 设置Http头
            PrepareHttpHead(ref mHttpRequest, pack.Method, pack.ContentType, pack.AcceptType);

            try
            {
                // 有要提交的数据时通过Post方法提交，需要添加没有需要提交的数据时的处理
                using (Stream s = mHttpRequest.GetRequestStream())
                {
                    s.Write(buffer,0,buffer.Length);
                }
                HttpWebResponse response = mHttpRequest.GetResponse() as HttpWebResponse;
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

        

        private byte[] GetUserBytes(HttpPkg pkg)
        {
            if (pkg == null)
            {
                throw new Exception("自定义Http包结构对象为null");
            }
            Encoding encoding = Encoding.GetEncoding(pkg.EncodingName);
            int len = encoding.GetByteCount(pkg.Content);

            mHttpRequest= WebRequest.Create(pkg.Url) as HttpWebRequest;
            return encoding.GetBytes(pkg.Content);
        }


    }
}
