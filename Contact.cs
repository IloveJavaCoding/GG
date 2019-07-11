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
	public partial class Contact : Form
	{
		protected string username = "";
		protected Color colors;
		public Contact(string name)
		{
			InitializeComponent();
			this.username = name;
			colors = Color.FromArgb(112, 224, 255);
		}

		private void Contact_Load(object sender, EventArgs e)
		{
			contactsToolStripMenuItem.Checked = true;
			contactsToolStripMenuItem.BackColor = colors;
		}

		private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Homepage homepage = new Homepage(username);
			homepage.StartPosition = FormStartPosition.CenterScreen;
			homepage.Show();
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

		private void Contact_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
