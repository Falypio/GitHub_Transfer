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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.File_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File_PB = new DataGridViewProgress.DataGridViewProgressColumn();
            this.dataGridViewProgressColumn1 = new DataGridViewProgress.DataGridViewProgressColumn();
            this.tlblState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_BT
            // 
            this.Start_BT.Location = new System.Drawing.Point(13, 13);
            this.Start_BT.Margin = new System.Windows.Forms.Padding(4);
            this.Start_BT.Name = "Start_BT";
            this.Start_BT.Size = new System.Drawing.Size(100, 29);
            this.Start_BT.TabIndex = 23;
            this.Start_BT.Text = "开始监听";
            this.Start_BT.UseVisualStyleBackColor = true;
            this.Start_BT.Click += new System.EventHandler(this.BtnStartListen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.File_Name,
            this.File_Size,
            this.File_Status,
            this.File_IP,
            this.File_PB});
            this.dataGridView1.Location = new System.Drawing.Point(12, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1028, 473);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellValueChanged);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_RowValidated);
            // 
            // File_Name
            // 
            this.File_Name.HeaderText = "文件名";
            this.File_Name.Name = "File_Name";
            this.File_Name.ReadOnly = true;
            this.File_Name.Width = 200;
            // 
            // File_Size
            // 
            this.File_Size.HeaderText = "文件大小";
            this.File_Size.Name = "File_Size";
            this.File_Size.ReadOnly = true;
            // 
            // File_Status
            // 
            this.File_Status.HeaderText = "状态";
            this.File_Status.Name = "File_Status";
            this.File_Status.ReadOnly = true;
            this.File_Status.Width = 150;
            // 
            // File_IP
            // 
            this.File_IP.HeaderText = "IP";
            this.File_IP.Name = "File_IP";
            // 
            // File_PB
            // 
            this.File_PB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.File_PB.HeaderText = "进度条";
            this.File_PB.Name = "File_PB";
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.HeaderText = "进度条";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            // 
            // tlblState
            // 
            this.tlblState.AutoSize = true;
            this.tlblState.Location = new System.Drawing.Point(120, 27);
            this.tlblState.Name = "tlblState";
            this.tlblState.Size = new System.Drawing.Size(52, 15);
            this.tlblState.TabIndex = 25;
            this.tlblState.Text = "状态：";
            // 
            // Receive_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 534);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tlblState);
            this.Controls.Add(this.Start_BT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Receive_File";
            this.Text = "接收端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Receive_File_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Start_BT;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridViewProgress.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.Label tlblState;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn File_IP;
        private DataGridViewProgress.DataGridViewProgressColumn File_PB;
    }
}