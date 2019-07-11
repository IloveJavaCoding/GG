using System;
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
	public partial class Homepage : Form
	{
		protected string username = "";
		protected Color colors;
		public Homepage(string name)
		{
			InitializeComponent();
			this.username = name;
			colors = Color.FromArgb(112,224,255);
		}

		private void Homepage_Load(object sender, EventArgs e)
		{
			label1.Text = username;
			messageToolStripMenuItem.Checked = true;
			messageToolStripMenuItem.BackColor = colors;
		}

		private void ContactsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Contact contact = new Contact(username);
			contact.StartPosition = FormStartPosition.CenterScreen;
			contact.Show();
		}

		private void NewsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			News news = new News(username);
			news.StartPosition = FormStartPosition.CenterScreen;
			news.Show();
		}

		private void UserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			User user = new User(username);
			user.StartPosition = FormStartPosition.CenterScreen;
			user.Show();
		}

		private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
