using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
			username = name;
			colors = Color.FromArgb(112, 224, 255);
		}

		private void Contact_Load(object sender, EventArgs e)
		{
			contactsToolStripMenuItem.Checked = true;
			contactsToolStripMenuItem.BackColor = colors;

			Data_bind(username);
		}

		public void Data_bind(string username)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers, GG_Friends where GG_Friends.username=@Username and GGusers.username=GG_Friends.friend_name", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			dataGridView1.DataSource = ds.Tables[0].DefaultView;

			int num = ds.Tables[0].Rows.Count;

			for(int i=0; i<num; i++)
			{
				bool state = (bool)ds.Tables[0].Rows[i][4];
				string sta= "offline";
				if(state)
				{
					sta = "online";
				}

				string nickname = ds.Tables[0].Rows[i][18].ToString();
				string sign = ds.Tables[0].Rows[i][9].ToString();

				friendlist.Items.Add(nickname + " | "+ sign + " | " + sta);
			}
			friendlist.EndUpdate();
		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{
			Add_friend add_Friend = new Add_friend(this, username);
			add_Friend.StartPosition = FormStartPosition.CenterScreen;
			add_Friend.Show();
		}

		private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			Homepage homepage = new Homepage(username);
			homepage.StartPosition = FormStartPosition.CenterScreen;
			homepage.Show();
		}

		private void NewsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			News news = new News(username);
			news.StartPosition = FormStartPosition.CenterScreen;
			news.Show();
		}

		private void UserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			User user = new User(username);
			user.StartPosition = FormStartPosition.CenterScreen;
			user.Show();
		}
		private void LogoutAccount()
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set state = 0 where username = '" + username + "'";
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
		}

		private void Contact_FormClosed(object sender, FormClosedEventArgs e)
		{
			LogoutAccount();
			Application.Exit();
		}

		private void Firendlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			string friend_name = friendlist.SelectedItem.ToString();
			MessageBox.Show(friend_name, "GG");

		}
	}
}
