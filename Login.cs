﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GG
{
    public partial class Login : Form
    {
        private SqlConnection conn;

        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            conn = DatabaseHandler.conn;
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
            if (Homepage.client.success)
                homepage.Show();
            else
            {
                MessageBox.Show("Please contact administrator to get more information!", "Can't connect server!");
                CommonHandler.SafelyExit();
            }
        }

        private void UpdateAccount(string name)
        {
            string ip = NetworkHandler.GetLocalIP();
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

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                if (ds.Tables[0].Rows[0][3].ToString().Equals(CommonHandler.Get_hash(password.Text, ds.Tables[0].Rows[0][2].ToString())))
                {
                    Hide();
                    UpdateAccount(username.Text);
                    Go_to_homepage(username.Text);
                }
                else
                {
                    MessageBox.Show("Login fail!!!", "GG");
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                CommonHandler.SafelyExit();
            else
                e.Cancel = true;
        }
    }
}
