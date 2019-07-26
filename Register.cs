using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GG
{
	public partial class Register : Form
	{
		protected SqlConnection conn;

		public Register()
		{
			InitializeComponent();
			conn = DatabaseHandler.conn;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (Valide(tb1.Text, tb2.Text, tb3.Text))
			{
				string ipv4 = NetworkHandler.GetLocalIP();
				string salt = CommonHandler.Get_salt();
				conn.Open();

				SqlCommand cmd = new SqlCommand("insert into user_info(username,salt,hash,status,ip,answer) values(@UN, @SALT, @HASH,0,@IP,@AS)", conn);
				cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = tb1.Text;
				cmd.Parameters.Add("@SALT", SqlDbType.VarChar, 50).Value = salt;
				cmd.Parameters.Add("@HASH", SqlDbType.VarChar, 50).Value = CommonHandler.Get_hash(tb2.Text,salt);
				cmd.Parameters.Add("@IP", SqlDbType.VarChar, 50).Value = ipv4;
				cmd.Parameters.Add("@AS", SqlDbType.VarChar, 50).Value = tb4.Text;

				cmd.ExecuteNonQuery();
				cmd.Dispose();

                Bitmap bitmap = new Bitmap("../../Image/default_avatar.png");
                bitmap = (Bitmap)CommonHandler.ResizeImage(bitmap, new Size(75, 75));
                string avatarStr = CommonHandler.ImgToBase64String(bitmap);
                string backgroundStr = CommonHandler.ImgToBase64String("../../Image/default_background.png");

                SqlCommand insert = new SqlCommand("insert into user_picture (username, user_avatar, user_background) values(@UN, @UA, @UB)", conn);
                insert.Parameters.Add("@UN", SqlDbType.VarChar).Value = tb1.Text;
                insert.Parameters.Add("@UA", SqlDbType.VarChar).Value = avatarStr;
                insert.Parameters.Add("@UB", SqlDbType.VarChar).Value = backgroundStr;

                insert.ExecuteNonQuery();
                insert.Dispose();

				conn.Close();

				MessageBox.Show("Register successfully!", "STATE");

				To_HomePage(tb1.Text);
			}
		}

		private void To_HomePage(string username)
		{
			Hide();
			LoginAccount(username);
			Homepage homepage = new Homepage(username)
			{
				StartPosition = FormStartPosition.CenterScreen
			};
			homepage.Show();
		}

		private bool Judge_username(string name)
		{
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from user_info where username = @UN", conn);
			cmd.Parameters.Add("@UN", SqlDbType.VarChar, 50).Value = name;
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			int num = ds.Tables[0].Rows.Count;
            ds.Dispose();
            adapter.Dispose();
            conn.Close();

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

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			Login login = new Login();
			login.StartPosition = FormStartPosition.CenterScreen;
			login.Show();
		}

		private void LoginAccount(string name)
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.user_info set status = 1 where username = '" + name + "'";
			cmd.ExecuteNonQuery();
			cmd.Dispose();
			conn.Close();
		}

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                CommonHandler.SafelyExit();
            else
                e.Cancel = true;
        }
    }
}
