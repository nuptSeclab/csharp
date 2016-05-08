namespace WindowsFormsApplication
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.button = new System.Windows.Forms.Button();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.button_go = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_yzm = new System.Windows.Forms.TextBox();
            this.webBrowserGS = new System.Windows.Forms.WebBrowser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox_HTML = new System.Windows.Forms.TextBox();
            this.groupBox_gs = new System.Windows.Forms.GroupBox();
            this.button_gs = new System.Windows.Forms.Button();
            this.button_sbmt = new System.Windows.Forms.Button();
            this.button_file1 = new System.Windows.Forms.Button();
            this.button_upld = new System.Windows.Forms.Button();
            this.button_home = new System.Windows.Forms.Button();
            this.groupBox_yhs = new System.Windows.Forms.GroupBox();
            this.button_submit = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.button_forward = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox_gs.SuspendLayout();
            this.groupBox_yhs.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webBrowser
            // 
            resources.ApplyResources(this.webBrowser, "webBrowser");
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // 
            // button
            // 
            resources.ApplyResources(this.button, "button");
            this.button.Name = "button";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox_url
            // 
            resources.ApplyResources(this.textBox_url, "textBox_url");
            this.textBox_url.Name = "textBox_url";
            // 
            // button_go
            // 
            resources.ApplyResources(this.button_go, "button_go");
            this.button_go.Name = "button_go";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.textBox_yzm);
            this.tabPage4.Controls.Add(this.webBrowserGS);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox_yzm
            // 
            resources.ApplyResources(this.textBox_yzm, "textBox_yzm");
            this.textBox_yzm.Name = "textBox_yzm";
            // 
            // webBrowserGS
            // 
            resources.ApplyResources(this.webBrowserGS, "webBrowserGS");
            this.webBrowserGS.Name = "webBrowserGS";
            this.webBrowserGS.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_gs_DocumentCompleted);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox_HTML);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox_HTML
            // 
            resources.ApplyResources(this.textBox_HTML, "textBox_HTML");
            this.textBox_HTML.Name = "textBox_HTML";
            // 
            // groupBox_gs
            // 
            this.groupBox_gs.Controls.Add(this.button_gs);
            this.groupBox_gs.Controls.Add(this.button_sbmt);
            this.groupBox_gs.Controls.Add(this.button_file1);
            this.groupBox_gs.Controls.Add(this.button_upld);
            resources.ApplyResources(this.groupBox_gs, "groupBox_gs");
            this.groupBox_gs.Name = "groupBox_gs";
            this.groupBox_gs.TabStop = false;
            // 
            // button_gs
            // 
            resources.ApplyResources(this.button_gs, "button_gs");
            this.button_gs.Name = "button_gs";
            this.button_gs.UseVisualStyleBackColor = true;
            this.button_gs.Click += new System.EventHandler(this.button_grsds_Click);
            // 
            // button_sbmt
            // 
            resources.ApplyResources(this.button_sbmt, "button_sbmt");
            this.button_sbmt.Name = "button_sbmt";
            this.button_sbmt.UseVisualStyleBackColor = true;
            // 
            // button_file1
            // 
            resources.ApplyResources(this.button_file1, "button_file1");
            this.button_file1.Name = "button_file1";
            this.button_file1.UseVisualStyleBackColor = true;
            // 
            // button_upld
            // 
            resources.ApplyResources(this.button_upld, "button_upld");
            this.button_upld.Name = "button_upld";
            this.button_upld.UseVisualStyleBackColor = true;
            // 
            // button_home
            // 
            resources.ApplyResources(this.button_home, "button_home");
            this.button_home.Name = "button_home";
            this.button_home.UseVisualStyleBackColor = true;
            this.button_home.Click += new System.EventHandler(this.button_home_Click);
            // 
            // groupBox_yhs
            // 
            this.groupBox_yhs.Controls.Add(this.button_submit);
            resources.ApplyResources(this.groupBox_yhs, "groupBox_yhs");
            this.groupBox_yhs.Name = "groupBox_yhs";
            this.groupBox_yhs.TabStop = false;
            // 
            // button_submit
            // 
            resources.ApplyResources(this.button_submit, "button_submit");
            this.button_submit.Name = "button_submit";
            this.button_submit.UseVisualStyleBackColor = true;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // button_forward
            // 
            resources.ApplyResources(this.button_forward, "button_forward");
            this.button_forward.Name = "button_forward";
            this.button_forward.UseVisualStyleBackColor = true;
            this.button_forward.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_back
            // 
            resources.ApplyResources(this.button_back, "button_back");
            this.button_back.Name = "button_back";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // timer5
            // 
            this.timer5.Interval = 1000;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_home);
            this.Controls.Add(this.groupBox_gs);
            this.Controls.Add(this.groupBox_yhs);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.button_forward);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button);
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox_gs.ResumeLayout(false);
            this.groupBox_yhs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_forward;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox_HTML;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.WebBrowser webBrowserGS;
        private System.Windows.Forms.TextBox textBox_yzm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.GroupBox groupBox_gs;
        private System.Windows.Forms.Button button_gs;
        private System.Windows.Forms.Button button_sbmt;
        private System.Windows.Forms.Button button_file1;
        private System.Windows.Forms.Button button_upld;
        private System.Windows.Forms.Button button_home;
        private System.Windows.Forms.GroupBox groupBox_yhs;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer5;
    }
}