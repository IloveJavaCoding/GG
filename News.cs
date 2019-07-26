using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG
{
    public partial class News : Form
    {
        private SqlConnection conn;
        protected string username = "";
        protected Color colors;

        News main;
        List<string> list = new List<string>();
        int count = -1;

        public News(string name)
        {
            InitializeComponent();
            username = name;

            conn = DatabaseHandler.conn;
            colors = Color.FromArgb(112, 224, 255);

            main = this;
            main.Width = 1200;
            main.Height = 800;
            list.Add(name);
            count++;
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.AllowWebBrowserDrop = false;
            this.webBrowser2.IsWebBrowserContextMenuEnabled = false;
            main = this;
            curUrl = "";
            this.webBrowser2.Navigate("www.ecns.cn/news/");

        }
        bool isRun;

        #region system
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
                DatabaseHandler.Logout(username);
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
        #endregion

        List<Link> linkList = new List<Link>();

        string curUrl;
        bool btn1 = false;
        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }

            if (e.Url.ToString() != webBrowser2.Url.ToString())
            {
                return;
            }

            if (curUrl == "")
            {
                Link newLink = new Link();
                newLink.Content = "Start";
                newLink.Size = this.webBrowser2.DocumentText.Length;
                newLink.Status = Link.LinkStatus.Complete;
                newLink.Name = this.webBrowser2.DocumentTitle;
                main = this;
                main.Text = this.webBrowser2.DocumentTitle;
                newLink.Url = e.Url.ToString();
                if (!btn1)
                {
                    list.Add(txtUrl.Text);
                    count++;
                }
                else
                {
                    btn1 = false;
                }
                //button1.Enabled = true;

            }


        }
        private void webBrowser2_NewWindow(object sender, CancelEventArgs e)
        {

            WebBrowser web = (WebBrowser)sender;
            list.Add(web.StatusText);
            count++;
            //if (checkBox1.Checked)
            //{
            //    main = this;
            //    News m = new News(web.StatusText, main.Width, main.Height);
            //    m.Show();
            //}
            //else
            //{
            //    //button1.Enabled = true;
            //    txtUrl.Text = web.StatusText;
            //    web.Navigate(web.StatusText);
            //    main = this;
            //    main.Text = web.DocumentTitle;
            //}

            e.Cancel = true;
        }



    }
    public class Link
    {
        public Link()
        {

        }

        public Link(string url, string content)
        {
            Url = url;
            Name = "";
            Content = content;
            Status = LinkStatus.Init;
            Size = 0;
        }

        public string Url;
        public string Name;
        public string Content;
        public LinkStatus Status;
        public long Size;
        public enum LinkStatus
        {
            Init,
            Loading,
            Complete,
            Error,
        }
    }
}
