using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Library.SingleInstance;

namespace Sample.wpf
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MutexImpl.StartSingleInstaneCheck("QMS", new Action<bool>(createNew =>
            {
                if(!createNew)
                {
                    MessageBox.Show("QMS程序实例正在运行", "提示");
                    Application.Current.Shutdown();
                }

            }));
            base.OnStartup(e);
        }
    }
}
