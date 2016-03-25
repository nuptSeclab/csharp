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
            this.button_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(6, 56);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(873, 400);
            this.webBrowser.TabIndex = 3;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser_NewWindow);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(897, 35);
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
            this.button_submit.Location = new System.Drawing.Point(897, 75);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(71, 24);
            this.button_submit.TabIndex = 11;
            this.button_submit.Text = "submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(897, 126);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(71, 24);
            this.button_reset.TabIndex = 12;
            this.button_reset.Text = "重试";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.textBox_url);
            this.Controls.Add(this.button_forward);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button);
            this.Controls.Add(this.webBrowser);
            this.Name = "MainForm";
            this.Text = "MainForm";
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
        private System.Windows.Forms.Button button_reset;
    }
}