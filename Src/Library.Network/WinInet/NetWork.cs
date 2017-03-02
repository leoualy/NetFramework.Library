/***************************************************************************
 * 文件名:            NetWork.cs
 * 作者：              liuy
 * 日期：              2016-11-29
 * 描述：              用于网络状态判断，后续可能会增加对上网方式的遍历
***************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace Library.Network.WinInet
{
    internal class NetWork
    {
        // 判断当前网络状态Win32 API
        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref   int dwFlag, int dwReserved);
        /// <summary>
        /// 获取网络状态
        /// </summary>
        /// <returns>true -已连接      false-未连接</returns>
        public static bool IsConnected()
        {
            int dwFlag = 0;
            return InternetGetConnectedState(ref dwFlag,0);
        }
    }
}
