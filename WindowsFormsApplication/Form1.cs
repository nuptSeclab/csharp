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

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
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


        private void button1_Click(object sender, EventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            Point p = new Point(x, y);
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
