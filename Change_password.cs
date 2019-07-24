using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GG
{
	public partial class Change_password : Form
	{
		Functions functions;
		protected SqlConnection conn;

		private User main_info;
		protected string username;
		
		public Change_password(User main_info, string username)
		{
			this.main_info = main_info;
			this.username = username;
			InitializeComponent();

			functions = new Functions();
			conn = functions.conn;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (!tb2.Text.Equals(""))
			{
				if (Judge_password(username, tb2.Text))
				{
					if(Valide_password(tb3.Text, tb4.Text))
					{
						Change_Password(username, tb3.Text);
						MessageBox.Show("Change password successfully!", "GG");
						Close();
					}
				}
				else
				{
					MessageBox.Show("The old password is wrong!", "GG");
				}
			}
			else
			{
				MessageBox.Show("Please input the old password!", "GG");
			}
		}

		private void Change_Password(string name, string password)
		{
			string salt = functions.Get_salt();
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set salt=@SALT, hash=@HASH where username = '" + name + "'";
			cmd.Parameters.Add("@SALT", SqlDbType.VarChar, 50).Value = salt;
			cmd.Parameters.Add("@HASH", SqlDbType.VarChar, 50).Value = functions.Get_hash(password, salt);
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			conn.Close();
		}

		private bool Judge_password(string name, string password)
		{
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username = @UN", conn);
			cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = name;
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			cmd.Dispose();
			conn.Close();
			string salt = ds.Tables[0].Rows[0][2].ToString();
			string hash = ds.Tables[0].Rows[0][3].ToString();
			if (functions.Get_hash(password,salt).Equals(hash))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool Valide_password(string passward, string cpassword)
		{
			if (passward.Equals(""))
			{
				MessageBox.Show("Password cannot be empty!", "WARNING!");
				return false;
			}
			if (passward.Length < 8)
			{
				MessageBox.Show("Password length cannot less than 8!", "WARNING!");
				return false;
			}
			if (!cpassword.Equals(passward))
			{
				MessageBox.Show("These two passwords don't match!", "WARNING!");
				return false;
			}

			return true;
		}

		private void Cb3_CheckedChanged(object sender, EventArgs e)
		{
			if (cb3.Checked)
			{
				tb2.PasswordChar = '\0';
			}
			else
			{
				tb2.PasswordChar = '*';
			}
		}

		private void Cb1_CheckedChanged(object sender, EventArgs e)
		{
			if (cb1.Checked)
			{
				tb3.PasswordChar = '\0';
			}
			else
			{
				tb3.PasswordChar = '*';
			}
		}

		private void Cb2_CheckedChanged(object sender, EventArgs e)
		{
			if (cb2.Checked)
			{
				tb4.PasswordChar = '\0';
			}
			else
			{
				tb4.PasswordChar = '*';
			}
		}

		private void Change_password_Load(object sender, EventArgs e)
		{

		}
	}
}
