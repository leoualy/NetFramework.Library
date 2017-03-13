using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Library.Network.WinSock
{
    internal class Ioctrl
    {
        #region 开启低级探测
        /// <summary>
        /// 启动低级操作，探测网络状况，主要用来处理意外断网
        /// </summary>
        /// <param name="socket">socket</param>
        /// <param name="beginTime">多长时间开始探测事件（毫秒）</param>
        /// <param name="interval">多长时间探测一次（毫秒）</param>
        internal static void OpenKeepAlive(Socket socket,int openTime,int interval)
        {
            socket.IOControl(IOControlCode.KeepAliveValues, GetOptionInValue(openTime,interval), null);
        }

        /// <summary>
        /// 获取操作输入值
        /// </summary>
        /// <param name="openTime">多长时间后探测</param>
        /// <param name="interval">多长时间探测一次</param>
        /// <returns></returns>
        private static byte[] GetOptionInValue(int openTime,int interval)
        {
            return new byte[12]
            {
                1,0,0,0,
                GetByteFromInt(openTime,0),
                GetByteFromInt(openTime,8),
                GetByteFromInt(openTime,16),
                GetByteFromInt(openTime,24),
                GetByteFromInt(interval,0),
                GetByteFromInt(interval,8),
                GetByteFromInt(interval,16),
                GetByteFromInt(interval,24)
            };
        }
        /// <summary>
        /// 获取整型数值中的某个字节
        /// </summary>
        /// <param name="value">源整数值</param>
        /// <param name="offset">字节位数变量 8的倍数</param>
        /// <returns></returns>
        private static byte GetByteFromInt(int value,int offset)
        {
            return (byte)(value >> offset &0xFF);
        }
        #endregion
    }
}
