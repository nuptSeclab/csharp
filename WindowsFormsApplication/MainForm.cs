using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        int failCount = 0;  //登陆失败次数
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }
        
        private void Initialize()
        {

            //    webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
            //this.webBrowser.Navigate("https://www.jsds.gov.cn/index/sbLogin.do");
            //webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/static/main.jsp");
            //webBrowserGS.ScrollBarsEnabled = false;

        }

        //timer1 用于数字登陆输入密码
        private void timer1_Tick(object sender, EventArgs e)
        {

            //到主页关闭定时器1
            if (webBrowser.Document.Url.ToString() != "http://ca.jsds.gov.cn/index/caLogin.html"|| webBrowser.Document.Url.ToString() == "http://www.jsds.gov.cn/index/caLogin.html#")
            {
                timer1.Enabled = false;
               // MessageBox.Show("timer1 stop");
            }
            //检测数字证书登陆输入框
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

        //退出按钮
        private void button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //后退按钮
        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser.GoBack();
            textBox_url.Text = this.webBrowser.Url.ToString();   //显示URL
        }

        //前进按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.webBrowser.GoForward();
            textBox_url.Text = this.webBrowser.Url.ToString();   //显示URL
        }

        //Go按钮
        private void button_go_Click(object sender, EventArgs e)
        {
            string url = this.textBox_url.Text;
            this.webBrowser.Navigate(url);
        }

        //印花税暂存按钮
        private void button_submit_Click(object sender, EventArgs e)
        {
        
            post_yhs(webBrowser.Document.Cookie);
       //     Thread.Sleep(3000);
            //webBrowser.Navigate("https://ca.jsds.gov.cn/sbLogin.do");
        }


        //地税浏览器webBrowser_DocumentCompleted
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            LoginCheck();       //检测是否登陆成功
            string url = webBrowser.Document.Url.ToString();

            ClickLogin(url);    //登陆主页 点击按钮            
            // timer2.Enabled = true;            
            FailCheck(url);     //提交失败等情况 返回主页了



            textBox_HTML.Text = webBrowser.DocumentText;            
        }

        /*提交失败等情况 返回主页了*/
        private void FailCheck(string url)
        {
            if (url == "http://www.jsds.gov.cn/" || url== "https://ca.jsds.gov.cn/")
            {
                this.webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
                this.timer1.Enabled = true;
                IntPtr mwh1 = IntPtr.Zero;
                mwh1 = FindWindow(null, "安全警告");
                if (mwh1 != IntPtr.Zero)
                {
                    IntPtr Button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "否(&N)");
                    if (Button != IntPtr.Zero)
                    {
                        SendKeys.SendWait("{Enter}");
                        SendKeys.Flush();
                    }
                }
            }
        }

        private void GsSecurityCheck()
        {
            IntPtr mwh1 = IntPtr.Zero;
            mwh1 = FindWindow(null, "安全警报");
            if (mwh1 != IntPtr.Zero)
            {
                IntPtr Button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "是(&Y)");
                if (Button != IntPtr.Zero)
                {
                    SendMessage(Button, 0xF5,IntPtr.Zero, null);
                }
            }
        }

        //地税主页 点击登陆按钮 开timer1
        private void ClickLogin(string url)
        {
            
            if (url == "http://www.jsds.gov.cn/index/caLogin.html" || url == "http://www.jsds.gov.cn/index/caLogin.html#")
            {
                //点击按钮登陆主页
                HtmlDocument doc = webBrowser.Document;   //把当前的webBrowser1显示的文档实例
                HtmlElementCollection elemColl = doc.GetElementsByTagName("a");
                foreach (HtmlElement elem in elemColl)
                {
                    string elemName = elem.GetAttribute("href");    //按钮
                    if (elemName.Equals("http://www.jsds.gov.cn/index/caLogin.html#"))
                    {
                        //find!
                        elem.InvokeMember("click"); //点击登陆
                        //定时器1用于输入Ukey密码
                        timer1.Enabled = true;
                        break;
                    }
                }
            }
        }

        //地税登陆失败检测
        private void LoginCheck()
        {
            HtmlDocument doc = this.webBrowser.Document;   //把当前的webBrowser1显示的文档实例
            HtmlElementCollection elemColl = doc.GetElementsByTagName("div");
            foreach (HtmlElement elem in elemColl)
            {
                string elemName = elem.GetAttribute("mainTitle");
                if (elem.InnerHtml.Equals("无法显示此页"))
                {
                    //   MessageBox.Show("登陆失败"+ elem.InnerHtml);
                    failCount++;
                   if(failCount<10)
                        this.webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
                    //this.timer1.Enabled = true;
                }
            }
        }
        
        //timer2 
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(webBrowser.Document.Url.ToString() == "https://ca.jsds.gov.cn/")
            {
                this.webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
                this.timer1.Enabled = true;
            }
        }

        /*印花税暂存POST设置 通过*/
        public void post_yhs(string cookie)
        {
            
            string postData = "tbrq=2016-03-23&nsrmc=%E5%8D%97%E4%BA%AC%E5%B0%8F%E6%80%AA%E5%85%BD%E8%B4%A2%E5%8A%A1%E4%BF%A1%E6%81%AF%E5%92%A8%E8%AF%A2%E6%9C%89%E9%99%90%E5%85%AC%E5%8F%B8&nsrsbh=320104302723175&swglm=320100100396501&zspmdm=1202&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmdm=&zspmmc=1202%20%E8%B5%84%E6%9C%AC%E5%A2%9E%E5%80%BC%E9%A2%9D%EF%BC%88%E5%AE%9E%E6%94%B6%E8%B5%84%E6%9C%AC%E3%80%81%E8%B5%84%E6%9C%AC%E5%85%AC%E7%A7%AF%E7%AD%89%EF%BC%89&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zspmmc=&zsfsdm=10&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&zsfsdm=&sbqx=2016-03-31&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&sbqx=&ssqq=2015-01-01&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqq=&ssqz=2015-12-31&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&ssqz=&jsje=1.00&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_jsje=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&hd_bl=&sl=0.000500&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&sl=&ying_nse=0.0&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&ying_nse=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&jmje=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&yi_nse=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&znje=&ybtse=0.0&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&ybtse=&hj_ying_nse=0.0&hj_jmje=&hj_yi_nse=&hj_znje=&hj_ybtse=0.0&sqjc=&bqgj=&bqth=&bqjc=&bbzt=null&bizData=%7B%22BIZDATA%22%3A%5B%7B%22bqybtseje%22%3A%22%22%2C%22bqyjseje%22%3A%22%22%2C%22hdbl%22%3A%22%22%2C%22hdjsje%22%3A%22%22%2C%22impactRowNum%22%3A0%2C%22jmje%22%3A%22%22%2C%22jsje%22%3A%22%22%2C%22pzxh%22%3A%22%22%2C%22qyzt%22%3A%22%22%2C%22req%22%3Anull%2C%22sbbxh%22%3A%22%22%2C%22sbmxxh%22%3A%22%22%2C%22sbqx%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A31%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A2%2C%22seconds%22%3A0%2C%22time%22%3A1459353600000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A116%7D%2C%22timeInMillis%22%3A1459353600000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22sfssqqsrq%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A1%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A0%2C%22seconds%22%3A0%2C%22time%22%3A1420041600000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A115%7D%2C%22timeInMillis%22%3A1420041600000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22sfssqzzrq%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A31%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A11%2C%22seconds%22%3A0%2C%22time%22%3A1451491200000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A115%7D%2C%22timeInMillis%22%3A1451491200000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22shbj%22%3A%22%22%2C%22sl%22%3A%220.0005%22%2C%22sqlParams%22%3A%5B%5D%2C%22status%22%3A%7B%22ZSFS_DM%22%3A%2210%22%2C%22SFSSQ_QSRQ%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A1%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A0%2C%22seconds%22%3A0%2C%22time%22%3A1420041600000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A115%7D%2C%22timeInMillis%22%3A1420041600000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22SFSSQ_ZZRQ%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A31%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A11%2C%22seconds%22%3A0%2C%22time%22%3A1451491200000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A115%7D%2C%22timeInMillis%22%3A1451491200000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22SL%22%3A5.0E-4%2C%22ZSXM_DM%22%3A%2216%22%2C%22SB_QX%22%3A%7B%22firstDayOfWeek%22%3A1%2C%22gregorianChange%22%3A%7B%22date%22%3A15%2C%22day%22%3A5%2C%22hours%22%3A8%2C%22minutes%22%3A0%2C%22month%22%3A9%2C%22seconds%22%3A0%2C%22time%22%3A-12219292800000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A-318%7D%2C%22lenient%22%3Atrue%2C%22minimalDaysInFirstWeek%22%3A1%2C%22time%22%3A%7B%22date%22%3A31%2C%22day%22%3A4%2C%22hours%22%3A0%2C%22minutes%22%3A0%2C%22month%22%3A2%2C%22seconds%22%3A0%2C%22time%22%3A1459353600000%2C%22timezoneOffset%22%3A-480%2C%22year%22%3A116%7D%2C%22timeInMillis%22%3A1459353600000%2C%22timeZone%22%3A%7B%22DSTSavings%22%3A0%2C%22ID%22%3A%22PRC%22%2C%22displayName%22%3A%22China%20Standard%20Time%22%2C%22lastRuleInstance%22%3Anull%2C%22rawOffset%22%3A28800000%7D%7D%2C%22ZSPM_DM%22%3A%221202%22%7D%2C%22str_sbqx%22%3A%222016-03-31%22%2C%22str_sfssqqsrq%22%3A%222015-01-01%22%2C%22str_sfssqzzrq%22%3A%222015-12-31%22%2C%22swglm%22%3A%22%22%2C%22yingnseje%22%3A%22%22%2C%22znje%22%3A%22%22%2C%22zsfsdm%22%3A%2210%22%2C%22zspmdm%22%3A%221202%22%2C%22zsxmdm%22%3A%2216%22%7D%5D%2C%22autoSel%22%3A%5B%7B%22content%22%3A%221202%7C%7C0.0005%7C%7Cnull%7C%7C2015-01-01%7C%7C2015-12-31%7C%7C10%7C%7C2016-03-31%22%2C%22parentCode%22%3A%22%22%2C%22text%22%3A%221202%20%E8%B5%84%E6%9C%AC%E5%A2%9E%E5%80%BC%E9%A2%9D%EF%BC%88%E5%AE%9E%E6%94%B6%E8%B5%84%E6%9C%AC%E3%80%81%E8%B5%84%E6%9C%AC%E5%85%AC%E7%A7%AF%E7%AD%89%EF%BC%89%22%7D%5D%7D&gljgdm=23201031300&yhzh=522266790983&qybj=1&errorMessage=&handleDesc=%E5%8D%B0%E8%8A%B1%E7%A8%8E%E8%A1%A8%E6%9A%82%E5%AD%98&handleCode=tempSave&pzxh=&cfsbbh=&fbbj=0&sucessMsg=&hjje=0&proMessage=&caVO.str_signature=&caVO.str_certificate=&nsrQrtjBz=0&txlJyCount=0&qzlJyCount=0&ymKj_Info=&cqSb=0";
            Byte[] postBuffer = Encoding.UTF8.GetBytes(postData);
           
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
                "Cookie:" + cookie
                ;
            //Cookie: _gscu_1112616140=52985877gk6s5596; JSID_WSBS=WhRjQQrSxWV0t1qv79n7hCBntrH1hq0yQ8q8nPMJY15kT5X21sw2!1516671385; Secure; _gscu_1161164261=41071794gwlnkd14
            // MessageBox.Show(postData);
            //MessageBox.Show(additionalHeaders);
            string url = "https://ca.jsds.gov.cn/wb029_WByhssbAction.do";
            this.webBrowser.Navigate(url, null, postBuffer, additionalHeaders);
        }

        /*个人所得税 普通算法 上传测试 未通过*/
        private void submit_grsds(string cookie)
        {
            string postData =
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"tbrq\"\n" +

              "2016 - 04 - 01\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"nsrsbh\"\n" +

              "320104302723175\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"swglm\"\n" +

              "320100100396501\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"nsrmc\"\n" +

              "南京小怪兽财务信息咨询有限公司\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"ssqq\"\n" +

              "2016 - 03 - 01\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"ssqz\"\n" +

              "2016 - 03 - 31\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"zclx\"\n" +

              "其他有限责任公司\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"fddbr\"\n" +

              "王孜豫\n" +
              "-----------------------------7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"dh\"\n" +

              "13776601441\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"yb\"\n" +

              "210000\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"file\"; filename = \"\"\n" +
              "Content - Type: application / octet - stream\n" +


                "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"file1\"; filename = \"C:\\Users\\wack\\Desktop\\鏂板缓鏂囦欢澶筡灏忔€吔\\灏忔€吔2016骞?鏈?dat\n" +
              "Content - Type: application / octet - stream\n" +

              "C: \\Users\\wack\\Desktop\\新建文件夹\\个人所得税明细申报客户端软件（适用新税法）\\templates\\个人所得税申报_A_普通算法明细数据.htm\n" +
              "7.0\n" +
              "320100100396501\n" +
              "南京小怪兽财务信息咨询有限公司\n" +
              "S\n" +
              "王孜豫,06,320106198110073214,156,0,1,,,,,010001,2000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,0.00,0.030,0.00,0.00,0.00,0.00,0.00,0.00,&& 0,,\n" +
              "张雪婷,06,320121199401192123,156,0,1,,,南京市鼓楼区中环国际广场4726,南京小怪兽财务信息咨询有限公司,040000,800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,800.00,0.00,0.00,0.200,0.00,0.00,0.00,0.00,0.00,0.00,&& 0,,\n" +
              "苗婷,06,320107199503303421,156,0,1,,,南京市鼓楼区中环国际广场4726,南京小怪兽财务信息咨询有限公司,040000,800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,800.00,0.00,0.00,0.200,0.00,0.00,0.00,0.00,0.00,0.00,&& 0,,\n" +
              "6ac665fbf3b563b6efcfbcd70e1cb730\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"handleCode\"\n" +

              "upload\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"bb\"\n" +

              "2\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"errorMessage\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"filename\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"bj\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"handleDesc\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"sbqx\"\n" +

              "2016 - 04 - 20\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"path\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"pzxh\"\n" +

              "2EDDC2FC3F9191BEE053C0A8661591BE\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"khyh\"\n" +

              "涓浗閾惰鑲′唤鏈夐檺鍏徃鍗椾含鍩庝腑鏀\n" +
              "-----------------------------7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"yhzh\"\n" +

              "522266790983\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"sbje\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"cfsbbh\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"sucessMsg\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"caVO.str_signature\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"caVO.str_certificate\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"nsrQrtjBz\"\n" +

              "0\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"txlJyCount\"\n" +

              "0\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"qzlJyCount\"\n" +

              "0\n" +
              "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"ymKj_Info\"\n" +


                  "---------------------------- - 7e01571c110d1a\n" +
              "Content - Disposition: form - data; name = \"cqSb\"\n" +

              "0\n" +
              "---------------------------- - 7e01571c110d1a--\n"
              ;
            Byte[] postBuffer = Encoding.UTF8.GetBytes(postData);
            //MessageBox.Show(postData);
            String additionalHeaders =
               "Accept: application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, */*\n" +
               "Referer:Referer: https://ca.jsds.gov.cn/wb_DkdjptUpLoadAction.do?SSQS=2016-03-01&SSQZ=2016-03-31&SBQX=2016-04-20&SWGLM=320100100396501&ksbsbqxrdm=M01_15\n" +
               "Accept-Encoding:gzip, deflate\n" +
               "Accept-Language: zh-cn\n" +
               "x-prototype-version: 1.6.0\n" +
               "x-requested-with: XMLHttpRequest\n" +
               "Content-Type: multipart/form-data; boundary=---------------------------7e01571c110d1a\n" +
               "Accept-Encoding: gzip, deflate\n" +
               "User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)\n" +
               "Host: ca.jsds.gov.cn\n" +
               "Content-Length:" + postBuffer.Length +
               "\nConnection: Keep-Alive\n" +
               "Cache-Control: no-cache\n" +
               "Cookie:" + cookie
               ;

            string url = "https://ca.jsds.gov.cn/wb_DkdjptUpLoadAction.do";
            webBrowser.Navigate(url, null, postBuffer, additionalHeaders);       
        }
        

        /*个人所得税 普通算法 POST测试 （上传文件） 未通过*/
        public void post_grsds(string cookie)
        {
            string postData = "-----------------------------7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"tbrq\"\n\n" +
                "2016 - 04 - 01\n---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"nsrsbh\"\n\n" +
                "320104302723175\n---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"swglm\"\n\n" +
                "320100100396501\n---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"nsrmc\"\n\n" +
                "南京小怪兽财务信息咨询有限公司\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"ssqq\"\n\n" +
                "2016 - 03 - 01\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"ssqz\"\n\n" +
                "2016 - 03 - 31\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"zclx\"\n\n" +
                "其他有限责任公司\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"fddbr\"\n\n" +
                "王孜豫\n" +
                "-----------------------------7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"dh\"\n\n" +
                "13776601441\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"yb\"\n\n" +
                "210000\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"file\"; filename = \"\"\n" +
                "Content - Type: application / octet - stream\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"file1\"; filename = \"C:\\Users\\wack\\Desktop\\鏂板缓鏂囦欢澶筡灏忔€吔\\灏忔€吔2016骞?鏈?dat\"\n" +
                "Content - Type: application / octet - stream\n" +

                @"C: \Users\wack\Desktop\新建文件夹\个人所得税明细申报客户端软件（适用新税法）\templates\个人所得税申报_A_普通算法明细数据.htm
                7.0
                320100100396501
                南京小怪兽财务信息咨询有限公司
                S
                王孜豫,06,320106198110073214,156,0,1,,,,,010001,2000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,0.00,0.030,0.00,0.00,0.00,0.00,0.00,0.00,&& 0,,
                张雪婷,06,320121199401192123,156,0,1,,,南京市鼓楼区中环国际广场4726,南京小怪兽财务信息咨询有限公司,040000,800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,800.00,0.00,0.00,0.200,0.00,0.00,0.00,0.00,0.00,0.00,&& 0,,
                苗婷,06,320107199503303421,156,0,1,,,南京市鼓楼区中环国际广场4726,南京小怪兽财务信息咨询有限公司,040000,800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,800.00,0.00,0.00,0.200,0.00,0.00,0.00,0.00,0.00,0.00,&& 0,,
                6ac665fbf3b563b6efcfbcd70e1cb730
                ---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"handleCode\"\n" +
                "upload\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"bb\"\n" +
                "2\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"errorMessage\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"filename\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"bj\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"handleDesc\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"sbqx\"\n" +
                "2016 - 04 - 20\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"path\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"pzxh\"\n" +
                "2F121B98B88DA07AE053C0A86615A07A\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"khyh\"\n" +
                "涓浗閾惰鑲′唤鏈夐檺鍏徃鍗椾含鍩庝腑鏀\n" +
                "-----------------------------7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"yhzh\"\n" +
                "522266790983\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"sbje\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"cfsbbh\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"sucessMsg\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"caVO.str_signature\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"caVO.str_certificate\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"nsrQrtjBz\"\n" +
                "0\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"txlJyCount\"\n" +
                "0\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"qzlJyCount\"\n" +
                "0\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"ymKj_Info\"\n" +
                "---------------------------- - 7e0147213067c\n" +
                "Content - Disposition: form - data; name = \"cqSb\"\n" +
                "0\n" +
                "---------------------------- - 7e0147213067c--";
            Byte[] postBuffer = Encoding.UTF8.GetBytes(postData);
            MessageBox.Show(postData);
            String additionalHeaders =
               "Accept: application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, */*\n" +
               "Accept-Encoding:gzip, deflate\n" +
               "Accept-Language: zh-cn\n" +
               "x-prototype-version: 1.6.0\n" +
               "Referer:https://ca.jsds.gov.cn/wb_DkdjptUpLoadAction.do?SSQS=2016-03-01&SSQZ=2016-03-31&SBQX=2016-04-20&SWGLM=320100100396501&ksbsbqxrdm=M01_15\n" +
               "x-requested-with: XMLHttpRequest\n" +
               "Content-Type: multipart/form-data; boundary=---------------------------7e0147213067c\n" +
               "Accept-Encoding: gzip, deflate\n" +
               "User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)\n" +
               "Host: ca.jsds.gov.cn\n" +
               "Content-Length:" + postBuffer.Length +
               "\nConnection: Keep-Alive\n" +
               "Cache-Control: no-cache\n" +
               "Cookie:" + cookie
               ;

            string url = "https://ca.jsds.gov.cn//wb_DkdjptUpLoadAction.do";
            this.webBrowser.Navigate(url, null, postBuffer, additionalHeaders);
        }


        //点击个税 按钮
        private void button_grsds_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://ca.jsds.gov.cn/wb_DkdjptUpLoadAction.do?SSQS=2016-03-01&SSQZ=2016-03-31&SBQX=2016-04-20&SWGLM=320100100396501&ksbsbqxrdm=M01_15");
        }

        //个税 点击浏览
        private void button_browse_Click(object sender, EventArgs e)
        {
            //webBrowser.Document.GetElementById("file1").SetAttribute("value", @"C:\Users\wack\Desktop\小怪兽2016年1月.dat");
            if (webBrowser.Document.GetElementById("file1") != null)
                webBrowser.Document.GetElementById("file1").InvokeMember("click");
            else
                MessageBox.Show("error!");
        }

        //个税 点击提交
        private void button_sbmt_Click(object sender, EventArgs e)
        {
            if (webBrowser.Document.GetElementById("submitBtn-btnInnerEl")!=null)
                webBrowser.Document.GetElementById("submitBtn-btnInnerEl").InvokeMember("click");
            else
                MessageBox.Show("error!");
        }

        //个税 点击上传
        private void button_upld_Click(object sender, EventArgs e)
        {
            if(webBrowser.Document.GetElementById("UploadBtn-btnInnerEl")!=null)
                webBrowser.Document.GetElementById("UploadBtn-btnInnerEl").InvokeMember("click");
            else
                MessageBox.Show("error!");
        }

        //关闭窗口
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //回地税主页
        private void button_home_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://ca.jsds.gov.cn/sbLogin.do");
        }

        //地税浏览器 显示URL
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox_url.Text = this.webBrowser.Url.ToString();   
        }


        private void webBrowser_gs_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(webBrowserGS.Document.Url.ToString() == "https://221.226.83.19:7001/newtax/ShowInform.do")
            {
                webBrowserGS.Visible = false;
                MessageBox.Show("登陆成功！");
                
            }

            if (webBrowserGS.Document.Url.ToString() == "https://221.226.83.19:7001/newtax/static/login.jsp?login_error=2")
            {
                webBrowserGS.Visible = false;
                button1.Visible = true;
                MessageBox.Show("验证码错误，请重新登陆！");
            }

            if (webBrowserGS.Document.Url.ToString() == "https://221.226.83.19:7001/newtax/static/j_spring_security_check")
            {
                webBrowserGS.Visible = false;
                button1.Visible = true;
                MessageBox.Show("登陆失败，请重新登陆！");
            }

        
            webBrowserGS.Document.Window.ScrollTo(700, 150);
            //textBox_url.Text = webBrowserGS.Url.ToString(); 
            //if (webBrowserGS.Document.GetElementById("right") != null)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    HtmlElementCollection hc = webBrowserGS.Document.GetElementById("right").All;

            //    if (webBrowserGS.Document.All["j_username"] != null)
            //    {
            //        HtmlElement user = webBrowserGS.Document.All["j_username"];
            //        user.SetAttribute("value", "nupt");
            //    }
            //    //遍历所有元素--此处改成你要的逻辑，
            //    int i = 1;
            //    foreach (HtmlElement he in hc)
            //    {
            //        //MessageBox.Show(he.OuterHtml);   
            //        //如果为要保留的标签名
            //        if(i == 2) {
            //            sb.Append(he.OuterHtml);
            //            break;
            //        }
            //        i++;
            //    }
            //    webBrowserGS.DocumentText = sb.ToString();//设置html代码
            //    textBox_HTML.Text = sb.ToString();

            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/static/main.jsp");
            webBrowserGS.ScrollBarsEnabled = false;
            webBrowserGS.Visible = true;
            button1.Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    //MessageBox.Show("主页标签");
                    break;
                case 1:
                    webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
                    //MessageBox.Show("地税标签");
                    break;
                case 2:
                    //webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/static/main.jsp");
                    webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/static/main.jsp");
                    webBrowserGS.ScrollBarsEnabled = false;
                    //MessageBox.Show("国税标签");
                    break;
                case 3:
                    //MessageBox.Show("HTML标签");
                    break;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            GsSecurityCheck();

        }
    }
}
