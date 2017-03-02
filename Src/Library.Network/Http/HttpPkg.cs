using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.Http
{
    internal class HttpPkg
    {
        #region Head
        public string Url { get; set; }
        public string Method { get; set; }
        public string EncodingName { get; set; }
        public string ContentType { get; set; }
        public string AcceptType { get; set; }
        
        #endregion Head

        #region Data
        public string Content { get; set; }
        #endregion Data

        #region Callback
        public Action<System.IO.Stream,System.Net.HttpStatusCode> ResponseCallback { get; set; }
        #endregion
    }
}
