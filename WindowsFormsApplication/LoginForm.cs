using System;
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
            this.username.Text = "admin";
            this.password.Text = "admin";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string strId = "18602538904";
            string strPassword = "dsfdsf";
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "loginName=" + strId;
            postData += ("&password=" + strPassword);
            byte[] data = encoding.GetBytes(postData);
            // Prepare web request 
            HttpWebRequest myRequest =
            (HttpWebRequest)WebRequest.Create("http://test2.58tax.com/loginCheck");
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded"; myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data. 
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // Get response 
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string content = reader.ReadToEnd();
            //MessageBox.Show(content);
            StreamWriter sw = new StreamWriter("E:\\1.txt");
          
            sw.Write(content);
            sw.Close();
            //Response.Write(content);
            //return retString;




            if (username.Text=="admin" && password.Text=="admin")
            {
                MainForm mf = new MainForm();
                mf.Show();
                Visible = false; //隐藏登陆窗口
            }
            else
            {
                MessageBox.Show("failed");
            }
            
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
