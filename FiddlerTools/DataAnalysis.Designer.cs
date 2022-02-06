namespace FiddlerTools
{
    partial class DataAnalysis
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
            this.txtOldData = new System.Windows.Forms.TextBox();
            this.txtNewData = new System.Windows.Forms.TextBox();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.txtSelectValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtOldData
            // 
            this.txtOldData.Location = new System.Drawing.Point(12, 12);
            this.txtOldData.Multiline = true;
            this.txtOldData.Name = "txtOldData";
            this.txtOldData.Size = new System.Drawing.Size(750, 230);
            this.txtOldData.TabIndex = 0;
            // 
            // txtNewData
            // 
            this.txtNewData.Location = new System.Drawing.Point(12, 311);
            this.txtNewData.Multiline = true;
            this.txtNewData.Name = "txtNewData";
            this.txtNewData.Size = new System.Drawing.Size(750, 326);
            this.txtNewData.TabIndex = 1;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(687, 269);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(75, 23);
            this.btnAnalysis.TabIndex = 2;
            this.btnAnalysis.Text = "解析";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // txtSelectValue
            // 
            this.txtSelectValue.FormattingEnabled = true;
            this.txtSelectValue.Items.AddRange(new object[] {
            "十六进制",
            "二进制",
            "解析数据"});
            this.txtSelectValue.Location = new System.Drawing.Point(560, 269);
            this.txtSelectValue.Name = "txtSelectValue";
            this.txtSelectValue.Size = new System.Drawing.Size(121, 25);
            this.txtSelectValue.TabIndex = 3;
            // 
            // DataAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 649);
            this.Controls.Add(this.txtSelectValue);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.txtNewData);
            this.Controls.Add(this.txtOldData);
            this.Name = "DataAnalysis";
            this.Text = "数据解析";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldData;
        private System.Windows.Forms.TextBox txtNewData;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.ComboBox txtSelectValue;
    }
}