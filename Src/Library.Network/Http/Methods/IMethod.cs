using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.Http.Methods
{
    internal interface IMethod
    {
        void AsyncFun(HttpPkg pack);
        void SyncFun(HttpPkg pack);
    }
}
