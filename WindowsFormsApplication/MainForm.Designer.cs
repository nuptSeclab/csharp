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
            this.button_back = new System.Windows.Forms.Button();
            this.button_forward = new System.Windows.Forms.Button();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.button_go = new System.Windows.Forms.Button();
            this.button_submit = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button_gs = new System.Windows.Forms.Button();
            this.button_file1 = new System.Windows.Forms.Button();
            this.button_upld = new System.Windows.Forms.Button();
            this.button_sbmt = new System.Windows.Forms.Button();
            this.groupBox_gs = new System.Windows.Forms.GroupBox();
            this.groupBox_yhs = new System.Windows.Forms.GroupBox();
            this.button_home = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox_yzm = new System.Windows.Forms.PictureBox();
            this.textBox_yzm = new System.Windows.Forms.TextBox();
            this.webBrowserGS = new System.Windows.Forms.WebBrowser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox_HTML = new System.Windows.Forms.TextBox();
            this.groupBox_gs.SuspendLayout();
            this.groupBox_yhs.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yzm)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(705, 328);
            this.webBrowser.TabIndex = 3;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            this.webBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser_NewWindow);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(886, 35);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 6;
            this.button.Text = "exit";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // button_back
            // 
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.Location = new System.Drawing.Point(25, 20);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(30, 30);
            this.button_back.TabIndex = 7;
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_forward
            // 
            this.button_forward.Image = ((System.Drawing.Image)(resources.GetObject("button_forward.Image")));
            this.button_forward.Location = new System.Drawing.Point(71, 20);
            this.button_forward.Name = "button_forward";
            this.button_forward.Size = new System.Drawing.Size(30, 30);
            this.button_forward.TabIndex = 8;
            this.button_forward.UseVisualStyleBackColor = true;
            this.button_forward.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_url
            // 
            this.textBox_url.Location = new System.Drawing.Point(124, 26);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(450, 21);
            this.textBox_url.TabIndex = 9;
            // 
            // button_go
            // 
            this.button_go.Location = new System.Drawing.Point(591, 20);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(30, 30);
            this.button_go.TabIndex = 10;
            this.button_go.Text = "Go";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(7, 29);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(74, 24);
            this.button_submit.TabIndex = 11;
            this.button_submit.Text = "印花税暂存";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button_gs
            // 
            this.button_gs.Location = new System.Drawing.Point(17, 26);
            this.button_gs.Name = "button_gs";
            this.button_gs.Size = new System.Drawing.Size(60, 25);
            this.button_gs.TabIndex = 14;
            this.button_gs.Text = "个税";
            this.button_gs.UseVisualStyleBackColor = true;
            this.button_gs.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button_file1
            // 
            this.button_file1.Location = new System.Drawing.Point(17, 57);
            this.button_file1.Name = "button_file1";
            this.button_file1.Size = new System.Drawing.Size(60, 25);
            this.button_file1.TabIndex = 15;
            this.button_file1.Text = "浏览";
            this.button_file1.UseVisualStyleBackColor = true;
            this.button_file1.Click += new System.EventHandler(this.button_test2_Click);
            // 
            // button_upld
            // 
            this.button_upld.Location = new System.Drawing.Point(83, 26);
            this.button_upld.Name = "button_upld";
            this.button_upld.Size = new System.Drawing.Size(60, 25);
            this.button_upld.TabIndex = 16;
            this.button_upld.Text = "上传";
            this.button_upld.UseVisualStyleBackColor = true;
            this.button_upld.Click += new System.EventHandler(this.button_upld_Click);
            // 
            // button_sbmt
            // 
            this.button_sbmt.Location = new System.Drawing.Point(83, 57);
            this.button_sbmt.Name = "button_sbmt";
            this.button_sbmt.Size = new System.Drawing.Size(60, 25);
            this.button_sbmt.TabIndex = 17;
            this.button_sbmt.Text = "提交";
            this.button_sbmt.UseVisualStyleBackColor = true;
            this.button_sbmt.Click += new System.EventHandler(this.button_sbmt_Click);
            // 
            // groupBox_gs
            // 
            this.groupBox_gs.Controls.Add(this.button_gs);
            this.groupBox_gs.Controls.Add(this.button_sbmt);
            this.groupBox_gs.Controls.Add(this.button_file1);
            this.groupBox_gs.Controls.Add(this.button_upld);
            this.groupBox_gs.Location = new System.Drawing.Point(20, 133);
            this.groupBox_gs.Name = "groupBox_gs";
            this.groupBox_gs.Size = new System.Drawing.Size(161, 100);
            this.groupBox_gs.TabIndex = 18;
            this.groupBox_gs.TabStop = false;
            this.groupBox_gs.Text = "个税";
            // 
            // groupBox_yhs
            // 
            this.groupBox_yhs.Controls.Add(this.button_submit);
            this.groupBox_yhs.Location = new System.Drawing.Point(20, 23);
            this.groupBox_yhs.Name = "groupBox_yhs";
            this.groupBox_yhs.Size = new System.Drawing.Size(91, 73);
            this.groupBox_yhs.TabIndex = 19;
            this.groupBox_yhs.TabStop = false;
            this.groupBox_yhs.Text = "印花税";
            // 
            // button_home
            // 
            this.button_home.Location = new System.Drawing.Point(789, 35);
            this.button_home.Name = "button_home";
            this.button_home.Size = new System.Drawing.Size(60, 25);
            this.button_home.TabIndex = 20;
            this.button_home.Text = "home";
            this.button_home.UseVisualStyleBackColor = true;
            this.button_home.Click += new System.EventHandler(this.button_home_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(47, 56);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(719, 360);
            this.tabControl1.TabIndex = 21;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox_gs);
            this.tabPage1.Controls.Add(this.groupBox_yhs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(711, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(711, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "浏览器";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.pictureBox_yzm);
            this.tabPage4.Controls.Add(this.textBox_yzm);
            this.tabPage4.Controls.Add(this.webBrowserGS);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(711, 334);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "验证码";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox_yzm
            // 
            this.pictureBox_yzm.Location = new System.Drawing.Point(557, 14);
            this.pictureBox_yzm.Name = "pictureBox_yzm";
            this.pictureBox_yzm.Size = new System.Drawing.Size(128, 62);
            this.pictureBox_yzm.TabIndex = 0;
            this.pictureBox_yzm.TabStop = false;
            this.pictureBox_yzm.Click += new System.EventHandler(this.pictureBox_yzm_Click);
            // 
            // textBox_yzm
            // 
            this.textBox_yzm.Location = new System.Drawing.Point(559, 98);
            this.textBox_yzm.Name = "textBox_yzm";
            this.textBox_yzm.Size = new System.Drawing.Size(125, 21);
            this.textBox_yzm.TabIndex = 2;
            // 
            // webBrowserGS
            // 
            this.webBrowserGS.Location = new System.Drawing.Point(0, 3);
            this.webBrowserGS.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserGS.Name = "webBrowserGS";
            this.webBrowserGS.Size = new System.Drawing.Size(272, 205);
            this.webBrowserGS.TabIndex = 1;
            this.webBrowserGS.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_gs_DocumentCompleted);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox_HTML);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(711, 334);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "HTML";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox_HTML
            // 
            this.textBox_HTML.Location = new System.Drawing.Point(0, 0);
            this.textBox_HTML.Multiline = true;
            this.textBox_HTML.Name = "textBox_HTML";
            this.textBox_HTML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_HTML.Size = new System.Drawing.Size(711, 334);
            this.textBox_HTML.TabIndex = 0;
            this.textBox_HTML.Text = "HTML";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_home);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.button_forward);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button);
            this.Name = "MainForm";
            this.Text = "自动报税 v1.2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.groupBox_gs.ResumeLayout(false);
            this.groupBox_yhs.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yzm)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button_gs;
        private System.Windows.Forms.Button button_file1;
        private System.Windows.Forms.Button button_upld;
        private System.Windows.Forms.Button button_sbmt;
        private System.Windows.Forms.GroupBox groupBox_gs;
        private System.Windows.Forms.GroupBox groupBox_yhs;
        private System.Windows.Forms.Button button_home;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox_HTML;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox_yzm;
        private System.Windows.Forms.WebBrowser webBrowserGS;
        private System.Windows.Forms.TextBox textBox_yzm;
        private System.Windows.Forms.Button button1;
    }
}