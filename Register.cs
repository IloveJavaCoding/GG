using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GG
{
	public partial class Register : Form
	{
		public const int SALT_BYTE_SIZE = 32;
		public const int HASH_BYTE_SIZE = 32;
		public const int PBKDF2_ITERATIONS = 1000;
		public Register()
		{
			InitializeComponent();
		}

		private void Register_Load(object sender, EventArgs e)
		{

		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (Valide(tb1.Text, tb2.Text, tb3.Text))
			{
				int num = Get_user_num() + 1;
				string ipv4 = Get_Host_IP();
				string salt = Get_salt();
				SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
				conn.Open();

				SqlCommand cmd = new SqlCommand("insert into GGusers(id,username,salt,hash,statue,ip,answer) values(" + num +",@UN, @SALT, @HASH,0,@IP,@AS)", conn);
				cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = tb1.Text;
				cmd.Parameters.Add("@SALT", SqlDbType.VarChar, 50).Value = salt;
				cmd.Parameters.Add("@HASH", SqlDbType.VarChar, 50).Value = Get_hash(tb2.Text,salt);
				cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50).Value = ipv4;
				cmd.Parameters.Add("@AS", SqlDbType.VarChar, 50).Value = tb4.Text;

				cmd.ExecuteNonQuery();
				cmd.Dispose();
				conn.Close();

				MessageBox.Show("Register successfully!", "STATE");

				ToHomePage(tb1.Text);
			}
		}

		private void ToHomePage(string name)
		{
			this.Hide();
			LoginAccount(name);
			Homepage homepage = new Homepage(name);
			homepage.StartPosition = FormStartPosition.CenterScreen;
			homepage.Show();
		}

		private string Get_Host_IP()
		{
			string ipv4 = "";
			string hostName = Dns.GetHostName();
			IPHostEntry iPHostEntry = Dns.GetHostEntry(hostName);
			for (int i = 0; i < iPHostEntry.AddressList.Length; i++)
			{
				if (iPHostEntry.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					ipv4 = iPHostEntry.AddressList[i].ToString();//IPv4
				}
			}
			return ipv4;
		}

		private int Get_user_num()
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers", conn);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			return ds.Tables[0].Rows.Count;
		}

		private bool Judge_username(string name)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username = @UN", conn);
			cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = name;
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			int num = ds.Tables[0].Rows.Count;
			if (num > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool Valide(string name, string passward, string cpassword)
		{
			if (name.Equals(""))
			{
				MessageBox.Show("Username cannot be empty!", "WARNING!");
				return false;
			}
			
			if (!Judge_username(name))
			{
				MessageBox.Show("This name has been used!", "WARNING!");
				return false;
			}
			
			if (passward.Equals(""))
			{
				MessageBox.Show("Password cannot be empty!", "WARNING!");
				return false;
			}
			if (passward.Length<8)
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

		private void Cb1_CheckedChanged(object sender, EventArgs e)
		{
			if (cb1.Checked)
			{
				tb2.PasswordChar = '\0';
			}
			else
			{
				tb2.PasswordChar = '*';
			}
		}

		private void Cb2_CheckedChanged(object sender, EventArgs e)
		{
			if (cb2.Checked)
			{
				tb3.PasswordChar = '\0';
			}
			else
			{
				tb3.PasswordChar = '*';
			}
		}

		private void Register_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			Login login = new Login();
			login.StartPosition = FormStartPosition.CenterScreen;
			login.Show();
		}

		private void LoginAccount(string name)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set statue = 1 where username = '" + name + "'";
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			conn.Close();
		}
	}
}
