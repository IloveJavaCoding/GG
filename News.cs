using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GG
{
    public partial class News : Form
    {
        Functions functions;
        private SqlConnection conn;
        protected string username = "";
        protected Color colors;

        public News(string name)
        {
            InitializeComponent();
            username = name;

            functions = new Functions();
            conn = functions.conn;
            colors = functions.colors;
        }

        private void News_Load(object sender, EventArgs e)
        {
            newsToolStripMenuItem.Checked = true;
            newsToolStripMenuItem.BackColor = colors;
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

        private void ContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Contact contact = new Contact(username)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            contact.Show();
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

        private void News_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                functions.Logout_Account(username);
                CommonHandler.SafelyExit();
            }
            else
                e.Cancel = true;
        }

        private void GGNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            GGNews GGnews = new GGNews(username);
            GGnews.StartPosition = FormStartPosition.CenterScreen;
            GGnews.Show();
        }
    }
}
