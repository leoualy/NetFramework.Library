using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Library.SingleInstance
{
    public class MutexImpl
    {
        /// <summary>
        /// 开始单实例的检测
        /// </summary>
        /// <param name="name">互斥体名称</param>
        /// <param name="checkResultCallback">检测结果回调</param>
        public static void StartSingleInstaneCheck(string name,Action<bool> checkResultCallback)
        {
            // 是否创建新实例
            bool createNew = true;
            Mutex mtxSingle = new Mutex(true, name, out createNew);
            if(checkResultCallback!=null)
            {
                checkResultCallback(createNew);
            }
        }
    }
}
