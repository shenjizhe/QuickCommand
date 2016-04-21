using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using SpringBootCodeFactory.code.view;
using common.code.register;
using System.Runtime.InteropServices;

namespace QuickCommand
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);
        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(int pfwi);

        private static void HandleRunningInstance(Process instance)
        {
            FlashWindow(instance.MainWindowHandle, true);
        }

        [STAThread]
        static void Main()
        {
            bool success = false;
            try
            {
                string certification = LicenceHelper.ReadLicenceFile();
                success = LicenceHelper.VerifyCertificate(certification);
                if(success)
                {
                    run();
                }
            }
            catch (Exception ex)
            {

            }
            if (!success)
            {
                MessageDialog dialog = new MessageDialog();
                string code = LicenceHelper.GenerationCode();
                dialog.ShowDialog("请申请注册文件(thirdlucky@126.com)", code);
            }
        }

        private static void run()
        {
            Process[] processes = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
            if (processes.Length > 1)
            {
                //MessageBox.Show("应用程序已经在运行中。。" + Application.ProductName);
                HandleRunningInstance(processes[0]);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                    Application.Run(new FormCommand());
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
