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
        public LoginForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            this.username.Text = "15150577554";
            this.password.Text = "DCRns123";
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
            //StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            //string content = reader.ReadToEnd();

            //Get header
            //foreach (Cookie ck in myResponse.Cookies)
            //{
            //    myCookieContainer.Add(ck);
            //}
            //IEnumerator iem = head.GetEnumerator();
            //ArrayList value = new ArrayList();
            //StreamWriter sw = new StreamWriter("E:\\1.txt");
            //for (int i = 0; iem.MoveNext(); i++)
            //{
            //    string key = head.GetKey(i);
            //    value.Add(head.Get(key));
            //    sw.WriteLine(value[i]);
            //}

            if (myResponse.ResponseUri.ToString().StartsWith("http://test2.58tax.com/index"))
            {
                MainForm mf = new MainForm();
                mf.Show();
                Visible = false; //隐藏登陆窗口
            }
            else {
                MessageBox.Show("failed");
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
