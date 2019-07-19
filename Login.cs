using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace GG
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		private void B_login_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(DatabaseHandler.connString_zsl);
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
				if(ds.Tables[0].Rows[0][3].ToString().Equals(CommonHandler.Get_hash(password.Text, ds.Tables[0].Rows[0][2].ToString())))
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
			string ip = NetworkHandler.GetLocalIP();
			SqlConnection conn = new SqlConnection(DatabaseHandler.connString_zsl);
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set statue = 1, ip = '"+ip+"' where username = '" + name + "'";
			cmd.ExecuteNonQuery();
		}

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
