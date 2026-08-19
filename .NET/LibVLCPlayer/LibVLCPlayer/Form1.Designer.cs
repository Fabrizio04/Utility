namespace LibVLCPlayer
{
    partial class Form1
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
            this.videoView1 = new LibVLCSharp.WinForms.VideoView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strumentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schermoInternoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoView1
            // 
            this.videoView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Location = new System.Drawing.Point(0, 27);
            this.videoView1.MediaPlayer = null;
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(800, 444);
            this.videoView1.TabIndex = 0;
            this.videoView1.Text = "videoView1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.strumentiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apriToolStripMenuItem,
            this.uRLToolStripMenuItem,
            this.eSCIToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.apriToolStripMenuItem.Text = "Apri File...";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.apriToolStripMenuItem_Click);
            // 
            // uRLToolStripMenuItem
            // 
            this.uRLToolStripMenuItem.Name = "uRLToolStripMenuItem";
            this.uRLToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.uRLToolStripMenuItem.Text = "Apri URL...";
            this.uRLToolStripMenuItem.Click += new System.EventHandler(this.uRLToolStripMenuItem_Click);
            // 
            // eSCIToolStripMenuItem
            // 
            this.eSCIToolStripMenuItem.Name = "eSCIToolStripMenuItem";
            this.eSCIToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.eSCIToolStripMenuItem.Text = "Esci";
            this.eSCIToolStripMenuItem.Click += new System.EventHandler(this.eSCIToolStripMenuItem_Click);
            // 
            // strumentiToolStripMenuItem
            // 
            this.strumentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schermoInternoToolStripMenuItem});
            this.strumentiToolStripMenuItem.Name = "strumentiToolStripMenuItem";
            this.strumentiToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.strumentiToolStripMenuItem.Text = "Strumenti";
            // 
            // schermoInternoToolStripMenuItem
            // 
            this.schermoInternoToolStripMenuItem.Name = "schermoInternoToolStripMenuItem";
            this.schermoInternoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.schermoInternoToolStripMenuItem.Text = "Schermo interno";
            this.schermoInternoToolStripMenuItem.Click += new System.EventHandler(this.schermoInternoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.videoView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LibVLCPlayer";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView videoView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uRLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eSCIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strumentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schermoInternoToolStripMenuItem;
    }
}
