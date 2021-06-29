namespace File_Transfer.WinForm
{
    partial class SendForm
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
            this.File_TB = new System.Windows.Forms.TextBox();
            this.Send_BT = new System.Windows.Forms.Button();
            this.Rece_IP = new System.Windows.Forms.TextBox();
            this.IP_LB = new System.Windows.Forms.Label();
            this.File_LB = new System.Windows.Forms.Label();
            this.Choice_BT = new System.Windows.Forms.Button();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel_BT = new System.Windows.Forms.Button();
            this.ST = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // File_TB
            // 
            this.File_TB.Location = new System.Drawing.Point(95, 43);
            this.File_TB.Name = "File_TB";
            this.File_TB.Size = new System.Drawing.Size(247, 25);
            this.File_TB.TabIndex = 0;
            // 
            // Send_BT
            // 
            this.Send_BT.Location = new System.Drawing.Point(267, 150);
            this.Send_BT.Name = "Send_BT";
            this.Send_BT.Size = new System.Drawing.Size(75, 32);
            this.Send_BT.TabIndex = 1;
            this.Send_BT.Text = "发送";
            this.Send_BT.UseVisualStyleBackColor = true;
            this.Send_BT.Click += new System.EventHandler(this.Send_Click);
            // 
            // Rece_IP
            // 
            this.Rece_IP.Location = new System.Drawing.Point(95, 12);
            this.Rece_IP.Name = "Rece_IP";
            this.Rece_IP.Size = new System.Drawing.Size(247, 25);
            this.Rece_IP.TabIndex = 2;
            // 
            // IP_LB
            // 
            this.IP_LB.AutoSize = true;
            this.IP_LB.Location = new System.Drawing.Point(16, 22);
            this.IP_LB.Name = "IP_LB";
            this.IP_LB.Size = new System.Drawing.Size(68, 15);
            this.IP_LB.TabIndex = 3;
            this.IP_LB.Text = "接收方IP";
            // 
            // File_LB
            // 
            this.File_LB.AutoSize = true;
            this.File_LB.Location = new System.Drawing.Point(16, 46);
            this.File_LB.Name = "File_LB";
            this.File_LB.Size = new System.Drawing.Size(37, 15);
            this.File_LB.TabIndex = 4;
            this.File_LB.Text = "文件";
            // 
            // Choice_BT
            // 
            this.Choice_BT.Location = new System.Drawing.Point(186, 150);
            this.Choice_BT.Name = "Choice_BT";
            this.Choice_BT.Size = new System.Drawing.Size(75, 32);
            this.Choice_BT.TabIndex = 5;
            this.Choice_BT.Text = " 选择";
            this.Choice_BT.UseVisualStyleBackColor = true;
            this.Choice_BT.Click += new System.EventHandler(this.Button1_Click);
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(95, 74);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(247, 15);
            this.PB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "进度条";
            // 
            // Cancel_BT
            // 
            this.Cancel_BT.Location = new System.Drawing.Point(109, 150);
            this.Cancel_BT.Name = "Cancel_BT";
            this.Cancel_BT.Size = new System.Drawing.Size(71, 32);
            this.Cancel_BT.TabIndex = 10;
            this.Cancel_BT.Text = "取消";
            this.Cancel_BT.UseVisualStyleBackColor = true;
            this.Cancel_BT.Click += new System.EventHandler(this.Cancel_But_Click);
            // 
            // ST
            // 
            this.ST.AutoSize = true;
            this.ST.Location = new System.Drawing.Point(16, 102);
            this.ST.Name = "ST";
            this.ST.Size = new System.Drawing.Size(37, 15);
            this.ST.TabIndex = 11;
            this.ST.Text = "状态";
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 194);
            this.Controls.Add(this.ST);
            this.Controls.Add(this.Cancel_BT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PB);
            this.Controls.Add(this.Choice_BT);
            this.Controls.Add(this.File_LB);
            this.Controls.Add(this.IP_LB);
            this.Controls.Add(this.Rece_IP);
            this.Controls.Add(this.Send_BT);
            this.Controls.Add(this.File_TB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SendForm";
            this.Text = "发送端";
            this.Load += new System.EventHandler(this.SendForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox File_TB;
        private System.Windows.Forms.Button Send_BT;
        private System.Windows.Forms.TextBox Rece_IP;
        private System.Windows.Forms.Label IP_LB;
        private System.Windows.Forms.Label File_LB;
        private System.Windows.Forms.Button Choice_BT;
        private System.Windows.Forms.ProgressBar PB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel_BT;
        private System.Windows.Forms.Label ST;
    }
}