/**
 *@author : Asuka_Amamiya
 * 1581D74474541240775B23A6818F1DB7
 */
using System;
using System.Windows.Forms;

namespace wintest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
