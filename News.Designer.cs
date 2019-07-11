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
			this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripMenuItem,
            this.contactToolStripMenuItem,
            this.newsToolStripMenuItem,
            this.userToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 25);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// messageToolStripMenuItem
			// 
			this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
			this.messageToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
			this.messageToolStripMenuItem.Text = "Message";
			this.messageToolStripMenuItem.Click += new System.EventHandler(this.MessageToolStripMenuItem_Click);
			// 
			// contactToolStripMenuItem
			// 
			this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
			this.contactToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
			this.contactToolStripMenuItem.Text = "Contact";
			this.contactToolStripMenuItem.Click += new System.EventHandler(this.ContactToolStripMenuItem_Click);
			// 
			// newsToolStripMenuItem
			// 
			this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
			this.newsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
			this.newsToolStripMenuItem.Text = "News";
			// 
			// userToolStripMenuItem
			// 
			this.userToolStripMenuItem.Name = "userToolStripMenuItem";
			this.userToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
			this.userToolStripMenuItem.Text = "User";
			this.userToolStripMenuItem.Click += new System.EventHandler(this.UserToolStripMenuItem_Click);
			// 
			// News
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "News";
			this.Text = "Homepage";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.News_FormClosed);
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
	}
}