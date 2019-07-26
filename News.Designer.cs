namespace GG
{
    partial class News
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chinaNewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gGNewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripMenuItem,
            this.contactToolStripMenuItem,
            this.newsToolStripMenuItem,
            this.userToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.messageToolStripMenuItem.Text = "Message";
            this.messageToolStripMenuItem.Click += new System.EventHandler(this.MessageToolStripMenuItem_Click);
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.contactToolStripMenuItem.Text = "Contact";
            this.contactToolStripMenuItem.Click += new System.EventHandler(this.ContactToolStripMenuItem_Click);
            // 
            // newsToolStripMenuItem
            // 
            this.newsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chinaNewsToolStripMenuItem,
            this.gGNewsToolStripMenuItem});
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.newsToolStripMenuItem.Text = "News";
            // 
            // chinaNewsToolStripMenuItem
            // 
            this.chinaNewsToolStripMenuItem.Name = "chinaNewsToolStripMenuItem";
            this.chinaNewsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.chinaNewsToolStripMenuItem.Text = "China News";
            // 
            // gGNewsToolStripMenuItem
            // 
            this.gGNewsToolStripMenuItem.Name = "gGNewsToolStripMenuItem";
            this.gGNewsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gGNewsToolStripMenuItem.Text = "GG News";
            this.gGNewsToolStripMenuItem.Click += new System.EventHandler(this.GGNewsToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.UserToolStripMenuItem_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 28);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1067, 534);
            this.webBrowser1.TabIndex = 1;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(0, 28);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(1067, 534);
            this.webBrowser2.TabIndex = 2;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(856, 0);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(100, 25);
            this.txtUrl.TabIndex = 3;
            this.txtUrl.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(979, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "news";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // News
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "News";
            this.Text = "China News";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.News_FormClosing);
            this.Load += new System.EventHandler(this.News_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chinaNewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gGNewsToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}