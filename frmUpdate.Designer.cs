namespace JarrettVance.ChapterTools
{
    partial class frmUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.linkInfo = new System.Windows.Forms.LinkLabel();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update Available";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(29, 52);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(341, 23);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "A new version {0} was made available on {1}.";
            // 
            // linkInfo
            // 
            this.linkInfo.AutoSize = true;
            this.linkInfo.Location = new System.Drawing.Point(29, 113);
            this.linkInfo.Name = "linkInfo";
            this.linkInfo.Size = new System.Drawing.Size(52, 13);
            this.linkInfo.TabIndex = 2;
            this.linkInfo.TabStop = true;
            this.linkInfo.Text = "More Info";
            this.linkInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInfo_LinkClicked);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDownload.Location = new System.Drawing.Point(304, 90);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(66, 40);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Download";
            this.btnDownload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDownload.UseVisualStyleBackColor = true;
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSkip.Image = ((System.Drawing.Image)(resources.GetObject("btnSkip.Image")));
            this.btnSkip.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSkip.Location = new System.Drawing.Point(220, 91);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(66, 40);
            this.btnSkip.TabIndex = 4;
            this.btnSkip.Text = "Skip";
            this.btnSkip.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSkip.UseVisualStyleBackColor = true;
            // 
            // frmUpdate
            // 
            this.AcceptButton = this.btnDownload;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSkip;
            this.ClientSize = new System.Drawing.Size(389, 143);
            this.ControlBox = false;
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.linkInfo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChapterGrabber {0}";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.LinkLabel linkInfo;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnSkip;
    }
}