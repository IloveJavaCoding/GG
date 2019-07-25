using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace GG
{
    public partial class User : Form
    {
        Functions functions;
        protected SqlConnection conn;

        protected string username = "";
        protected Color colors;
        public User(string name)
        {
            InitializeComponent();
            functions = new Functions();
            conn = functions.conn;
            username = name;
            colors = functions.colors;
        }

        private void User_Load(object sender, EventArgs e)
        {
            userToolStripMenuItem.Checked = true;
            userToolStripMenuItem.BackColor = colors;

            Account_info_bind(username);

            Load_imgs();
        }

        private void Load_imgs()
        {
            pictureBox1.Image = CommonHandler.LoadImage(username, "user_background");
            pictureBox2.Image = CommonHandler.LoadImage(username, "user_avatar");
            pictureBox2.Image = functions.Change_shap(CommonHandler.ResizeImage(pictureBox2.Image, new Size(75, 75)));
        }

        private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage(username);
            homepage.StartPosition = FormStartPosition.CenterScreen;
            homepage.Show();
        }

        private void ContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contact contact = new Contact(username);
            contact.StartPosition = FormStartPosition.CenterScreen;
            contact.Show();
        }

        private void NewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            News news = new News(username);
            news.StartPosition = FormStartPosition.CenterScreen;
            news.Show();
        }

        private void Account_info_bind(string name)
        {
            label1.Text = name;
            label2.Text = "Online";

            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from user_info where username=@Username", conn);
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = name;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            l_gender.Text = ds.Tables[0].Rows[0][5].ToString();
            l_age.Text = ds.Tables[0].Rows[0][6].ToString();
            l_birthday.Text = ds.Tables[0].Rows[0][7].ToString();
            l_address.Text = ds.Tables[0].Rows[0][8].ToString();
            signature.Text = ds.Tables[0].Rows[0][9].ToString();
            l_blood.Text = ds.Tables[0].Rows[0][10].ToString();

            cmd.Dispose();
            conn.Close();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Edit_account edit_Account = new Edit_account(this, username);
            edit_Account.Show();
        }

        private void Change_password_Click(object sender, EventArgs e)
        {
            Change_password change = new Change_password(this, username);
            change.Show();
        }

        private void PictureBox2_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = CommonHandler.ResizeImage(Image.FromFile(openFileDialog.FileName), new Size(75, 75));
                DatabaseHandler.UpdatePicture(username, CommonHandler.ImgToBase64String(pictureBox2.Image), "user_avatar");
                pictureBox2.Image = functions.Change_shap(pictureBox2.Image);
            }
        }

        private void Change_bg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                DatabaseHandler.UpdatePicture(username, CommonHandler.ImgToBase64String(pictureBox1.Image), "user_background");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?", "GG", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                functions.Logout_Account(username);
                Homepage.client.CloseClient();
                foreach (var item in Contact.chatKey)
                    item.Value.Close();
                Contact.chatKey.Clear();
            }

            Login loginPage = new Login();
            Hide();
            loginPage.Show();
        }

        public void Refresh_window(string username)
        {
            Account_info_bind(username);
        }

        private void User_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                functions.Logout_Account(username);
                CommonHandler.SafelyExit();
            }
            else
                e.Cancel = true;
        }
    }
}
