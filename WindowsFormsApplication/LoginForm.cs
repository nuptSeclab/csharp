using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            if(username.Text=="admin" && password.Text=="admin")
            {
                MainForm mf = new MainForm();
                mf.Show();
               // this.Visible = false;

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
