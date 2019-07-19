using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GG
{
	public partial class Change_password : Form
	{
		private User main_info;
		protected string username;
		public const int SALT_BYTE_SIZE = 32;
		public const int HASH_BYTE_SIZE = 32;
		public const int PBKDF2_ITERATIONS = 1000;
		public Change_password(User main_info, string username)
		{
			this.main_info = main_info;
			this.username = username;
			InitializeComponent();
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
			string salt = Get_salt();
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set salt=@SALT, hash=@HASH where username = '" + name + "'";
			cmd.Parameters.Add("@SALT", SqlDbType.VarChar, 50).Value = salt;
			cmd.Parameters.Add("@HASH", SqlDbType.VarChar, 50).Value = Get_hash(password, salt);
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			conn.Close();
		}

		private bool Judge_password(string name, string password)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username = @UN", conn);
			cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = name;
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			string salt = ds.Tables[0].Rows[0][2].ToString();
			string hash = ds.Tables[0].Rows[0][3].ToString();
			if (Get_hash(password,salt).Equals(hash))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private string Get_salt()
		{
			RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
			byte[] salt = new byte[SALT_BYTE_SIZE];
			csprng.GetBytes(salt);

			return Convert.ToBase64String(salt, 0, 24); ;
		}

		private string Get_hash(string password, string str)
		{
			byte[] salt = Convert.FromBase64String(str);
			byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);

			return Convert.ToBase64String(hash, 0, 24);
		}

		private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
		{
			Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
			pbkdf2.IterationCount = iterations;
			return pbkdf2.GetBytes(outputBytes);
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
	}
}
