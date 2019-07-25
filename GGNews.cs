using System;
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
        public GGNews(string username)
        {
            InitializeComponent();
            this.username = username;
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
    }
}
