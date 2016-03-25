using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string classname, string captionName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindowEx(IntPtr parent, IntPtr child, string classname, string captionName);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public bool first;   //第一次打开
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }
        public void post_test(string cookie)
        {
            string postData = "tbrq=2016-03-23&nsrmc=%E5%8D%97%E4%BA%AC%E5%B0%8F%E6%80%AA%E5%85%BD%E8%B4%A2%E5%8A%A1%E4%BF%A1%E6%81%AF%E5%92%A8%E8%AF%A2%E6%9C%89%E9%99%90%E5%85%AC%E5%8F%B8&nsrsbh=320104302723175&swglm=320100100396501&zspmdm=1202&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmmc=1202%20%E8%B5%84%E6%9C%AC%E5%A2%9E%E5%80%BC%E9%A2%9D%EF%BC%88%E5%AE%9E%E6%94%B6%E8%B5%84%E6%9C%AC%E3%80%81%E8%B5%84%E6%9C%AC%E5%85%AC%E7%A7%AF%E7%AD%89%EF%BC%89&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zsfsdm=10&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&sbqx=2016-03-31&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&ssqq=2015-01-01&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqz=2015-12-31&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&jsje=1.00&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&sl=0.000500&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&ying_nse=0.0&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&ybtse=0.0&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&hj_ying_nse=0.0&hj_jmje=&hj_yi_nse=&hj_znje=&hj_ybtse=0.0&sqjc=&bqgj=&bqth=&bqjc=&bbzt=null&bizData=%7B%22BIZDATA%22%3A%5B%7B%22bqybtseje%22%3A%22%22%2C%22bqyjseje%22%3A%22%22%2C%22hdbl%22%3A%22%22%2C%22hdjsje%22%3A%22%22%2C%22impactRowNum%22%3A0%2C%22jmje%22%3A%22%22%2C%22jsje%22%3A%22%22%2C%22pzxh%22%3A%22%22%2C%22qyzt%22%3A%22%22%2C%22req%22%3Anull%2C%22sbbxh%22%3A%22%22%2C%22sbmxxh%22%3A%22%22%2C%22sbqx%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A31%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A2%2C%22seconds%22%3A0%2C%22time%22%3A1459353600000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A116%7D%2C%22timeInMillis%22%3A1459353600000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22sfssqqsrq%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A1%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A0%2C%22seconds%22%3A0%2C%22time%22%3A1420041600000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A115%7D%2C%22timeInMillis%22%3A1420041600000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22sfssqzzrq%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A31%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A11%2C%22seconds%22%3A0%2C%22time%22%3A1451491200000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A115%7D%2C%22timeInMillis%22%3A1451491200000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22shbj%22%3A%22%22%2C%22sl%22%3A%220.0005%22%2C%22sqlParams%22%3A%5B%5D%2C%22status%22%3A%7B%22ZSFS_DM%22%3A%2210%22%2C%22SFSSQ_QSRQ%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A1%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A0%2C%22seconds%22%3A0%2C%22time%22%3A1420041600000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A115%7D%2C%22timeInMillis%22%3A1420041600000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22SFSSQ_ZZRQ%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A31%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A11%2C%22seconds%22%3A0%2C%22time%22%3A1451491200000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A115%7D%2C%22timeInMillis%22%3A1451491200000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22SL%22%3A5.0E-4%2C%22ZSXM_DM%22%3A%2216%22%2C%22SB_QX%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A31%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A2%2C%22seconds%22%3A0%2C%22time%22%3A1459353600000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A116%7D%2C%22timeInMillis%22%3A1459353600000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22ZSPM_DM%22%3A%221202%22%7D%2C%22str_sbqx%22%3A%222016-03-31%22%2C%22str_sfssqqsrq%22%3A%222015-01-01%22%2C%22str_sfssqzzrq%22%3A%222015-12-31%22%2C%22swglm%22%3A%22%22%2C%22yingnseje%22%3A%22%22%2C%22znje%22%3A%22%22%2C%22zsfsdm%22%3A%2210%22%2C%22zspmdm%22%3A%221202%22%2C%22zsxmdm%22%3A%2216%22%7D%5D%2C%22autoSel%22%3A%5B%7B%22content%22%3A%221202%7C%7C0.0005%7C%7Cnull%7C%7C2015-01-01%7C%7C2015-12-31%7C%7C10%7C%7C2016-03-31%22%2C%22parentCode%22%3A%22%22%2C%22text%22%3A%221202%20%E8%B5%84%E6%9C%AC%E5%A2%9E%E5%80%BC%E9%A2%9D%EF%BC%88%E5%AE%9E%E6%94%B6%E8%B5%84%E6%9C%AC%E3%80%81%E8%B5%84%E6%9C%AC%E5%85%AC%E7%A7%AF%E7%AD%89%EF%BC%89%22%7D%5D%7D&gljgdm=23201031300&yhzh=522266790983&qybj=1&errorMessage=&handleDesc=%E5%8D%B0%E8%8A%B1%E7%A8%8E%E8%A1%A8%E6%9A%82%E5%AD%98&handleCode=tempSave&pzxh=&cfsbbh=&fbbj=0&sucessMsg=&hjje=0&proMessage=&caVO.str_signature=&caVO.str_certificate=&nsrQrtjBz=0&txlJyCount=0&qzlJyCount=0&ymKj_Info=&cqSb=0";
            Byte[] postBuffer = Encoding.UTF8.GetBytes(postData);
            //String additionalHeaders = String.Format("{0}:{1}\r\n{2}:{3}", "Accept", "*/*", "User-Agent", "Mozilla/5.0 (Windows NT 5.1; rv:14.0) Gecko/20100101 Firefox/14.0.1");
            String additionalHeaders =
                 "Accept: text/javascript, text/html, application/xml, text/xml, */*\n" +
                "Accept-Language: zh-cn\n" +
                "x-prototype-version: 1.6.0\n" +
                "Referer:https://ca.jsds.gov.cn/wb029_WByhssbAction.do?SSQS=&SSQZ=&SBQX=&SWGLM=320100100396501&ksbsbqxrdm=\n" +
                "x-requested-with: XMLHttpRequest\n" +
                "Content-Type: application/x-www-form-urlencoded; charset=UTF-8\n" +
                "Accept-Encoding: gzip, deflate\n" +
                "User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)\n" +
                "Host: ca.jsds.gov.cn\n" +
                "Content-Length:" + postBuffer.Length +
                "\nConnection: Keep-Alive\n" +
                "Cache-Control: no-cache\n" + 
                "Cookie:"+cookie
                ;
            //Cookie: _gscu_1112616140=52985877gk6s5596; JSID_WSBS=WhRjQQrSxWV0t1qv79n7hCBntrH1hq0yQ8q8nPMJY15kT5X21sw2!1516671385; Secure; _gscu_1161164261=41071794gwlnkd14
           // MessageBox.Show(postData);
            //MessageBox.Show(additionalHeaders);
            string url = "https://ca.jsds.gov.cn/wb029_WByhssbAction.do";
            this.webBrowser.Navigate(url,null, postBuffer, additionalHeaders);
        }
       
        public WebBrowser getWebBrowser()
        {
            return this.webBrowser;
        }

        private void Initialize()
        {
            
            this.webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
            //this.webBrowser.Navigate("https://www.jsds.gov.cn/index/sbLogin.do");
            first = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //到主页关闭定时器1
            if(webBrowser.Document.Url.ToString() != "https://ca.jsds.gov.cn/index/caLogin.html"|| webBrowser.Document.Url.ToString() == "http://www.jsds.gov.cn/index/caLogin.html#")
            {
                timer1.Enabled = false;
               // MessageBox.Show("timer1 stop");
            }
            

            HtmlDocument doc = this.webBrowser.Document;   //把当前的webBrowser1显示的文档实例
            HtmlElementCollection elemColl = doc.GetElementsByTagName("a");
            foreach (HtmlElement elem in elemColl)
            {
                string elemName = elem.GetAttribute("href");    //按钮
                if (elemName.Equals("http://www.jsds.gov.cn/index/caLogin.html#"))
                {
                    //find!
                    elem.InvokeMember("click"); //点击登陆
                }

            }

            IntPtr mwh1 = IntPtr.Zero;
            mwh1 = FindWindow(null, "数字证书登录");
            if (mwh1 != IntPtr.Zero)
            {
                IntPtr edit = FindWindowEx(mwh1, IntPtr.Zero, "Edit", null);
              //  IntPtr button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "确定");
                if (edit != IntPtr.Zero)
                {
                    //MessageBox.Show("find edit");
                    SendMessage(edit, 0xC, IntPtr.Zero, "123456");
                    SendKeys.SendWait("{Enter}");
                    SendKeys.Flush();
                //    this.timer1.Enabled = false;    //关闭定时器
                    //MessageBox.Show("timer1 stop");
                }
            }
          
        }

        private void button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.webBrowser.GoForward();
        }

        private void button_go_Click(object sender, EventArgs e)
        {
            string url = this.textBox_url.Text;
            this.webBrowser.Navigate(url);
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
        
            post_test(webBrowser.Document.Cookie);
       //     Thread.Sleep(3000);
            //webBrowser.Navigate("https://ca.jsds.gov.cn/sbLogin.do");
        }

      

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            LoginCheck();   //检测是否登陆成功
            //登陆主页 打开timer1
            if (webBrowser.Document.Url.ToString() == "http://www.jsds.gov.cn/index/caLogin.html" || webBrowser.Document.Url.ToString() == "http://www.jsds.gov.cn/index/caLogin.html#")
            {
                timer1.Enabled = true;
            }
            // timer2.Enabled = true;

            //提交失败等情况 返回主页了
            if (webBrowser.Document.Url.ToString() == "http://www.jsds.gov.cn/")
            {
                this.webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
                this.timer1.Enabled = true;
                IntPtr mwh1 = IntPtr.Zero;
                mwh1 = FindWindow(null, "安全警告");
                if (mwh1 != IntPtr.Zero)
                {
                    IntPtr Button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "否(&N)");
                    //  IntPtr button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "确定");
                    if (Button != IntPtr.Zero)
                    {
                        //MessageBox.Show("find edit");
                    //    SendMessage(Button, 0xC, IntPtr.Zero, "123456");
                        SendKeys.SendWait("{Enter}");
                        SendKeys.Flush();
                    }
                }
            }
            //显示URL
            textBox_url.Text = this.webBrowser.Url.ToString();
        }

        private void LoginCheck()
        {
            HtmlDocument doc = this.webBrowser.Document;   //把当前的webBrowser1显示的文档实例
            HtmlElementCollection elemColl = doc.GetElementsByTagName("div");
            foreach (HtmlElement elem in elemColl)
            {
                string elemName = elem.GetAttribute("id");
                if (elemName.Equals("无法显示此页"))
                {
                    MessageBox.Show("登陆失败");
                    this.webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
                    this.timer1.Enabled = true;
                }
            }
        }

        private void webBrowser_NewWindow(object sender, CancelEventArgs e)
        {

            //打开新窗口的方式是在已有的窗口内打开
            webBrowser.Url = new Uri(((WebBrowser)sender).StatusText);
            e.Cancel = true;

    }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if(webBrowser.Document.Url.ToString() == "https://ca.jsds.gov.cn/")
            {
                this.webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
                this.timer1.Enabled = true;
            }
        }
    }
}
