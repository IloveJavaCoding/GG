﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace GG
{
	public partial class Add_friend : Form
	{
		Functions functions;
		protected SqlConnection conn;
		protected Contact main_info;
		protected string username;
		public Add_friend(Contact main_info, string username)
		{
			this.main_info = main_info;
			this.username = username;
			InitializeComponent();

			functions = new Functions();
			conn = functions.conn;
		}

		private void Search_Click(object sender, EventArgs e)
		{
			string friend_name = tb_input.Text;
			if (!friend_name.Equals(""))
			{
				Search_New_Friend(friend_name);
			}
		}

		private void Search_New_Friend(string search_name)
		{
			if (Validate_search(search_name))
			{
				conn.Open();

				SqlCommand cmd = new SqlCommand("select * from GGusers where username=@Username", conn);
				cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = search_name;

				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				adapter.Fill(ds);

				int num = ds.Tables[0].Rows.Count;
				if (num > 0)
				{
					p_info.Visible = true;
					Result_bind(ds);
				}
				else//no find
				{
					p_info.Visible = false;
					result.Visible = true;
					result.Text = "No find any users that match the condition! Please try again.";
				}
				cmd.Dispose();
				conn.Close();
			}
			else
			{
				result.Text = "No find any users that match the condition! Please try again.";
			}
		}

		private bool Validate_search(string search_name)
		{
			if (search_name.Equals(username))
			{
				return false;
			}

			if (Is_Friend(username, search_name))
			{
				return false;
			}
			return true;
		}

		private bool Is_Friend(string username, string search_name)
		{
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GG_Friends where username=@Username and friend_name=@FUN", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
			cmd.Parameters.Add("@FUN", SqlDbType.VarChar, 50).Value = search_name;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			int num = ds.Tables[0].Rows.Count;
			cmd.Dispose();
			conn.Close();

			if (num > 0)//is friend
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void Result_bind(DataSet data)
		{
			string portrait_name = data.Tables[0].Rows[0][14].ToString();
			if (!portrait_name.Equals(""))
			{
				Load_portrait(portrait_name);
			}
			else
			{
				Load_portrait("default2.jpg");
			}

			l_name.Text = data.Tables[0].Rows[0][1].ToString();
			string gender = data.Tables[0].Rows[0][5].ToString();
			if (gender.Equals(""))
			{
				gender = "...";
			}
			l_gender.Text = gender;

			string birthday = data.Tables[0].Rows[0][7].ToString();
			if (birthday.Equals(""))
			{
				birthday = "...";
			}
			l_birthday.Text = birthday;

			string sign = data.Tables[0].Rows[0][9].ToString();
			if (sign.Equals(""))
			{
				sign = "...";
			}
			l_signature.Text = sign;
		}

		private void Load_portrait(string filename)
		{
			WebClient webClient = new WebClient();
			string url = "http://localhost:55607/database/" + filename;
			var bytes = webClient.DownloadData(url);
			Image img = Image.FromStream(new MemoryStream(bytes));
			portrait.Image = img;

			functions.Change_shap(portrait);
		}


		private void Button1_Click(object sender, EventArgs e)
		{
			int num = Get_num_all_friends() + 1;
			Add_Firends(num, username, l_name.Text);//self
			num++;
			Add_Firends(num, l_name.Text, username);//friend

			MessageBox.Show("Add successfully!", "GG");

			main_info.Data_bind(username);
			p_info.Visible = false;
			result.Visible = false;
		}

		private void Add_Firends(int num, string username, string friendname)
		{
			conn.Open();

			SqlCommand cmd = new SqlCommand("insert into GG_Friends(id,username,friend_name,friend_nick) values(" + num + ",@UN, @FUN, @FNN)", conn);
			cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = username;
			cmd.Parameters.Add("@FUN", SqlDbType.VarChar, 50).Value = friendname;
			cmd.Parameters.Add("@FNN", SqlDbType.VarChar, 50).Value = friendname;//default

			cmd.ExecuteNonQuery();
			cmd.Dispose();
			conn.Close();
		}

		private int Get_num_all_friends()
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand("select * from GG_Friends", conn);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			cmd.Dispose();
			conn.Close();

			return ds.Tables[0].Rows.Count;
		}

		private void Add_friend_Load(object sender, EventArgs e)
		{

		}
	}
}
