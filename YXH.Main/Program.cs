using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using YXH.ScanBLL;
using System.Runtime.InteropServices;
using YXH.Common;
using System.Reflection;

namespace YXH.Main
{
    static class Program
    {
        private static BaseDisposeBLL _bdBLL = new BaseDisposeBLL();

        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                SystemInfoHelper.InitApplicationInfo();
                GlobalInfo.ApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                LogHelper.WriteInfoLog("启动程序");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm());

                // Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);   //处理未捕获的异常

                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);   //处理UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException); //处理非UI线程异常

                Application.Run(new LoginForm());

                glExitApp = true;   //标志应用程序可以退出
            }
            catch (Exception ex)
            {
                _bdBLL.System_SaveErrorLog(ex, "应用程序崩溃错误");
                MessageBox.Show("应用程序遇到一个错误需要退出", "点击确定退出并尝试重启程序。", MessageBoxButtons.OK);
                GC.Collect();
                GC.WaitForPendingFinalizers();

                LogHelper.WriteErrorLog(ex.ToString());

                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
                }

                Application.Restart();
            }
        }

        /// <summary>
        /// 是否退出应用程序
        /// </summary>
        static bool glExitApp = false;

        /// <summary>
        /// 处理UI线程异常
        /// </summary>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _bdBLL.System_SaveErrorLog(e.ExceptionObject as Exception, "应用程序异常");

            while (true)    //循环处理，否则应用程序将会退出
            {
                if (glExitApp)
                {
                    //标志应用程序可以退出，否则程序退出后，进程仍然在运行
                    _bdBLL.System_SaveErrorLog(e.ExceptionObject as Exception, "异常允许退出程序");

                    return;
                }

                Thread.Sleep(2 * 1000);
            };
        }

        /// <summary>
        /// 处理线程异常
        /// </summary>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            _bdBLL.System_SaveErrorLog(e.Exception as Exception, "应用程序线程异常");
        }
    }
}
