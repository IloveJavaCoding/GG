using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GG
{
	public partial class User : Form
	{
		protected string username = "";
		protected Color colors;
		//protected Users user;
		public User(string name)
		{
			InitializeComponent();
			this.username = name;
			colors = Color.FromArgb(112, 224, 255);
		}

		private void User_Load(object sender, EventArgs e)
		{
			label1.Text = username;
			userToolStripMenuItem.Checked = true;
			userToolStripMenuItem.BackColor = colors;
			//user = Get_userinfo(username);
			label2.Text = "Online";
		}

		private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Homepage homepage = new Homepage(username);
			homepage.StartPosition = FormStartPosition.CenterScreen;
			homepage.Show();
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

		private void User_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Are you sure to logout?", "GG", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				LogoutAccount();
				Application.Exit();
			}
		}

		private void LogoutAccount()
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set statue = 0 where username = '" + username + "'";
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
		}

		private Users Get_userinfo(string name)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username=@Username", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = name;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			Users users = new Users();
			users.set_state((int)ds.Tables[0].Rows[0][4]);
			users.set_username(name);

			cmd.Dispose();
			conn.Close();

			return users;
		}
	}

	class Users
	{
		string username;
		int state;

		public Users() { }
		public void set_username(string name)
		{
			this.username = name;
		}

		public string get_username()
		{
			return username;
		}

		public void set_state(int state)
		{
			this.state = state;
		}

		public int get_state()
		{
			return state;
		}
	}
}
