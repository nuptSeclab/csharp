namespace WindowsFormsApplication
{
    partial class TargetForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.auto_id = new System.Windows.Forms.TextBox();
            this.run_times = new System.Windows.Forms.TextBox();
            this.out_time = new System.Windows.Forms.TextBox();
            this.target_url = new System.Windows.Forms.TextBox();
            this.timing1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "尝试次数:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "超时时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "响应值:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户编号:";
            // 
            // auto_id
            // 
            this.auto_id.Enabled = false;
            this.auto_id.Location = new System.Drawing.Point(92, 24);
            this.auto_id.Name = "auto_id";
            this.auto_id.Size = new System.Drawing.Size(154, 21);
            this.auto_id.TabIndex = 5;
            // 
            // run_times
            // 
            this.run_times.Enabled = false;
            this.run_times.Location = new System.Drawing.Point(92, 58);
            this.run_times.Name = "run_times";
            this.run_times.Size = new System.Drawing.Size(154, 21);
            this.run_times.TabIndex = 6;
            // 
            // out_time
            // 
            this.out_time.Enabled = false;
            this.out_time.Location = new System.Drawing.Point(92, 91);
            this.out_time.Name = "out_time";
            this.out_time.Size = new System.Drawing.Size(154, 21);
            this.out_time.TabIndex = 7;
            // 
            // target_url
            // 
            this.target_url.Enabled = false;
            this.target_url.Location = new System.Drawing.Point(92, 124);
            this.target_url.Name = "target_url";
            this.target_url.Size = new System.Drawing.Size(154, 21);
            this.target_url.TabIndex = 8;
            // 
            // timing1
            // 
            this.timing1.Enabled = false;
            this.timing1.Location = new System.Drawing.Point(92, 157);
            this.timing1.Name = "timing1";
            this.timing1.Size = new System.Drawing.Size(154, 21);
            this.timing1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 22);
            this.button1.TabIndex = 10;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 22);
            this.button2.TabIndex = 11;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "目标URL:";
            // 
            // TargetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 241);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timing1);
            this.Controls.Add(this.target_url);
            this.Controls.Add(this.out_time);
            this.Controls.Add(this.run_times);
            this.Controls.Add(this.auto_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TargetForm";
            this.Text = "TargetForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox auto_id;
        private System.Windows.Forms.TextBox run_times;
        private System.Windows.Forms.TextBox out_time;
        private System.Windows.Forms.TextBox target_url;
        private System.Windows.Forms.TextBox timing1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}