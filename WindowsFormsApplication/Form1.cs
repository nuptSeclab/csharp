using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication
{
    /*
    Form1 用于捕捉窗口句柄测试
    */
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);//查找窗口句柄
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);//查找窗口内控件句柄
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);//发送消息
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        private static extern void SetForegroundWindow(IntPtr hwnd);// 设置窗口为激活状态
        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(
            IntPtr hWnd,//窗口句柄 
            StringBuilder lpString,//标题 
            int nMaxCount //最大值 
            );
        //获取类的名字 
        [DllImport("user32.dll")]
        private static extern int GetClassName(
            IntPtr hWnd,//句柄 
            StringBuilder lpString, //类名 
            int nMaxCount //最大值 
            );
        //根据坐标获取窗口句柄 
        [DllImport("user32")]
        private static extern IntPtr WindowFromPoint(
        Point Point  //坐标 
        );
        public Form1()
        {
            InitializeComponent();
        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hwndCalc = FindWindow("#32770",null); //查找窗口句柄
            if (hwndCalc != IntPtr.Zero)//找到
            {
    
                
                SetForegroundWindow(hwndCalc);
                System.Windows.Forms.SendKeys.SendWait("{TAB}");
                System.Windows.Forms.SendKeys.SendWait("{TAB}");
                System.Windows.Forms.SendKeys.SendWait("123456");
                System.Windows.Forms.SendKeys.SendWait("{TAB}");
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");
                //const uint WM_SETTEXT = 0x000C;//设置文本框内容的消息
                //const uint BM_CLICK = 0xF5; //鼠标点击的消息，对于各种消息的数值，你还是得去查查API手册
                //IntPtr hwndLogin = FindWindowEx(hwndCalc, 0, null, "确定"); //获取登陆按钮的句柄
                //IntPtr hwndP = FindWindowEx(hwndCalc, 0, "", "Edit");  //获取密码输入框的控件句柄 SetForegroundWindow ( hwndCalc );    //将QQ窗口设置为激活

                //System.Threading.Thread.Sleep(1000);   //暂停1秒让你看到效果
                //SendMessage(hwndP, WM_SETTEXT, 0, 0);//发送文本框2里面的内容（QQpassword）

                //System.Threading.Thread.Sleep(1000);   //暂停1秒让你看到效果
                //SendMessage(hwndLogin, BM_CLICK, 0, 0);//点击登录
            }
            else
            {
                MessageBox.Show("没有启动 ");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            Point p = new Point(x, y);
            this.x.Text = x.ToString();
            this.y.Text = y.ToString();
            IntPtr formHandle = WindowFromPoint(p);//得到窗口句柄 
            StringBuilder title = new StringBuilder(256);
            GetWindowText(formHandle, title, title.Capacity);//得到窗口的标题 
            StringBuilder className = new StringBuilder(256);
            GetClassName(formHandle, className, className.Capacity);//得到窗口的句柄 
            this.textBox1.Text = title.ToString();
            this.textBox2.Text = formHandle.ToString();
            this.textBox3.Text = className.ToString();

        }

    }
   }
