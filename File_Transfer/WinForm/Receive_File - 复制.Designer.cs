namespace File_Transfer.WinForm
{
    partial class Receive_File
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
            this.Start_BT = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Port_TB = new System.Windows.Forms.TextBox();
            this.IP_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tlblState = new System.Windows.Forms.Label();
            this.FN_LB = new System.Windows.Forms.Label();
            this.S_LB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start_BT
            // 
            this.Start_BT.Location = new System.Drawing.Point(196, 193);
            this.Start_BT.Margin = new System.Windows.Forms.Padding(4);
            this.Start_BT.Name = "Start_BT";
            this.Start_BT.Size = new System.Drawing.Size(100, 29);
            this.Start_BT.TabIndex = 23;
            this.Start_BT.Text = "开始监听";
            this.Start_BT.UseVisualStyleBackColor = true;
            this.Start_BT.Click += new System.EventHandler(this.btnStartListen_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(117, 97);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(224, 15);
            this.progressBar1.TabIndex = 22;
            // 
            // Port_TB
            // 
            this.Port_TB.Location = new System.Drawing.Point(117, 50);
            this.Port_TB.Margin = new System.Windows.Forms.Padding(4);
            this.Port_TB.Name = "Port_TB";
            this.Port_TB.Size = new System.Drawing.Size(287, 25);
            this.Port_TB.TabIndex = 21;
            // 
            // IP_TB
            // 
            this.IP_TB.Location = new System.Drawing.Point(117, 9);
            this.IP_TB.Margin = new System.Windows.Forms.Padding(4);
            this.IP_TB.Name = "IP_TB";
            this.IP_TB.ReadOnly = true;
            this.IP_TB.Size = new System.Drawing.Size(287, 25);
            this.IP_TB.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "进度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "IP地址：";
            // 
            // tlblState
            // 
            this.tlblState.AutoSize = true;
            this.tlblState.Location = new System.Drawing.Point(13, 137);
            this.tlblState.Name = "tlblState";
            this.tlblState.Size = new System.Drawing.Size(52, 15);
            this.tlblState.TabIndex = 25;
            this.tlblState.Text = "状态：";
            // 
            // FN_LB
            // 
            this.FN_LB.AutoSize = true;
            this.FN_LB.Location = new System.Drawing.Point(13, 173);
            this.FN_LB.Name = "FN_LB";
            this.FN_LB.Size = new System.Drawing.Size(52, 15);
            this.FN_LB.TabIndex = 26;
            this.FN_LB.Text = "文件名";
            // 
            // S_LB
            // 
            this.S_LB.AutoSize = true;
            this.S_LB.Location = new System.Drawing.Point(13, 207);
            this.S_LB.Name = "S_LB";
            this.S_LB.Size = new System.Drawing.Size(37, 15);
            this.S_LB.TabIndex = 27;
            this.S_LB.Text = "大小";
            // 
            // Receive_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 235);
            this.Controls.Add(this.S_LB);
            this.Controls.Add(this.FN_LB);
            this.Controls.Add(this.tlblState);
            this.Controls.Add(this.Start_BT);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Port_TB);
            this.Controls.Add(this.IP_TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Receive_File";
            this.Text = "Receive_File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Receive_File_FormClosing);
            this.Load += new System.EventHandler(this.Receive_File_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Start_BT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox Port_TB;
        private System.Windows.Forms.TextBox IP_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tlblState;
        private System.Windows.Forms.Label FN_LB;
        private System.Windows.Forms.Label S_LB;
    }
}