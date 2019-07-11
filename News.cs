﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
	public partial class News : Form
	{
		protected string username = "";
		protected Color colors;
		public News(string name)
		{
			InitializeComponent();
			this.username = name;
			colors = Color.FromArgb(112, 224, 255);
		} 

		private void News_Load(object sender, EventArgs e)
		{
			newsToolStripMenuItem.Checked = true;
			newsToolStripMenuItem.BackColor = colors;
		}

		private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Homepage homepage = new Homepage(username);
			homepage.StartPosition = FormStartPosition.CenterScreen;
			homepage.Show();
		}

		private void ContactToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Contact contact = new Contact(username);
			contact.StartPosition = FormStartPosition.CenterScreen;
			contact.Show();
		}

		private void UserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			User user = new User(username);
			user.StartPosition = FormStartPosition.CenterScreen;
			user.Show();
		}

		private void News_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
