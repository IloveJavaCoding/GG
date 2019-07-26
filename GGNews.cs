using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
    public partial class GGNews : Form
    {
        protected string username;
        private bool shown = false;
        private bool clicked = false;
        private bool clicked1 = false;
        private Image titleImage;
        ArrayList releventUsers = new ArrayList();

        public GGNews(string username)
        {
            InitializeComponent();
            this.username = username;

            pictureBox1.Image = Homepage.image;
            label2.Text = username;
            textBox2.Text = Homepage.signature;
            pictureBox7.Image = CommonHandler.ResizeImage(new Bitmap("../../Image/left_arrow.png"), new Size(25, 25));
            pictureBox8.Image = CommonHandler.ResizeImage(new Bitmap("../../Image/right_arrow.png"), new Size(25, 25));

            LoadNews();
        }

        private void LoadNews()
        {
            GetReleventUser(username);
            Random random = new Random();
            int i = random.Next(releventUsers.Count);
            DataTable newsTable = DatabaseHandler.SelectNews(releventUsers[i].ToString());
            if (newsTable.Rows.Count > 0)
            {
                i = random.Next(newsTable.Rows.Count);
                DataRow news = newsTable.Rows[i];
                pictureBox5.Image = CommonHandler.ChangeShape(CommonHandler.LoadImage(news[1].ToString(), "user_avatar"), new Rectangle(0, 0, 75, 75), new Size(75, 75));
                label3.Text = news[1].ToString();
                label4.Text = news[3].ToString();
                label5.Text = news[2].ToString();
                pictureBox6.Image = CommonHandler.Base64StringToImg(news[4].ToString());
            }
        }

        private void GetReleventUser(string username)
        {
            releventUsers.Add(username);
            DataTable friendTable = DatabaseHandler.SelectFriend(username).Copy();
            foreach (DataRow row in friendTable.Rows)
                releventUsers.Add(row[0].ToString());
        }

        private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Homepage homepage = new Homepage(username)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            homepage.Show();
        }

        private void UserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            User user = new User(username)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            user.Show();
        }

        private void ContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Contact contact = new Contact(username);
            contact.StartPosition = FormStartPosition.CenterScreen;
            contact.Show();
        }

        private void ChinaNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            News news = new News(username)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            news.Show();
        }

        private void GGNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            GGNews GGnews = new GGNews(username);
            GGnews.StartPosition = FormStartPosition.CenterScreen;
            GGnews.Show();
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!shown)
            {
                textBox1.Text = "";
                textBox1.Multiline = true;
                textBox1.ForeColor = Color.Black;
                textBox1.Size = new Size(241, 60);
                ShowButton();
                shown = true;
            }
        }

        private void ShowButton()
        {
            button1.Location = new Point(button1.Location.X, button1.Location.Y + 40);
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 40);
            button1.Visible = true;
            pictureBox2.Visible = true;

            Bitmap bitmap = new Bitmap("../../Image/picture_icon.png");
            pictureBox2.Image = CommonHandler.ResizeImage(bitmap, new Size(25, 25));
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (!clicked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image|*.jpg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox2.Location.Y + 25);
                    pictureBox4.Location = new Point(pictureBox4.Location.X, pictureBox2.Location.Y + 25);

                    pictureBox3.Visible = true;
                    titleImage = CommonHandler.ResizeImage(Image.FromFile(openFileDialog.FileName), new Size(241, 142));
                    pictureBox3.Image = CommonHandler.ResizeImage(titleImage, new Size(75, 75));
                    pictureBox4.Visible = true;
                    Bitmap bitmap = new Bitmap("../../Image/cross.png");
                    pictureBox4.Image = CommonHandler.ResizeImage(bitmap, new Size(10, 10));
                    clicked = true;
                }
            }
        }

        private void BackToInit()
        {
            pictureBox2.Visible = false;
            button1.Visible = false;

            button1.Location = new Point(button1.Location.X, button1.Location.Y - 40);
            pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 40);

            textBox1.Size = new Size(241, 19);
            textBox1.ForeColor = Color.Silver;
            textBox1.Multiline = false;
            textBox1.Text = "Say something...";

            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox3.Dispose();
            pictureBox4.Dispose();

            shown = false;
            clicked = false;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox3.Dispose();
            pictureBox4.Dispose();

            clicked = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image == null || pictureBox3.IsDisposed)
                DatabaseHandler.InsertNews(username, textBox1.Text, "");
            else
                DatabaseHandler.InsertNews(username, textBox1.Text, CommonHandler.ImgToBase64String(titleImage));
            BackToInit();
        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            if (!clicked1)
            {
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "";
                clicked1 = true;
            }
        }

        private void GGNews_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DatabaseHandler.Logout(username);
                CommonHandler.SafelyExit();
            }
            else
                e.Cancel = true;
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            LoadNews();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            LoadNews();
        }
    }
}
