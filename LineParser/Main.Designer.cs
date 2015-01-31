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
            this.quoteButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(66, 10);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(2);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(82, 32);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "Upload File";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // quoteButtonPanel
            // 
            this.quoteButtonPanel.AutoScroll = true;
            this.quoteButtonPanel.ColumnCount = 1;
            this.quoteButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.quoteButtonPanel.Location = new System.Drawing.Point(7, 47);
            this.quoteButtonPanel.Name = "quoteButtonPanel";
            this.quoteButtonPanel.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.quoteButtonPanel.RowCount = 1;
            this.quoteButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.quoteButtonPanel.Size = new System.Drawing.Size(220, 386);
            this.quoteButtonPanel.TabIndex = 3;
            // 
            // vlcControl
            // 
            this.vlcControl.Location = new System.Drawing.Point(233, 12);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Rate = 0F;
            this.vlcControl.Size = new System.Drawing.Size(472, 421);
            this.vlcControl.TabIndex = 4;
            this.vlcControl.Text = "vlcControl";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 445);
            this.Controls.Add(this.vlcControl);
            this.Controls.Add(this.quoteButtonPanel);
            this.Controls.Add(this.uploadButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Quote Chat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TableLayoutPanel quoteButtonPanel;
        private Vlc.DotNet.Forms.VlcControl vlcControl;
    }
}

