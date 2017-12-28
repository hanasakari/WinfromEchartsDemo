/**
 *@author : Asuka_Amamiya
 * 1581D74474541240775B23A6818F1DB7
 * 这是一个js和winform结合的demo
 * 请不要删除作者信息
 */
using System;
using System.Windows.Forms;
using System.Security.Permissions;
using CefSharp;
using CefSharp.WinForms;
using System.Threading;

namespace wintest
{    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }

        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            CefSettings setting = new CefSettings();
            setting.Locale = "UTF-8";
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\static\\chartPage.html";
            path = "file://" + path.Replace("\\", "/");
            Cef.Initialize(setting);
            browser = new ChromiumWebBrowser(path);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill; //满窗体
            //注册js对象
            browser.RegisterJsObject("rtn", new GetJson());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //加载图表
            browser.ExecuteScriptAsync("location.reload()");//js刷新
            Thread.Sleep(500);//等待0.5s
            browser.ExecuteScriptAsync("recall()");//调用js获取数据
        }
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    class GetJson
    {
        public string ReturnJson
        {
            get
            {
                Random random = new Random();
                string rtnJson = "";
                rtnJson += "{ \"data\" : [";
                rtnJson += "{\"date\" : \"01:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"02:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"03:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"04:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"05:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"06:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"07:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"08:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"09:00\" ,\"data\" : \""+random.Next()+"\"},";
                rtnJson += "{\"date\" : \"10:00\" ,\"data\" : \""+random.Next()+"\" },";
                rtnJson += "{\"date\" : \"11:00\" ,\"data\" : \""+random.Next()+"\" },";
                rtnJson += "{\"date\" : \"12:00\" ,\"data\" : \""+random.Next()+"\" },";
                rtnJson += "{\"date\" : \"13:00\" ,\"data\" : \""+random.Next()+"\" },";
                rtnJson += "{\"date\" : \"14:00\" ,\"data\" : \""+random.Next()+"\" },";
                rtnJson += "{\"date\" : \"15:00\" ,\"data\" : \""+random.Next()+"\" },";
                rtnJson += "{\"date\" : \"16:00\" ,\"data\" : \""+random.Next()+"\" }";
                rtnJson += "]" +                                  
                    "}";                                          
                return rtnJson;                                   
            }                                                     
        }                                                         
    }                                                             
}                                                                 
                                                                  
                                                                  