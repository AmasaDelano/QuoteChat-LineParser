namespace QuoteChatLineParser
{
    partial class Main
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
            this.uploadButton = new System.Windows.Forms.Button();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(83, 12);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(103, 39);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "Upload File";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultsTextBox.Location = new System.Drawing.Point(13, 64);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ReadOnly = true;
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBox.Size = new System.Drawing.Size(255, 472);
            this.resultsTextBox.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 548);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.uploadButton);
            this.Name = "Main";
            this.Text = "Quote Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TextBox resultsTextBox;
    }
}

