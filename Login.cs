using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GG
{
	public partial class Login : Form
	{
		Functions functions; 
		private SqlConnection conn;

		public Login()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterScreen;
			functions = new Functions();
			conn = functions.conn;
		}

		private void B_login_Click(object sender, EventArgs e)
		{
            ValidateAccount();
        }

		private void Go_to_homepage(string username)
		{
			Homepage homepage = new Homepage(username)
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			homepage.Show();
		}

		private void Login_Account(string name)
		{
			string ip = functions.Get_Host_IP();
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.user_info set status = 1, ip = '" + ip + "' where username = '" + name + "'";
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
		}

		private void Register_Click(object sender, EventArgs e)
		{
			this.Hide();
			Register register = new Register
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			register.Show();
		}

		private void Forget_pass_Click(object sender, EventArgs e)
		{
			this.Hide();
			Forget_password forget = new Forget_password
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			forget.Show();
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

		private void Login_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ValidateAccount();
            }
        }

        private void ValidateAccount()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from user_info where username=@Username", conn);
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            cmd.Dispose();
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Username no find!!!", "GG");
            }
            else
            {
                if (ds.Tables[0].Rows[0][3].ToString().Equals(functions.Get_hash(password.Text, ds.Tables[0].Rows[0][2].ToString())))
                {
                    Hide();
                    Login_Account(username.Text);
                    Go_to_homepage(username.Text);
                }
                else
                {
                    MessageBox.Show("Login fail!!!", "GG");
                }
            }
        }
    }
}
