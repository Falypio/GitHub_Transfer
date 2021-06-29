namespace File_Transfer.WinForm
{
    partial class Help
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
            this.Help_RTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Help_RTB
            // 
            this.Help_RTB.Location = new System.Drawing.Point(12, 12);
            this.Help_RTB.Name = "Help_RTB";
            this.Help_RTB.ReadOnly = true;
            this.Help_RTB.Size = new System.Drawing.Size(352, 220);
            this.Help_RTB.TabIndex = 0;
            this.Help_RTB.Text = "";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 249);
            this.Controls.Add(this.Help_RTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Help";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Help_RTB;
    }
}