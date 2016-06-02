namespace WindowsFormsApplication
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.CheckUser = new System.Windows.Forms.CheckBox();
            this.UserCombo = new System.Windows.Forms.ComboBox();
            this.lgbutton = new DevComponents.DotNetBar.ButtonX();
            this.rgbutton = new DevComponents.DotNetBar.ButtonX();
            this.wbbutton = new DevComponents.DotNetBar.ButtonX();
            this.srgbutton = new DevComponents.DotNetBar.ButtonX();
            this.rstbutton = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(213, 278);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(55, 18);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "登陆";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Visible = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(166, 271);
            this.username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(39, 25);
            this.username.TabIndex = 4;
            this.username.Text = "admin";
            this.username.Visible = false;
            this.username.Click += new System.EventHandler(this.username_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(199, 68);
            this.password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(167, 25);
            this.password.TabIndex = 5;
            this.password.Text = "admin";
            this.password.UseSystemPasswordChar = true;
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // CheckUser
            // 
            this.CheckUser.AutoSize = true;
            this.CheckUser.Location = new System.Drawing.Point(16, 111);
            this.CheckUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CheckUser.Name = "CheckUser";
            this.CheckUser.Size = new System.Drawing.Size(119, 19);
            this.CheckUser.TabIndex = 7;
            this.CheckUser.Text = "记住用户信息";
            this.CheckUser.UseVisualStyleBackColor = true;
            this.CheckUser.CheckedChanged += new System.EventHandler(this.CheckUser_CheckedChanged);
            // 
            // UserCombo
            // 
            this.UserCombo.FormattingEnabled = true;
            this.UserCombo.Location = new System.Drawing.Point(16, 68);
            this.UserCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UserCombo.Name = "UserCombo";
            this.UserCombo.Size = new System.Drawing.Size(160, 23);
            this.UserCombo.TabIndex = 8;
            this.UserCombo.SelectedIndexChanged += new System.EventHandler(this.UserCombo_SelectedIndexChanged);
            // 
            // lgbutton
            // 
            this.lgbutton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.lgbutton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.lgbutton.Location = new System.Drawing.Point(41, 153);
            this.lgbutton.Name = "lgbutton";
            this.lgbutton.Size = new System.Drawing.Size(104, 36);
            this.lgbutton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lgbutton.TabIndex = 10;
            this.lgbutton.Text = "登陆";
            this.lgbutton.Click += new System.EventHandler(this.lgbutton_Click);
            // 
            // rgbutton
            // 
            this.rgbutton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.rgbutton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.rgbutton.Location = new System.Drawing.Point(239, 153);
            this.rgbutton.Name = "rgbutton";
            this.rgbutton.Size = new System.Drawing.Size(104, 36);
            this.rgbutton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rgbutton.TabIndex = 11;
            this.rgbutton.Text = "用户注册";
            this.rgbutton.Click += new System.EventHandler(this.rgbutton_Click);
            // 
            // wbbutton
            // 
            this.wbbutton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.wbbutton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.wbbutton.Location = new System.Drawing.Point(41, 214);
            this.wbbutton.Name = "wbbutton";
            this.wbbutton.Size = new System.Drawing.Size(104, 36);
            this.wbbutton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.wbbutton.TabIndex = 12;
            this.wbbutton.Text = "58tax官网";
            this.wbbutton.Click += new System.EventHandler(this.wbbutton_Click);
            // 
            // srgbutton
            // 
            this.srgbutton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.srgbutton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.srgbutton.Location = new System.Drawing.Point(239, 214);
            this.srgbutton.Name = "srgbutton";
            this.srgbutton.Size = new System.Drawing.Size(104, 36);
            this.srgbutton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.srgbutton.TabIndex = 13;
            this.srgbutton.Text = "服务商注册";
            // 
            // rstbutton
            // 
            this.rstbutton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.rstbutton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.rstbutton.Location = new System.Drawing.Point(239, 105);
            this.rstbutton.Name = "rstbutton";
            this.rstbutton.Size = new System.Drawing.Size(104, 25);
            this.rstbutton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rstbutton.TabIndex = 14;
            this.rstbutton.Text = "重置";
            this.rstbutton.Click += new System.EventHandler(this.rstbutton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(383, 309);
            this.Controls.Add(this.rstbutton);
            this.Controls.Add(this.srgbutton);
            this.Controls.Add(this.wbbutton);
            this.Controls.Add(this.rgbutton);
            this.Controls.Add(this.lgbutton);
            this.Controls.Add(this.UserCombo);
            this.Controls.Add(this.CheckUser);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.CheckBox CheckUser;
        private System.Windows.Forms.ComboBox UserCombo;
        private DevComponents.DotNetBar.ButtonX lgbutton;
        private DevComponents.DotNetBar.ButtonX rgbutton;
        private DevComponents.DotNetBar.ButtonX wbbutton;
        private DevComponents.DotNetBar.ButtonX srgbutton;
        private DevComponents.DotNetBar.ButtonX rstbutton;
    }
}

