using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class LoginForm : Form
    {
        string path1 = "E:\\taxfile1.txt";
        string path2 = "E:\\taxfile2.txt";
        //string path3 = "E:\\taxfile3.txt";
        public LoginForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            this.username.Text = "15150577554";
            this.password.Text = "DCRns123";
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            CookieContainer myCookieContainer = new CookieContainer();
            string strId = this.username.Text;
            string strPassword = this.password.Text;
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "loginName=" + strId;
            postData += ("&password=" + strPassword);
            byte[] data = encoding.GetBytes(postData);
            // Prepare web request 
            HttpWebRequest myRequest =
            (HttpWebRequest)WebRequest.Create("http://test2.58tax.com/loginCheck");
            myRequest.Method = "POST";
            myRequest.CookieContainer = myCookieContainer;
            myRequest.ContentType = "application/x-www-form-urlencoded"; myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data. 
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // Get response 
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

            if (myResponse.ResponseUri.ToString().StartsWith("http://test2.58tax.com/index"))
            {
                myCookieContainer.Add(myResponse.Cookies);
                DownloadFile1(this.username.Text,myCookieContainer);
                File1 f1 = ReadFile(path1);
                if (f1 == null)
                {
                    MessageBox.Show("读取文件错误！");
                    return;
                }
                DownloadFile2(f1, myCookieContainer);
                MainForm mf = new MainForm();
                mf.Show();
                Visible = false; //隐藏登陆窗口
            }
            else {
                MessageBox.Show("登录失败！");
                MainForm mf = new MainForm();
                mf.Show();
                Visible = false; //隐藏登陆窗口
            }
            
            
           // sw.Close();
            //Response.Write(content);
            //return retString;




            //if (username.Text=="admin" && password.Text=="admin")
            //{
            //    MainForm mf = new MainForm();
            //    mf.Show();
            //    Visible = false; //隐藏登陆窗口
            //}
            //else
            //{
            //    MessageBox.Show("failed");
            //}
            
        }

        private void DownloadFile2(File1 f1, CookieContainer cookie)
        {
            // 设置参数
            string file2 = f1.file2Url;
            HttpWebRequest request = WebRequest.Create(file2) as HttpWebRequest;
            //发送请求并获取相应回应数据
            request.CookieContainer = cookie;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(path2, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
        }

        private File1 ReadFile(string path1)
        {
            StreamReader sr = new StreamReader(path1, Encoding.Default);
            String line;
            line = sr.ReadLine();
            string l = line.ToString();
            File1 f1 = new File1();
            string []str = l.Split(',');
            
            if (str.Length != 8)
                return null;
            //MessageBox.Show(str[0]);
            f1.taxNumber = str[0];
            f1.repeatTax = Convert.ToInt32(str[1]);
            f1.loginTimes = Convert.ToInt32(str[2]);
            f1.submitTime = Convert.ToInt32(str[3]);
            f1.uKey = str[4];
            f1.sbType = Convert.ToInt32(str[5]);
            f1.loginUrl = str[6];
            f1.file2Url = str[7];
            return f1;
        }

        private void DownloadFile1(string uname,CookieContainer cookie)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create("http://test2.58tax.com/autoApply/tax_report_files?id="+uname+"&month=01&info=1") as HttpWebRequest;
            //发送请求并获取相应回应数据
            request.CookieContainer = cookie;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(path1, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            //return path;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            username.Text = null;
            password.Text = null;
        }

        private void username_Click(object sender, EventArgs e)
        {
            username.Text = null;
        }
        private void password_Click(object sender,EventArgs e)
        {
            password.Text = null;
        }
    }
}
