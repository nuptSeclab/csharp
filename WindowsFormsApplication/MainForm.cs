﻿using System;
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
        string path1 = "taxfile1.txt";
        string path2 = "taxfile2.txt";
        string path3 = "taxfile3.txt";
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string classname, string captionName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindowEx(IntPtr parent, IntPtr child, string classname, string captionName);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lParam);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, bool wParam, int lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public bool first;   //第一次打开
        int failCount = 0;  //登陆失败次数
        int file, upload, submit, upload_click, confirm;    //个税
        int yys_submit,yys_yes, yys_msg;
        int num=0,current_num=0;        //file2申报数量
        string[] poststr;   //file2申报地址
        string[] posttype;  //申报类型
        string dshomepage= "https://ca.jsds.gov.cn:2443/";  //地税主页
        int num1 = 0, current_num1 = 0;        //file3申报数量
        string[] poststr1;  //file3申报地址
        string ukey;
        string current_path;

        bool gs281 = false; //国税第一个
        bool gs690 = false; //国税第二个
        public MainForm()
        {
            Initialize();
            InitializeComponent();
        }
        
        private void Initialize()
        {
            current_path = System.Environment.CurrentDirectory;
            //webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
            //this.webBrowser.Navigate("https://www.jsds.gov.cn/index/sbLogin.do");
            //webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/static/main.jsp");
            //webBrowserGS.ScrollBarsEnabled = false;

            /*文件2初始化*/
            StreamReader sr = new StreamReader(path2, Encoding.Default);
            String line, l;string[] str; string[]firststr;
            line = sr.ReadLine();
            if (line.Length != 0)
            {
                l = line.ToString();
                str = l.Split(';');
                firststr = str[0].Split(',');
                num = Convert.ToInt32(firststr[1]);//报税的数量
                dshomepage = firststr[0];
                poststr = new string[num];
                posttype = new string[num];

                for (int i = 0; i < num; i++)
                {
                    poststr[i] = str[i + 1].Split(',')[1];//需要零申报的地址
                    posttype[i] = str[i + 1].Split(',')[2];//零申报/上传
                }
            }
            else
            {
                MessageBox.Show("文件2为空！请先在网站进行参数配置！");
            }
            sr.Close();
            /*文件3初始化*/
            sr = new StreamReader(path3, Encoding.Default);
            line = sr.ReadLine();
            if (line.Length != 0)
            {
                l = line.ToString();
                string[] str1 = l.Split(';');
                string[] firststr1 = str1[0].Split(',');
                num1 = Convert.ToInt32(firststr1[1]);//报税的数量
                poststr1 = new string[num1];
                for (int i = 0; i < num1; i++)
                {
                    poststr1[i] = str1[i + 1].Split(',')[1];//需要零申报的地址
                                                            //MessageBox.Show(str1[i + 1]);
                }
            }
            else
            {
                MessageBox.Show("文件3为空！请先在网站进行参数配置！");
            }
            sr.Close();
            //获取文件1的ukey

            sr = new StreamReader(path1, Encoding.Default);
            line = sr.ReadLine();
            l = line.ToString();
            string[] str3 = l.Split(',');
            ukey = str3[4];
            sr.Close();
            //MessageBox.Show(ukey);



        }

        //timer1 用于数字登陆输入密码
        private void timer1_Tick(object sender, EventArgs e)
        {


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
                    StringBuilder s = new StringBuilder(ukey);
                    SendMessage(edit, 0xC, IntPtr.Zero, s);
                    SendKeys.SendWait("{Enter}");
                    SendKeys.Flush();
                    //    this.timer1.Enabled = false;    //关闭定时器
                    //MessageBox.Show("timer1 stop");
                }
            }
            mwh1 = FindWindow(null, "脚本错误");
            if (mwh1 != IntPtr.Zero)
            {

                //MessageBox.Show("1");
                SendKeys.SendWait("{Enter}");
                //SendKeys.SendWait("{Space}");
                SendKeys.Flush();

            }
           
            try {
                if (webBrowser.Url.ToString().Equals("https://ca.jsds.gov.cn/sbLogin.do"))
                {
                    //   MessageBox.Show(current_num.ToString());
                    if (current_num < num) //申报file2
                    {
                        if (posttype[current_num] == "0")  //零申报
                        {
                            try
                            {
                                this.webBrowser.Navigate(poststr[current_num]);
                            }
                            catch (Exception ex)
                            {
                                //   MessageBox.Show(ex.ToString());
                                return;
                            }
                            yys_submit = 0; yys_yes = 0; yys_msg = 0;
                            timer5.Enabled = true;
                        }
                        else                           //
                        {

                        }
                    }
                    else if (current_num1 < num1)  //申报file3
                    {
                        try
                        {
                            webBrowser.Navigate(poststr1[current_num1]);                           
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                            return;
                        }
                        file = 0; upload = 0; submit = 0; upload_click = 0; confirm = 0;
                        timer4.Enabled = true;
                        timer2.Enabled = true;
                    }
                    else
                    {
                        timer1.Enabled = false;
                        MessageBox.Show("已完成报税，建议用户自行检查报税结果");
                       
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

            //到主页关闭定时器1
            //if (webbrowser.document.url.tostring() != "http://ca.jsds.gov.cn/index/calogin.html" && webbrowser.document.url.tostring() != "http://www.jsds.gov.cn/index/calogin.html#")
            //{
            //messagebox.show("timer1 disable");
            //timer1.enabled = false;
            //}
            

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
            
            if (url.Equals("https://ca.jsds.gov.cn:2443/"))
            { 
                ClickNextStep();
            }
            if(url.StartsWith("http://www.jsds.gov.cn/index/caLogin.jsp"))
            {              
                ClickLogin();    //登陆主页 点击按钮    
            }
            if (url.Equals("https://ca.jsds.gov.cn/sbLogin.do"))
            {
                //Thread.Sleep(1000);
            }
            FailCheck(url);     //提交失败等情况 返回主页了
    
        }

        //选择上传的文件

        private void ClickNextStep()
        {
            //点击按钮登陆主页
            HtmlDocument doc = webBrowser.Document;   //把当前的webBrowser1显示的文档实例
            HtmlElementCollection elemColl = doc.GetElementsByTagName("input");
            foreach (HtmlElement elem in elemColl)
            {
                string elemName = elem.GetAttribute("name");    //按钮
                if (elemName.Equals("sign"))
                {
                    //find!
                    elem.InvokeMember("click"); //点击登陆                                                
                    break;
                }
            }
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
            mwh1 = FindWindow(null, "安全警告");
            if (mwh1 != IntPtr.Zero)
            {
                IntPtr Button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "是(&Y)");
                if (Button != IntPtr.Zero)
                {
                    SendMessage(Button, 0xF5, IntPtr.Zero, null);
                }
            }
        }

        //地税主页 点击登陆按钮 开timer1
        private void ClickLogin()
        {

                //点击按钮登陆主页
                HtmlDocument doc = webBrowser.Document;   //把当前的webBrowser1显示的文档实例
                HtmlElementCollection elemColl = doc.GetElementsByTagName("a");
                foreach (HtmlElement elem in elemColl)
                {
                    string elemName = elem.GetAttribute("className");    //按钮
                    if (elemName.Equals("link-login"))
                    {
                        //find!
                        elem.InvokeMember("click"); //点击登陆
                        break;
                    }
                }
        }

        //地税登陆失败检测
        private void LoginCheck()
        {
            string url = webBrowser.Url.ToString();


            if (url.Equals("http://www.jsds.gov.cn/index/portal/index.html")|| url.Equals("http://www.jsds.gov.cn/indexAction.do"))
                this.webBrowser.Navigate("https://ca.jsds.gov.cn:2443/");
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
        
        //timer2 浏览文件
        private void timer2_Tick(object sender, EventArgs e)
        {
            IntPtr mwh1 = IntPtr.Zero;
            mwh1 = FindWindow(null, "选择要加载的文件");
            IntPtr ComboBoxEx32 = FindWindowEx(mwh1, IntPtr.Zero, "ComboBoxEx32", "");
            if (ComboBoxEx32 != IntPtr.Zero)
            {
                IntPtr ComboBox = FindWindowEx(ComboBoxEx32, IntPtr.Zero, "ComboBox", "");
                if(ComboBox != IntPtr.Zero)
                {
                    IntPtr Edit = FindWindowEx(ComboBox, IntPtr.Zero, "Edit", "");
                    if(Edit != IntPtr.Zero)
                    {
                        StringBuilder s = new StringBuilder(current_path + '\\' + current_num1+".dat");
                        SendMessage(Edit, 0xC, IntPtr.Zero, s);
                        IntPtr button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "打开(&O)");
                        if(button != IntPtr.Zero)
                        {
                            SendMessage(button, 0xF5, IntPtr.Zero, null);
                            timer2.Enabled = false;
                            file = 1;
                        }

                    }
                } 
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


        //点击个税 按钮
        private void button_grsds_Click(object sender, EventArgs e)
        {

            StreamReader sr = new StreamReader(path3, Encoding.Default);
            String line;
            line = sr.ReadLine();
            string l = line.ToString();
            string[] str = l.Split(';');

            string[] firststr = str[0].Split(',');
            int num = Convert.ToInt32(firststr[1]);//报税的数量

            string[] poststr = new string[num];
            string[] datstr = new string[num];

            for (int i = 0; i < num; i++)
            {
                poststr[i] = str[i + 1].Split(',')[1];//需要零申报的地址
            }



            file = 0;
            upload = 0;
            submit = 0;
            upload_click = 0;
            confirm = 0;
            timer4.Enabled = true;
            timer2.Enabled = true;
            webBrowser.Navigate("https://ca.jsds.gov.cn/wb_DkdjptUpLoadAction.do?SSQS=2016-04-01&SSQZ=2016-04-30&SBQX=2016-05-16&SWGLM=320100100396501&ksbsbqxrdm=M01_15");
            //       http://www.jsds.gov.cn/wb_DkdjptUpLoadAction.do?SSQS=2016-04-01&SSQZ=2016-04-30&SBQX=2016-05-16&SWGLM=320100100396501&ksbsbqxrdm=M01_15
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
            webBrowser.Navigate("http://www.jsds.gov.cn/sbMain.do");
        }

        //地税浏览器 显示URL
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox_url.Text = this.webBrowser.Url.ToString();   
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            string url = this.textBox_url.Text;
            this.webBrowserGS.Navigate(url);
        }

        private void webBrowser_gs_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox_url.Text = this.webBrowserGS.Url.ToString();
            if (webBrowserGS.Document.Url.ToString() == "https://221.226.83.19:7001/newtax/ShowInform.do")
            {
                //webBrowserGS.Visible = false;
                //MessageBox.Show("登陆成功！");
                //webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/getzzsnsrinfojs");
                webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/nssb_GetSssq.do");

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

            if(webBrowserGS.Document.Url.ToString() ==  "https://221.226.83.19:7001/newtax/static/main.jsp")
                webBrowserGS.Document.Window.ScrollTo(700, 150);

            if (webBrowserGS.Document.Url.ToString().Equals("https://221.226.83.19:7001/newtax/nssb_GetSssq.do"))
            {//点击创建
                HtmlElementCollection input = this.webBrowserGS.Document.GetElementsByTagName("input");
                for (int ii = 0; ii < input.Count; ii++)
                {
                    if (input[ii].GetAttribute("type").ToLower().Equals("submit"))
                    {
                        input[ii].InvokeMember("click");
                    }
                }
            }

            if (webBrowserGS.Document.Url.ToString().Equals("https://221.226.83.19:7001/newtax/nssb_Access.do"))
            {//点击创建
                if(!gs281)
                {
                    HtmlElementCollection link = this.webBrowserGS.Document.GetElementsByTagName("a");
                    for (int ii = 0; ii < link.Count; ii++)
                    {
                        //点击2005版增值税纳税申报表(小规模纳税人适用)
                        if (link[ii].GetAttribute("href").StartsWith("https://221.226.83.19:7001/newtax/nssb_report281_access.do"))
                        {
                            link[ii].InvokeMember("click");
                        }
                    
                    }
                }else if (!gs690)
                {
                    HtmlElementCollection link = this.webBrowserGS.Document.GetElementsByTagName("a");
                    for (int ii = 0; ii < link.Count; ii++)
                    {
                        //点击2005版增值税纳税申报表(小规模纳税人适用)
                        if (link[ii].GetAttribute("href").StartsWith("https://221.226.83.19:7001/newtax/nssb_report690_access.do"))
                        {
                            link[ii].InvokeMember("click");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("国税申报完成，请用户自行检查");
                }
            }
            if(webBrowserGS.Document.Url.ToString().StartsWith("https://221.226.83.19:7001/newtax/nssb_report281_access.do"))
            {//保存报表281
             //	2005版增值税纳税申报表(小规模纳税人适用)
                HtmlElementCollection link = this.webBrowserGS.Document.GetElementsByTagName("a");
                for (int ii = 0; ii < link.Count; ii++)
                {
                    //MessageBox.Show(link[ii].GetAttribute("href").ToLower());
                    //点击2005版增值税纳税申报表(小规模纳税人适用)
                    if (link[ii].GetAttribute("href").Equals("javascript:checkReoprt281()"))
                    {
                        link[ii].InvokeMember("click");
                        gs281 = true;
                        webBrowserGS.Navigate( "https://221.226.83.19:7001/newtax/nssb_Access.do");
                    }

                }

            }
            if (webBrowserGS.Document.Url.ToString().StartsWith("https://221.226.83.19:7001/newtax/nssb_report690_access.do"))
            {//保存报表690
             //	2005版增值税纳税申报表(小规模纳税人适用)
                HtmlElementCollection link = this.webBrowserGS.Document.GetElementsByTagName("a");
                for (int ii = 0; ii < link.Count; ii++)
                {
                    //MessageBox.Show(link[ii].GetAttribute("href").ToLower());
                    //点击2005版增值税纳税申报表(小规模纳税人适用)
                    if (link[ii].GetAttribute("href").Equals("javascript:getconfirm('此操作将清除此报表所有现有数据！请确认','/newtax/nssb_report690_clear.do')"))
                    {
                        link[ii].InvokeMember("click");
                        gs690 = true;
                        webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/nssb_Access.do");
                    }

                }

            }
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

        //营业税、城市维护建设税、教育费附加、文化事业建设费零申报
        private void button2_Click_1(object sender, EventArgs e)
        {
            //string postData = "swglm=320100100396501&yyssbVO.str_sfssqqsrq=2016-04-01&yyssbVO.str_sfssqzzrq=2016-04-30&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&HH=1&HH=2&HH=3&HH=4&HH=5&HH=6&HH=7&HH=8&HH=9&HH=9&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&YSSR_JE=0.00&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSYYE_JE=0.00&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&SL=&SL=&SL=&SL=&SL=&SL=&SL=&SL=&SL=&BQSK_JE=0.00&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYINGJSE_JE=0.00&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&YSSR_JE_HJ=0.00&YSJCXMJE_JE_HJ=&YSYYE_JE_HJ=0.00&BQSK_JE_HJ=0.00&JMSE_JE_HJ=&BQYIJSE_JE_HJ=&BQYINGJSE_JE_HJ=0.00&CS_HH=10&CS_HH=12&CS_HH=13&CS_HH=14&CS_ZSXMDM=10&CS_ZSXMDM=10&CS_ZSXMDM=10&CS_ZSXMDM=10&CS_ZSPMDM=0100&CS_ZSPMDM=0100&CS_ZSPMDM=0100&CS_ZSPMDM=0100&CS_YSYYE_JE=0.00&CS_YSYYE_JE=&CS_YSYYE_JE=&CS_YSYYE_JE=&CS_SL=0.07&CS_SL=0.07&CS_SL=0.07&CS_SL=0.07&CS_BQSK_JE=0.00&CS_BQSK_JE=0.00&CS_BQSK_JE=0.00&CS_BQSK_JE=0.00&CS_JMSE_JE=&CS_JMSE_JE=&CS_JMSE_JE=&CS_JMSE_JE=&CS_BQYIJSE_JE=&CS_BQYIJSE_JE=&CS_BQYIJSE_JE=&CS_BQYIJSE_JE=&CS_BQYINGJSE_JE=0.00&CS_BQYINGJSE_JE=0.00&CS_BQYINGJSE_JE=0.00&CS_BQYINGJSE_JE=0.00&CS_YSYYE_JE_HJ=0.00&CS_BQSK_JE_HJ=0.00&CS_JMSE_JE_HJ=&CS_BQYIJSE_JE_HJ=&CS_BQYINGJSE_JE_HJ=0.00&JYFJ_HH=17&JYFJ_ZSXMDM=61&JYFJ_ZSPMDM=0100&JYFJ_YSYYE_JE=0.00&JYFJ_SL=0.0300&JYFJ_BQSK_JE=0.00&JYFJ_JMSE_JE=&JYFJ_BQYIJSE_JE=&JYFJ_BQYINGJSE_JE=0.00&DFJY_HH=18&DFJY_ZSXMDM=63&DFJY_ZSPMDM=0100&DFJY_YSYYE_JE=0.00&DFJY_SL=0.0200&DFJY_BQSK_JE=0.00&DFJY_JMSE_JE=&DFJY_BQYIJSE_JE=&DFJY_BQYINGJSE_JE=0.00&WHSY_HH=19&WHSY_ZSXMDM=65&WHSY_ZSPMDM=0001&WHSY_YSYYE_JE=&WHSY_SL=0.0300&WHSY_BQSK_JE=0.00&WHSY_JMSE_JE=&WHSY_BQYIJSE_JE=&WHSY_BQYINGJSE_JE=0.00&YSSR_JE_ZJ=0.00&YSJCXMJE_JE_ZJ=&YSYYE_JE_ZJ=0.00&BQSK_JE_ZJ=0.00&JMSE_JE_ZJ=&BQYIJSE_JE_ZJ=&BQYINGJSE_JE_ZJ=0.00&bqysyye=0.00&bqysxse=&bbzt=null&tbrq=2016-05-05&bizData=&handleDesc=%E8%90%A5%E4%B8%9A%E7%A8%8E%E6%8F%90%E4%BA%A4&handleCode=submit&mrcjsl=0.07&returnvalue=&yuanpzxh=&whsyfbj=1&ljyye=&errorMessage=&sucessMsg=&cfsbbh=&xwyh_zqhjje=&xwyh_hjje=&xwyh_czlx=&xwyh_tsxx=&pzxh=3212DDEF0786E156E053C0A86615E156&zhuPzxh=&pzxhStrs=&bbsl2w=&proMessage=&hz3wzt=&ybtsje3whzje=&tempzt=&caVO.str_signature=HRXGIJahdS0VfeYduWsRbuEK38zfdf9DFw1urpRFdPcFyQDrhpyWgj4xq%2Fif6VsnEIVhTzPlzzgcSFGIzaLaHs2q2E5N6fsDdbatzzxLtJEmS6rajDGhK3wtqkyo9DCU%2B5D4ikvui9JLhji74%2Bp9FOblWizetpjH%2BGnWI7E03Ik%3D&caVO.str_certificate=MIIEZzCCA9CgAwIBAgIMGD%2B82LzGzd573WL9MA0GCSqGSIb3DQEBBQUAMIGOMQ0wCwYDVQQGHgQAQwBOMQ8wDQYDVQQIHgZsX4LPdwExDzANBgNVBAceBlNXTqxeAjEvMC0GA1UECh4mbF%2BCz3cBdTVbUFVGUqGLwU5mi6SLwU4tX8NnCZZQjSNO%2B1FsU%2FgxETAPBgNVBAseCABKAFMAQwBBMRcwFQYDVQQDHg4ASgBTAEMAQQBfAEMAQTAeFw0xNTA0MDYxNjAwMDBaFw0xNzA0MDYxNjAwMDBaMIIBTjESMBAGA1UEGgwJ56em5reu5Yy6MRgwFgYDVQQPDA8zMjAxMDQwMDAyMjIzMzcxEjAQBgNVBAEMCTMwMjcyMzE3NTELMAkGBFUEiFcMATIxETAPBgNVBC0MCGVudENlcnQyMRgwFgYDVQQfDA8zMjAxMDQzMDI3MjMxNzUxCzAJBgNVBAYTAkNOMRIwEAYDVQQIDAnmsZ%2Foi4%2FnnIExEjAQBgNVBAcMCeWNl%2BS6rOW4gjE2MDQGA1UECgwt5Y2X5Lqs5bCP5oCq5YW96LSi5Yqh5L%2Bh5oGv5ZKo6K%2Bi5pyJ6ZmQ5YWs5Y%2B4MQwwCgYDVQQLDAMwMDAxGDAWBgNVBCoMDzMyMDEwMDEwMDM5NjUwMTE7MDkGA1UEAwwy5Y2X5Lqs5bCP5oCq5YW96LSi5Yqh5L%2Bh5oGv5ZKo6K%2Bi5pyJ6ZmQ5YWs5Y%2B4KDAwMCkwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBALjh%2BC4Ojtug5vvwlqrNrkWkPqd%2BRmgmALSRRFuUWLrxRbThQNwHjOnR9n71taSE0NNOYP9ktrue1THErA5mrQPXgJcfFQPJehw8SCpEvzRJvfuSbpzs87BJjDRuhX%2FCCmVoD8QPV2goF1th9NL0YGx1cv2vm95%2Bxqu1hXhBQyjVAgMBAAGjggEFMIIBATAJBgNVHRMEAjAAMAsGA1UdDwQEAwIGwDAdBgNVHSUEFjAUBggrBgEFBQcDAgYIKwYBBQUHAwQwHwYDVR0jBBgwFoAUVsDIEVRVNgZKfe0mUOiIvbejegkwRwYIKwYBBQUHAQEEOzA5MDcGCCsGAQUFBzAChitodHRwOi8vMTAuMTA4LjUuMjo4ODgwL2Rvd25sb2FkL0pTQ0FfQ0EuY2VyMD8GA1UdHwQ4MDYwNKAyoDCGLmh0dHA6Ly93d3cuanNjYS5jb20uY24vY3JsZG93bmxvYWQvSlNDQV9DQS5jcmwwHQYDVR0OBBYEFFR6TzCNMBFvfJrRkgJ33jff6dlEMA0GCSqGSIb3DQEBBQUAA4GBACszlPZYbLBIVBMLoWHd6Y8V5XlfhtLoA2I8q%2BeZ4BiiqR4gx22y2Ou6cwdYgPi8ctyy7bd1pfRagbUwhWEf8sEZnHsHXo1z%2BsNYiDNzuunWC%2FH0ZdNSp5dXOKQKeNnfMZOERFzhARHOlu8E0Sj6eFVn6x3b9bEXBMIQx6XB6Gxr&nsrQrtjBz=0&txlJyCount=0&qzlJyCount=0&ymKj_Info=&cqSb=0&jzybj=&fdcbj=&sbbjqx=2016-05-16&sbqx=2016-05-16&sbqxrdm=&jcxmzcbz=&gljgdm=23201031300";
            string postData = "swglm=320100100396501&yyssbVO.str_sfssqqsrq=2016-04-01&yyssbVO.str_sfssqzzrq=2016-04-30&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&ZSXMDM=02&HH=1&HH=2&HH=3&HH=4&HH=5&HH=6&HH=7&HH=8&HH=9&HH=9&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLDM=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDLMC=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMDM=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&ZSPMMC=&YSSR_JE=0.00&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSSR_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSJCXMJE_JE=&YSYYE_JE=0.00&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&YSYYE_JE=&SL=&SL=&SL=&SL=&SL=&SL=&SL=&SL=&SL=&BQSK_JE=0.00&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&BQSK_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&JMSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYIJSE_JE=&BQYINGJSE_JE=0.00&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&BQYINGJSE_JE=&YSSR_JE_HJ=0.00&YSJCXMJE_JE_HJ=&YSYYE_JE_HJ=0.00&BQSK_JE_HJ=0.00&JMSE_JE_HJ=&BQYIJSE_JE_HJ=&BQYINGJSE_JE_HJ=0.00&CS_HH=10&CS_HH=12&CS_HH=13&CS_HH=14&CS_ZSXMDM=10&CS_ZSXMDM=10&CS_ZSXMDM=10&CS_ZSXMDM=10&CS_ZSPMDM=0100&CS_ZSPMDM=0100&CS_ZSPMDM=0100&CS_ZSPMDM=0100&CS_YSYYE_JE=0.00&CS_YSYYE_JE=&CS_YSYYE_JE=&CS_YSYYE_JE=&CS_SL=0.07&CS_SL=0.07&CS_SL=0.07&CS_SL=0.07&CS_BQSK_JE=0.00&CS_BQSK_JE=0.00&CS_BQSK_JE=0.00&CS_BQSK_JE=0.00&CS_JMSE_JE=&CS_JMSE_JE=&CS_JMSE_JE=&CS_JMSE_JE=&CS_BQYIJSE_JE=&CS_BQYIJSE_JE=&CS_BQYIJSE_JE=&CS_BQYIJSE_JE=&CS_BQYINGJSE_JE=0.00&CS_BQYINGJSE_JE=0.00&CS_BQYINGJSE_JE=0.00&CS_BQYINGJSE_JE=0.00&CS_YSYYE_JE_HJ=0.00&CS_BQSK_JE_HJ=0.00&CS_JMSE_JE_HJ=&CS_BQYIJSE_JE_HJ=&CS_BQYINGJSE_JE_HJ=0.00&JYFJ_HH=17&JYFJ_ZSXMDM=61&JYFJ_ZSPMDM=0100&JYFJ_YSYYE_JE=0.00&JYFJ_SL=0.0300&JYFJ_BQSK_JE=0.00&JYFJ_JMSE_JE=&JYFJ_BQYIJSE_JE=&JYFJ_BQYINGJSE_JE=0.00&DFJY_HH=18&DFJY_ZSXMDM=63&DFJY_ZSPMDM=0100&DFJY_YSYYE_JE=0.00&DFJY_SL=0.0200&DFJY_BQSK_JE=0.00&DFJY_JMSE_JE=&DFJY_BQYIJSE_JE=&DFJY_BQYINGJSE_JE=0.00&WHSY_HH=19&WHSY_ZSXMDM=65&WHSY_ZSPMDM=0001&WHSY_YSYYE_JE=&WHSY_SL=0.0300&WHSY_BQSK_JE=0.00&WHSY_JMSE_JE=&WHSY_BQYIJSE_JE=&WHSY_BQYINGJSE_JE=0.00&YSSR_JE_ZJ=0.00&YSJCXMJE_JE_ZJ=&YSYYE_JE_ZJ=0.00&BQSK_JE_ZJ=0.00&JMSE_JE_ZJ=&BQYIJSE_JE_ZJ=&BQYINGJSE_JE_ZJ=0.00&bqysyye=0.00&bqysxse=&bbzt=null&tbrq=2016-05-07&bizData=&handleDesc=%E8%90%A5%E4%B8%9A%E7%A8%8E%E6%8F%90%E4%BA%A4&handleCode=submit&mrcjsl=0.07&returnvalue=&yuanpzxh=&whsyfbj=1&ljyye=&errorMessage=&sucessMsg=&cfsbbh=&xwyh_zqhjje=&xwyh_hjje=&xwyh_czlx=&xwyh_tsxx=&pzxh=323D54DA50541222E053C0A866151222&zhuPzxh=&pzxhStrs=&bbsl2w=&proMessage=&hz3wzt=&ybtsje3whzje=&tempzt=&caVO.str_signature=HRXGIJahdS0VfeYduWsRbuEK38zfdf9DFw1urpRFdPcFyQDrhpyWgj4xq%2Fif6VsnEIVhTzPlzzgcSFGIzaLaHs2q2E5N6fsDdbatzzxLtJEmS6rajDGhK3wtqkyo9DCU%2B5D4ikvui9JLhji74%2Bp9FOblWizetpjH%2BGnWI7E03Ik%3D&caVO.str_certificate=MIIEZzCCA9CgAwIBAgIMGD%2B82LzGzd573WL9MA0GCSqGSIb3DQEBBQUAMIGOMQ0wCwYDVQQGHgQAQwBOMQ8wDQYDVQQIHgZsX4LPdwExDzANBgNVBAceBlNXTqxeAjEvMC0GA1UECh4mbF%2BCz3cBdTVbUFVGUqGLwU5mi6SLwU4tX8NnCZZQjSNO%2B1FsU%2FgxETAPBgNVBAseCABKAFMAQwBBMRcwFQYDVQQDHg4ASgBTAEMAQQBfAEMAQTAeFw0xNTA0MDYxNjAwMDBaFw0xNzA0MDYxNjAwMDBaMIIBTjESMBAGA1UEGgwJ56em5reu5Yy6MRgwFgYDVQQPDA8zMjAxMDQwMDAyMjIzMzcxEjAQBgNVBAEMCTMwMjcyMzE3NTELMAkGBFUEiFcMATIxETAPBgNVBC0MCGVudENlcnQyMRgwFgYDVQQfDA8zMjAxMDQzMDI3MjMxNzUxCzAJBgNVBAYTAkNOMRIwEAYDVQQIDAnmsZ%2Foi4%2FnnIExEjAQBgNVBAcMCeWNl%2BS6rOW4gjE2MDQGA1UECgwt5Y2X5Lqs5bCP5oCq5YW96LSi5Yqh5L%2Bh5oGv5ZKo6K%2Bi5pyJ6ZmQ5YWs5Y%2B4MQwwCgYDVQQLDAMwMDAxGDAWBgNVBCoMDzMyMDEwMDEwMDM5NjUwMTE7MDkGA1UEAwwy5Y2X5Lqs5bCP5oCq5YW96LSi5Yqh5L%2Bh5oGv5ZKo6K%2Bi5pyJ6ZmQ5YWs5Y%2B4KDAwMCkwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBALjh%2BC4Ojtug5vvwlqrNrkWkPqd%2BRmgmALSRRFuUWLrxRbThQNwHjOnR9n71taSE0NNOYP9ktrue1THErA5mrQPXgJcfFQPJehw8SCpEvzRJvfuSbpzs87BJjDRuhX%2FCCmVoD8QPV2goF1th9NL0YGx1cv2vm95%2Bxqu1hXhBQyjVAgMBAAGjggEFMIIBATAJBgNVHRMEAjAAMAsGA1UdDwQEAwIGwDAdBgNVHSUEFjAUBggrBgEFBQcDAgYIKwYBBQUHAwQwHwYDVR0jBBgwFoAUVsDIEVRVNgZKfe0mUOiIvbejegkwRwYIKwYBBQUHAQEEOzA5MDcGCCsGAQUFBzAChitodHRwOi8vMTAuMTA4LjUuMjo4ODgwL2Rvd25sb2FkL0pTQ0FfQ0EuY2VyMD8GA1UdHwQ4MDYwNKAyoDCGLmh0dHA6Ly93d3cuanNjYS5jb20uY24vY3JsZG93bmxvYWQvSlNDQV9DQS5jcmwwHQYDVR0OBBYEFFR6TzCNMBFvfJrRkgJ33jff6dlEMA0GCSqGSIb3DQEBBQUAA4GBACszlPZYbLBIVBMLoWHd6Y8V5XlfhtLoA2I8q%2BeZ4BiiqR4gx22y2Ou6cwdYgPi8ctyy7bd1pfRagbUwhWEf8sEZnHsHXo1z%2BsNYiDNzuunWC%2FH0ZdNSp5dXOKQKeNnfMZOERFzhARHOlu8E0Sj6eFVn6x3b9bEXBMIQx6XB6Gxr&nsrQrtjBz=0&txlJyCount=0&qzlJyCount=0&ymKj_Info=&cqSb=0&jzybj=&fdcbj=&sbbjqx=2016-05-16&sbqx=2016-05-16&sbqxrdm=&jcxmzcbz=&gljgdm=23201031300";
            Byte[] postBuffer = Encoding.UTF8.GetBytes(postData);

            String additionalHeaders =
                 "x-requested-with: XMLHttpRequest\n" +
                "X-HttpWatch-RID: 70108-10215\n" +
                "Accept-Language: zh-CN\n" +
                "x-prototype-version: 1.6.0\n" +
                "Referer: https://ca.jsds.gov.cn/WB366yyssbAction.do?SSQS=2016-04-01&SSQZ=2016-04-30&SBQX=2016-05-16&SWGLM=320100100396501&ksbsbqxrdm=M01_15\n" +
                "Accept: text/javascript, text/html, application/xml, text/xml, */*\n" +
                "Content-Type: application/x-www-form-urlencoded; charset=UTF-8\n" +
                "Accept-Encoding: gzip, deflate\n" +
                "User-Agent: Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; GWX:QUALIFIED)\n" +
                "Host: ca.jsds.gov.cn\n" +
                "Content-Length:" + postBuffer.Length +   
                "\nConnection: Keep-Alive\n" +
                "Cache-Control: no-cache\n" +
                "Cookie:" + this.webBrowser.Document.Cookie
                ;
            //Cookie: _gscu_1112616140=52985877gk6s5596; JSID_WSBS=WhRjQQrSxWV0t1qv79n7hCBntrH1hq0yQ8q8nPMJY15kT5X21sw2!1516671385; Secure; _gscu_1161164261=41071794gwlnkd14
            // MessageBox.Show(postData);
            //MessageBox.Show(additionalHeaders);
            string url = "https://ca.jsds.gov.cn/WB366yyssbAction.do";
            this.webBrowser.Navigate(url, null, postBuffer, additionalHeaders);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            //读取文件2
            StreamReader sr = new StreamReader(path2, Encoding.Default);
            String line;
            line = sr.ReadLine();
            string l = line.ToString();
            string[] str = l.Split(';');

            string[] firststr = str[0].Split(',');
            int num = Convert.ToInt32(firststr[1]);//报税的数量

            string[] poststr = new string[num];

            for (int i = 0; i < num; i++)
            {
                poststr[i] = str[i + 1].Split(',')[1];//需要零申报的地址
            } 


            this.webBrowser.Navigate("https://ca.jsds.gov.cn/WB366yyssbAction.do?SSQS=2016-04-01&SSQZ=2016-04-30&SBQX=2016-05-16&SWGLM=320100100396501&ksbsbqxrdm=M01_15");
            yys_submit = 0; yys_yes = 0; yys_msg = 0;
            timer5.Enabled = true;
            
        }

        //营业税零申报
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (webBrowser.Url.ToString().StartsWith("https://ca.jsds.gov.cn/WB399cjjyssbAction.do"))
            {
                if (yys_msg == 0)
                {
                    IntPtr mwh1 = IntPtr.Zero;
                    mwh1 = FindWindow(null, "来自网页的消息");
                    if (mwh1 != IntPtr.Zero)
                    {
                        IntPtr Button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "确定");
                        if (Button != IntPtr.Zero)
                        {
                            SendMessage(Button, 0xF5, IntPtr.Zero, null);
                            yys_msg++;
                        }
                    }
                }
    
                if (yys_submit <= 2)
                {
                    HtmlDocument doc = webBrowser.Document;
                    HtmlElement yssr = doc.All["YSSR_JE"];   //把当前的webBrowser1显示的文档实例
                    if (yssr != null)
                    {
                        yssr.InnerText = "0";
                        yssr.InvokeMember("click");
                        HtmlElement cb = doc.All["yysfsyhbj"];   //把当前的webBrowser1显示的文档实例
                        if (cb != null)
                        {
                            cb.InvokeMember("click");
                            cb.InvokeMember("click");
                        }                       
                    }
                    if (webBrowser.Document.GetElementById("submitBtn-btnIconEl") != null)
                    {
                        webBrowser.Document.GetElementById("submitBtn-btnInnerEl").InvokeMember("click");
                        yys_submit++;
                        return;
                    }
                   
                }
                if (webBrowser.Document.GetElementById("button-1006-btnInnerEl") != null)
                {
                    webBrowser.Document.GetElementById("button-1006-btnInnerEl").InvokeMember("click");
                }
                if (yys_submit>=1 && yys_yes<=2)
                {
                    if (webBrowser.Document.GetElementById("button-1006-btnInnerEl") != null)
                    {
                        webBrowser.Document.GetElementById("button-1006-btnInnerEl").InvokeMember("click");
                        yys_yes++;
                    }
                }
                

                if(yys_yes>=2)  //申报完成
                {
                    current_num++;
                    Thread.Sleep(2000);
                    webBrowser.Navigate("https://ca.jsds.gov.cn/sbLogin.do");   //回主页
                    timer5.Enabled = false;
                }            
            }
            if (webBrowser.Document.GetElementById("button-1006-btnInnerEl") != null)
            {
                webBrowser.Document.GetElementById("button-1006-btnInnerEl").InvokeMember("click");
            }
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
                    //webBrowser.Navigate("http://www.jsds.gov.cn/index/caLogin.html");
                    //webBrowser.Navigate("https://ca.jsds.gov.cn:2443/");
                    //MessageBox.Show(dshomepage);
                    webBrowser.Navigate(dshomepage);
                    timer1.Enabled = true;
                    //MessageBox.Show("地税标签");
                    break;
                case 2:
                    //webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/static/main.jsp");
                    webBrowserGS.Navigate("https://221.226.83.19:7001/newtax/static/main.jsp");
                    webBrowserGS.ScrollBarsEnabled = false;
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    timer4.Enabled = false;
                    timer5.Enabled = false;
                    timer3.Enabled = true;
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
            IntPtr mwh1 = IntPtr.Zero;
            mwh1 = FindWindow(null, "来自网页的消息");
            if (mwh1 != IntPtr.Zero)
            {
                IntPtr Button = FindWindowEx(mwh1, IntPtr.Zero, "Button", "确定");
                if (Button != IntPtr.Zero)
                {
                    SendMessage(Button, 0xF5, IntPtr.Zero, null);
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (webBrowser.Url.ToString().StartsWith("https://ca.jsds.gov.cn/wb_DkdjptUpLoadAction"))  //个税页面
            {
                if (file==0)
                {
                    if (webBrowser.Document.GetElementById("file1") != null)
                    {
                        webBrowser.Document.GetElementById("file1").InvokeMember("click");
                    }
                }
                if (upload_click==0 &&file ==1)
                {
                    if (webBrowser.Document.GetElementById("UploadBtn-btnInnerEl") != null)
                    {
                        webBrowser.Document.GetElementById("UploadBtn-btnInnerEl").InvokeMember("click");
                        upload_click = 1;
                        return;
                    }
                }
                
                if (webBrowser.Document.GetElementById("button-1006-btnInnerEl") != null)
                {   //是
                    webBrowser.Document.GetElementById("button-1006-btnInnerEl").InvokeMember("click");
                    upload ++;
                    if (upload == 1)
                        return;
                }
                
                if (webBrowser.Document.GetElementById("button-1005-btnInnerEl") != null)
                {
                    webBrowser.Document.GetElementById("button-1005-btnInnerEl").InvokeMember("click");
                    confirm ++;
                    //MessageBox.Show("2");
                    if(confirm==1)
                        return;
                }
                if (upload >=1 && submit<2 && confirm >=2 && upload_click==1)
                {
                    if (webBrowser.Document.GetElementById("submitBtn-btnInnerEl") != null)
                    {
                        webBrowser.Document.GetElementById("submitBtn-btnInnerEl").InvokeMember("click");
                        submit++;
                        //MessageBox.Show("1");
                        Thread.Sleep(1000);
                        if (webBrowser.Document.GetElementById("button-1006-btnInnerEl") != null)
                        {
                            webBrowser.Document.GetElementById("button-1006-btnInnerEl").InvokeMember("click");
                        }
                        return;
                    }
                } 
                if (submit >= 2)
                {
                    current_num1++;
                    //Thread.Sleep(1000);
                    webBrowser.Navigate("https://ca.jsds.gov.cn/sbLogin.do");   //回主页
                    timer4.Enabled = false;
                    timer2.Enabled = false;
                }
                
            }
        }
    }
}
