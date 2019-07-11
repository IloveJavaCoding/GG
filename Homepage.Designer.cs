namespace GG
{
	partial class Homepage
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
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(678, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripMenuItem,
            this.contactsToolStripMenuItem,
            this.newsToolStripMenuItem,
            this.userToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 25);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// messageToolStripMenuItem
			// 
			this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
			this.messageToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
			this.messageToolStripMenuItem.Text = "Message";
			// 
			// contactsToolStripMenuItem
			// 
			this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
			this.contactsToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
			this.contactsToolStripMenuItem.Text = "Contacts";
			this.contactsToolStripMenuItem.Click += new System.EventHandler(this.ContactsToolStripMenuItem_Click);
			// 
			// newsToolStripMenuItem
			// 
			this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
			this.newsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
			this.newsToolStripMenuItem.Text = "News";
			this.newsToolStripMenuItem.Click += new System.EventHandler(this.NewsToolStripMenuItem_Click);
			// 
			// userToolStripMenuItem
			// 
			this.userToolStripMenuItem.Name = "userToolStripMenuItem";
			this.userToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
			this.userToolStripMenuItem.Text = "User";
			this.userToolStripMenuItem.Click += new System.EventHandler(this.UserToolStripMenuItem_Click);
			// 
			// Homepage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Homepage";
			this.Text = "Homepage";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Homepage_FormClosed);
			this.Load += new System.EventHandler(this.Homepage_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
	}
}