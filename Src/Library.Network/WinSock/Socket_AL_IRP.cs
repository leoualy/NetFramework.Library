using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Library.Network.WinSock
{
    public enum OperationType
    {
        NONE=-1,
        SOCK_ACCEPT=0,
        SOCK_RECV,
        SOCK_SEND
    }

    public class Socket_AL_IRP
    {
        private static long irpID = 0;
        public Socket_AL_IRP()
        {
            ID = Interlocked.Increment(ref irpID);
            this.Buffer = new byte[4096];
        }
        /// <summary>
        /// 该IRP的编号
        /// </summary>
        public long ID { get; private set; }
        /// <summary>
        /// 当前要使用的连接ID
        /// </summary>
        public long ConnID { get; set; }
        /// <summary>
        /// 使用当前连接的用户标识，需要区别连接使用者时使用该值
        /// </summary>
        public int ConnUserFlag { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public OperationType OperType { get; set; }

        /// <summary>
        /// 传输的数据缓冲区
        /// </summary>
        public byte[] Buffer { get; set; }
        /// <summary>
        /// 传输数据的长度
        /// </summary>
        public int TransferredLen { get; set; }

        

    }
}
