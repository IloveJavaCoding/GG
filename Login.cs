using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
	public partial class Login : Form
	{
		public const int HASH_BYTE_SIZE = 32;
		public const int PBKDF2_ITERATIONS = 1000;

		public Login()
		{
			InitializeComponent();
		}

		private void B_login_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username=@Username", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username.Text;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			if(ds.Tables[0].Rows.Count == 0)
			{
				MessageBox.Show("Username no find!!!", "GG");
			}
			else
			{
				if(ds.Tables[0].Rows[0][3].ToString().Equals(Get_hash(password.Text, ds.Tables[0].Rows[0][2].ToString())))
				{
					this.Hide();
					LoginAccount(username.Text);
					Homepage homepage = new Homepage(username.Text);
					homepage.StartPosition = FormStartPosition.CenterScreen;
					homepage.Show();
				}
				else
				{
					MessageBox.Show("Login fail!!!", "GG");
				}
			}

			cmd.Dispose();
			conn.Close();
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

		private void Register_Click(object sender, EventArgs e)
		{
			this.Hide();
			Register register = new Register();
			register.StartPosition = FormStartPosition.CenterScreen;
			register.Show();
		}

		private void Cb1_CheckedChanged(object sender, EventArgs e)
		{
			if (cb1.Checked)
			{
				password.PasswordChar = '\0';
			}
			else
			{
				password.PasswordChar = '*';
			}
		}

		private void Login_Load(object sender, EventArgs e)
		{

		}

		private void LoginAccount(string name)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set statue = 1 where username = '" + name + "'";
			cmd.ExecuteNonQuery();
		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
