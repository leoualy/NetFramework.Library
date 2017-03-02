using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Network.WinSock
{
    public delegate void SocketExceptionOutputEventHandler(SocketExceptionOutputEventArgs e);
    public class SocketExceptionOutputEventArgs : EventArgs
    {
        public SocketExceptionOutputEventArgs() { }
        public SocketExceptionOutputEventArgs(Type sourceClass,Exception exceptionInstance,string exceptionDescr)
        {
            SourceClass = sourceClass;
            ThrowDateTime=DateTime.Now;
            ExceptionInstance = exceptionInstance;
            ExecptionDescr = exceptionDescr;

        }
        /// <summary>
        /// 异常来源类型
        /// </summary>
        public Type SourceClass { get; set; }
        /// <summary>
        /// 抛出时间
        /// </summary>
        public DateTime ThrowDateTime { get; set; }
        public Exception ExceptionInstance { get; set; }
        // 异常描述
        public string ExecptionDescr { get; set; }
    }

    public class SocketExceptionManager
    {
        private SocketExceptionManager() { }
        
        public static event SocketExceptionOutputEventHandler OnSocketExceptionOutput;

        public static  void SocketExceptionOutputHandle(EventArgs e)
        {
            if(OnSocketExceptionOutput!=null)
            {
                OnSocketExceptionOutput((SocketExceptionOutputEventArgs)e);
                return;
            }
#if DEBUG
            {
                throw new Exception("Socket异常处理事件为空");
            }
#endif

        }

        public static string CreateFormatExceptionDescr(string funName,string exceptionDescr)
        {
            return string.Format("函数:{},异常描述:{1}",
                        "SocketBase.Listen",
                       "函数：{0} 异常描述：{1}", "SocketBase.Bind", "Socket 绑定时错误");
        }


    }
}
