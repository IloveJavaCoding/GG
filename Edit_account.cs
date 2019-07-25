using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GG
{
	public partial class Edit_account : Form
	{
		Functions functions;
		protected SqlConnection conn;

		private User main_info;
		protected string username;
		protected List<string> gender_list, blood_list;
		public Edit_account(User main_info, string username)
		{
			this.main_info = main_info;
			this.username = username;

			functions = new Functions();
			conn = functions.conn;
			InitializeComponent();
			gender_list = new List<string> { };
			gender_list.Add("Male");
			gender_list.Add("Female");

			blood_list = new List<string> { };
			blood_list.Add("Type O");
			blood_list.Add("Type A");
			blood_list.Add("Type B");
			blood_list.Add("Type AB");
			blood_list.Add("Other types");
		}

		private void Edit_account_Load(object sender, EventArgs e)
		{
			Account_info_bind(username);
	
			cb_gender.DataSource = gender_list;
			cb_blood.DataSource = blood_list;
		}

		private void Save_Click(object sender, EventArgs e)
		{
			Update_account_info(username);
			main_info.Refresh_window(username);
		}

		private void Account_info_bind(string name)
		{
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from user_info where username=@Username", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = name;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			cb_gender.Text = ds.Tables[0].Rows[0][5].ToString();
			tb_age.Text = ds.Tables[0].Rows[0][6].ToString();
			tb_birthday.Text = ds.Tables[0].Rows[0][7].ToString();
			tb_address.Text = ds.Tables[0].Rows[0][8].ToString();
			tb_signature.Text = ds.Tables[0].Rows[0][9].ToString();
			cb_blood.Text = ds.Tables[0].Rows[0][10].ToString();

			cmd.Dispose();
			conn.Close();
		}

		private void Update_account_info(string name)
		{
			conn.Open();

			SqlCommand cmd = new SqlCommand("update dbo.user_info set gender=@GN, age=@AG, birthday=@BD, address=@AD, signature=@SG, blood=@BL where username=@UN", conn);
			cmd.Parameters.Add("@GN", SqlDbType.VarChar, 10).Value = cb_gender.SelectedValue;
			cmd.Parameters.Add("@AG", SqlDbType.VarChar, 10).Value = tb_age.Text;
			cmd.Parameters.Add("@BD", SqlDbType.VarChar, 50).Value = tb_birthday.Text;
			cmd.Parameters.Add("@AD", SqlDbType.VarChar, 100).Value = tb_address.Text;
			cmd.Parameters.Add("@SG", SqlDbType.VarChar, 150).Value = tb_signature.Text;
			cmd.Parameters.Add("@BL", SqlDbType.VarChar, 50).Value = cb_blood.SelectedValue;

			cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = name;
			cmd.ExecuteNonQuery();
			MessageBox.Show("The change has been saved.", "GG");

			cmd.Dispose();
			conn.Close();
		}
	}
}
