﻿namespace WindowsFormsApplication
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
            this.button_grsds = new System.Windows.Forms.Button();
            this.button_submit_grsds = new System.Windows.Forms.Button();
            this.button_gs = new System.Windows.Forms.Button();
            this.button_file1 = new System.Windows.Forms.Button();
            this.button_upld = new System.Windows.Forms.Button();
            this.button_sbmt = new System.Windows.Forms.Button();
            this.groupBox_gs = new System.Windows.Forms.GroupBox();
            this.groupBox_yhs = new System.Windows.Forms.GroupBox();
            this.button_home = new System.Windows.Forms.Button();
            this.groupBox_gs.SuspendLayout();
            this.groupBox_yhs.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(6, 56);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(744, 400);
            this.webBrowser.TabIndex = 3;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
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
            // button_grsds
            // 
            this.button_grsds.Location = new System.Drawing.Point(886, 131);
            this.button_grsds.Name = "button_grsds";
            this.button_grsds.Size = new System.Drawing.Size(86, 23);
            this.button_grsds.TabIndex = 12;
            this.button_grsds.Text = "提交个人所得";
            this.button_grsds.UseVisualStyleBackColor = true;
            this.button_grsds.Click += new System.EventHandler(this.button_grsd_Click);
            // 
            // button_submit_grsds
            // 
            this.button_submit_grsds.Location = new System.Drawing.Point(886, 101);
            this.button_submit_grsds.Name = "button_submit_grsds";
            this.button_submit_grsds.Size = new System.Drawing.Size(86, 24);
            this.button_submit_grsds.TabIndex = 13;
            this.button_submit_grsds.Text = "上传个人所得";
            this.button_submit_grsds.UseVisualStyleBackColor = true;
            this.button_submit_grsds.Click += new System.EventHandler(this.button_submit_grsds_Click);
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
            this.groupBox_gs.Location = new System.Drawing.Point(772, 196);
            this.groupBox_gs.Name = "groupBox_gs";
            this.groupBox_gs.Size = new System.Drawing.Size(161, 100);
            this.groupBox_gs.TabIndex = 18;
            this.groupBox_gs.TabStop = false;
            this.groupBox_gs.Text = "个税";
            // 
            // groupBox_yhs
            // 
            this.groupBox_yhs.Controls.Add(this.button_submit);
            this.groupBox_yhs.Location = new System.Drawing.Point(772, 92);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.button_home);
            this.Controls.Add(this.groupBox_yhs);
            this.Controls.Add(this.groupBox_gs);
            this.Controls.Add(this.button_submit_grsds);
            this.Controls.Add(this.button_grsds);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.button_forward);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button);
            this.Controls.Add(this.webBrowser);
            this.Name = "MainForm";
            this.Text = "自动报税 v1.2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
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
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button_grsds;
        private System.Windows.Forms.Button button_submit_grsds;
        private System.Windows.Forms.Button button_gs;
        private System.Windows.Forms.Button button_file1;
        private System.Windows.Forms.Button button_upld;
        private System.Windows.Forms.Button button_sbmt;
        private System.Windows.Forms.GroupBox groupBox_gs;
        private System.Windows.Forms.GroupBox groupBox_yhs;
        private System.Windows.Forms.Button button_home;
    }
}