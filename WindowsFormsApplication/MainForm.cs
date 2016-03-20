using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Initialize();
            getWebBrowser();

        }
        public WebBrowser getWebBrowser()
        {
            return this.webBrowser;
        }

        private void Initialize()
        {
            this.webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
            //this.webBrowser.Navigate("https://www.jsds.gov.cn/index/sbLogin.do");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = this.webBrowser.Document;   //把当前的webBrowser1显示的文档实例
            HtmlElementCollection elemColl = doc.GetElementsByTagName("a");
            //MessageBox.Show(  webBrowser.DocumentText );
           // MessageBox.Show(elemColl.Count.ToString() );
            foreach (HtmlElement elem in elemColl)
            {
                string elemName = elem.GetAttribute("href");
                if(elemName.Equals("http://www.jsds.gov.cn/index/caLogin.html#"))
                {
                    //MessageBox.Show("find!");
                    elem.InvokeMember("click"); //点击登陆

                    Thread.Sleep(3000);
                    //模拟输入 密码
                    IntPtr hwndCalc = FindWindow("#32770", null); //查找窗口句柄
                    if (hwndCalc != IntPtr.Zero)//找到
                    {
                        SetForegroundWindow(hwndCalc);
                        System.Windows.Forms.SendKeys.SendWait("{TAB}");
                        System.Windows.Forms.SendKeys.SendWait("{TAB}");
                        System.Windows.Forms.SendKeys.SendWait("123456");
                        System.Windows.Forms.SendKeys.SendWait("{TAB}");
                        System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                    }
                    else
                    {
                       // MessageBox.Show("没有启动 ");
                    }
                }         

            }
            //if (doc.All.Count != 0)
            //{

            //    for (int i = 0; i < doc.All.Count; i++)          //循环查找这个对象的每一个元素
            //    {
            //        if (doc.All[i].GetAttribute("class") == "link-login")
            //        {
            //            doc.All[i].InvokeMember("click");
            //            break;
            //        }

            //    }
            //}
        }

    }
}
