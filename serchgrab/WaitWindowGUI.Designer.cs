namespace serchgrab
{
    partial class WaitWindowGUI
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
            this.MessageLabel = new System.Windows.Forms.Label();
            this.Marque = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Location = new System.Drawing.Point(24, 3);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(276, 23);
            this.MessageLabel.TabIndex = 3;
            this.MessageLabel.Text = "Please wait ...";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Marque
            // 
            this.Marque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Marque.Location = new System.Drawing.Point(24, 37);
            this.Marque.MarqueeAnimationSpeed = 1;
            this.Marque.Name = "Marque";
            this.Marque.Size = new System.Drawing.Size(276, 12);
            this.Marque.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Marque.TabIndex = 2;
            // 
            // WaitWindowGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 52);
            this.ControlBox = false;
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.Marque);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitWindowGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WaitWindowGUI";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.ProgressBar Marque;
    }
}