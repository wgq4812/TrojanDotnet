namespace FiddlerTools
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtShowLogs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtShowLogs
            // 
            this.txtShowLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShowLogs.Location = new System.Drawing.Point(0, 0);
            this.txtShowLogs.Multiline = true;
            this.txtShowLogs.Name = "txtShowLogs";
            this.txtShowLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShowLogs.Size = new System.Drawing.Size(1220, 792);
            this.txtShowLogs.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 792);
            this.Controls.Add(this.txtShowLogs);
            this.Name = "MainForm";
            this.Text = "解析Https";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShowLogs;
    }
}
