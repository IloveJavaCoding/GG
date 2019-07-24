using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace GG
{
	public partial class Homepage : Form
	{
		Functions functions;
		protected SqlConnection conn;
		protected string username = "";
		protected Color colors;
		public Homepage(string name)
		{
			InitializeComponent();
			username = name;

			functions = new Functions();
			conn = functions.conn;
			colors = functions.colors;
		}

		private void Homepage_Load(object sender, EventArgs e)
		{
			label1.Text = username;
			ip.Text = functions.Get_Host_IP();

			messageToolStripMenuItem.Checked = true;
			messageToolStripMenuItem.BackColor = colors;
		}

		private void ContactsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			Contact contact = new Contact(username)
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			contact.Show();
		}

		private void NewsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			News news = new News(username)
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			news.Show();
		}

		private void UserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			User user = new User(username)
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			user.Show();
		}

		private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
		{
			functions.Logout_Account(username);
			Application.Exit();
		}
	}
}
