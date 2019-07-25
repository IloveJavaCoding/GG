using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GG
{
	public partial class Contact : Form
	{
		Functions functions;
		protected SqlConnection conn;
		protected string username = "";
		protected Color colors;

        public static Dictionary<string, Chatroom> chatKey = new Dictionary<string, Chatroom>();

        public Contact(string name)
		{
			InitializeComponent();
			username = name;

			functions = new Functions();
			conn = functions.conn;
			colors = functions.colors;
		}

		private void Contact_Load(object sender, EventArgs e)
		{
			contactsToolStripMenuItem.Checked = true;
			contactsToolStripMenuItem.BackColor = colors;

			Data_bind(username);
		}

		public void Data_bind(string username)
		{
			friendlist.Items.Clear();
            bool connUsing = true;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                connUsing = false;
            }

			SqlCommand cmd = new SqlCommand("select * from user_info, user_friends where user_friends.username=@Username and user_info.username=user_friends.friend_name", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);


			cmd.Dispose();
            if(!connUsing)
			    conn.Close();
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

				friendlist.Items.Add(nickname + " | " + sign + "|" + sta);
			}
			friendlist.Height = (num+1) * 16;
		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{
			Add_friend add_Friend = new Add_friend(this, username)
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			add_Friend.Show();
		}

		private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			Homepage homepage = new Homepage(username)
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			homepage.Show();
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

		private void Firendlist_SelectedIndexChanged(object sender, EventArgs e)
		{
			string item = friendlist.SelectedItem.ToString();
			string nickname = item.Substring(0,item.IndexOf("|")).Trim();
			string friend_name = Get_name_from_nick(username, nickname);

			Friend_Info friend_Info = new Friend_Info(this, username, friend_name);
			friend_Info.StartPosition = FormStartPosition.CenterScreen;
			friend_Info.Show();
		}

		private string Get_name_from_nick(string username,string nickname)
		{
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from user_friends where user_friends.username=@Username and user_friends.friend_nick=@NICK", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
			cmd.Parameters.Add("@NICK", SqlDbType.VarChar, 50).Value = nickname;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			cmd.Dispose();
			conn.Close();

			return ds.Tables[0].Rows[0][2].ToString();
		}

		private void Contact_FormClosed(object sender, FormClosedEventArgs e)
		{
			functions.Logout_Account(username);
			Application.Exit();
		}
	}
}
