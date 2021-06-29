namespace File_Transfer
{
    partial class Form1
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
            this.Rec_But = new System.Windows.Forms.Button();
            this.Sen_But = new System.Windows.Forms.Button();
            this.IP_Lab = new System.Windows.Forms.Label();
            this.Help_BT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rec_But
            // 
            this.Rec_But.Location = new System.Drawing.Point(12, 28);
            this.Rec_But.Name = "Rec_But";
            this.Rec_But.Size = new System.Drawing.Size(78, 32);
            this.Rec_But.TabIndex = 0;
            this.Rec_But.Text = "接收";
            this.Rec_But.UseVisualStyleBackColor = true;
            this.Rec_But.Click += new System.EventHandler(this.Rec_But_Click);
            // 
            // Sen_But
            // 
            this.Sen_But.Location = new System.Drawing.Point(96, 28);
            this.Sen_But.Name = "Sen_But";
            this.Sen_But.Size = new System.Drawing.Size(75, 32);
            this.Sen_But.TabIndex = 1;
            this.Sen_But.Text = "发送";
            this.Sen_But.UseVisualStyleBackColor = true;
            this.Sen_But.Click += new System.EventHandler(this.Sen_But_Click);
            // 
            // IP_Lab
            // 
            this.IP_Lab.AutoSize = true;
            this.IP_Lab.Location = new System.Drawing.Point(12, 9);
            this.IP_Lab.Name = "IP_Lab";
            this.IP_Lab.Size = new System.Drawing.Size(61, 15);
            this.IP_Lab.TabIndex = 2;
            this.IP_Lab.Text = "本机IP:";
            // 
            // Help_BT
            // 
            this.Help_BT.Location = new System.Drawing.Point(177, 28);
            this.Help_BT.Name = "Help_BT";
            this.Help_BT.Size = new System.Drawing.Size(73, 32);
            this.Help_BT.TabIndex = 3;
            this.Help_BT.Text = "帮助";
            this.Help_BT.UseVisualStyleBackColor = true;
            this.Help_BT.Click += new System.EventHandler(this.Help_BT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 63);
            this.Controls.Add(this.Help_BT);
            this.Controls.Add(this.IP_Lab);
            this.Controls.Add(this.Sen_But);
            this.Controls.Add(this.Rec_But);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "主界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Rec_But;
        private System.Windows.Forms.Button Sen_But;
        private System.Windows.Forms.Label IP_Lab;
        private System.Windows.Forms.Button Help_BT;
    }
}

