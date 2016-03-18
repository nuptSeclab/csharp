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
    public partial class TargetForm : Form
    {
        public TargetForm()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            //need to acquire from server
            string txt = "201683833,99,60,https://login.abc.com/login.aspx,200";
            Target target = new Target();
            int ret = target.InitWithTxt(txt);
            if (ret == 1)
            {
                auto_id.Text = target.auto_id;
                run_times.Text = target.run_times;
                out_time.Text = target.out_time;
                target_url.Text = target.target_url;
                timing1.Text = target.timing1;
            }
            else
            {
                auto_id.Text = "Failed";
                run_times.Text = "Failed";
                out_time.Text = "Failed";
                target_url.Text = "Failed";
                timing1.Text = "Failed";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
