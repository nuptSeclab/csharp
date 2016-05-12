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
        string path1 = "taxfile1.txt";
        string path2 = "taxfile2.txt";
        string path3 = "taxfile3.txt";
        public LoginForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {

            this.username.Text = "15005175574";
            this.password.Text = "Wk12345";
         //   MainForm mf = new MainForm();
         //   mf.Show();
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
            (HttpWebRequest)WebRequest.Create("http://www.58tax.com/loginCheck");
            myRequest.Method = "POST";
            myRequest.CookieContainer = myCookieContainer;
            myRequest.ContentType = "application/x-www-form-urlencoded"; myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data. 
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // Get response 
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

            if (myResponse.ResponseUri.ToString().StartsWith("http://www.58tax.com/index"))
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
                DownloadFile3(this.username.Text, myCookieContainer);
                bool ret = DownloadDat(myCookieContainer);
                /*
                if(!ret)
                {
                    MessageBox.Show("下载dat文件错误!");
                    Application.Exit();
                }*/
                MainForm mf = new MainForm();
                mf.Show();
                Visible = false; //隐藏登陆窗口
            }
            else {
                MessageBox.Show("登录失败！");
               
            }            
            
        }

        private bool DownloadDat(CookieContainer cookie)
        {
            //读取dat
            //FileInfo fi = new FileInfo(path3);
            //if (fi.Length == 0)
            //{
            //    MessageBox.Show("读取dat错误");
            //    return;
            //}

            StreamReader sr = new StreamReader(path3, Encoding.Default);
            String line;
            line = sr.ReadLine();
            string l = line.ToString();
            string[] str = l.Split(';');

            string[] firststr = str[0].Split(',');
            if(line.Length==0)
            {
                return false;
            }
            int num = Convert.ToInt32(firststr[1]);//报税的数量

            string[] datstr = new string[num];
            //MessageBox.Show(firststr[1]);
            for (int i = 0; i < num; i++)
            {
                datstr[i] = str[i + 1].Split(',')[2];//dat的地址
             //   MessageBox.Show(datstr[i]);
                string DatPath = i + ".dat";
                HttpWebRequest request = WebRequest.Create(datstr[i]) as HttpWebRequest;
                //发送请求并获取相应回应数据
                request.CookieContainer = cookie;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                Stream stream = new FileStream(DatPath, FileMode.Create);
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
            return true;
        }

        //下载文件3
        private void DownloadFile3(string uname, CookieContainer cookie)
        {
            // 设置参数
            string file3 = "http://www.58tax.com/autoApply/tax_report_files?id=" + uname + "&month=05&info=3";
            HttpWebRequest request = WebRequest.Create(file3) as HttpWebRequest;
            //发送请求并获取相应回应数据
            request.CookieContainer = cookie;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(path3, FileMode.Create);
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
            sr.Close();
            return f1;
        }

        private void DownloadFile1(string uname,CookieContainer cookie)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create("http://www.58tax.com/autoApply/tax_report_files?id="+uname+"&month=05&info=1") as HttpWebRequest;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.58tax.com/");
        }
    }
}
