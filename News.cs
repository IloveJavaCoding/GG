using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
	public partial class News : Form
	{
		protected string username = "";
		protected Color colors;

        News main;
        List<string> list = new List<string>();
        int count = -1;
        public News(string name = "www.bbc.com/news", int w = 1200, int h = 800)
        {
            InitializeComponent();
            username = name;
            colors = Color.FromArgb(112, 224, 255);
            main = this;
            main.Width = w;
            main.Height = h;
            //list.Add(name);
            //count++;
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            main = this;
            curUrl = "";
            this.webBrowser1.Navigate(name);

        }

        private void News_Load(object sender, EventArgs e)
		{
			newsToolStripMenuItem.Checked = true;
			newsToolStripMenuItem.BackColor = colors;
		}

		private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			Homepage homepage = new Homepage(username);


			homepage.StartPosition = FormStartPosition.CenterScreen;
			homepage.Show();
		}

		private void ContactToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			Contact contact = new Contact(username);
			contact.StartPosition = FormStartPosition.CenterScreen;
			contact.Show();
		}

		private void UserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Hide();
			User user = new User(username);
			user.StartPosition = FormStartPosition.CenterScreen;
			user.Show();
		}

		private void LogoutAccount()
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set state = 0 where username = '" + username + "'";
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
		}

		private void News_FormClosed(object sender, FormClosedEventArgs e)
		{
			LogoutAccount();
			Application.Exit();
		}

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
        bool isRun;


        private void Run()
        {
        }
        List<Link> linkList = new List<Link>();

        string curUrl;
        bool btn1 = false;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }

            if (e.Url.ToString() != webBrowser1.Url.ToString())
            {
                return;
            }

            if (curUrl == "")
            {
                Link newLink = new Link();
                newLink.Content = "起始页";
                newLink.Size = this.webBrowser1.DocumentText.Length;
                newLink.Status = Link.LinkStatus.Complete;
                newLink.Name = this.webBrowser1.DocumentTitle;
                main = this;
                main.Text = this.webBrowser1.DocumentTitle;
                newLink.Url = e.Url.ToString();
                button1.Enabled = true;
            }


        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (list.Count > 1)
                {
                    btn1 = true;
                    button2.Enabled = true;
                    webBrowser1.Navigate(list[--count]);
                }
            }
            catch
            {
                webBrowser1.Navigate(list[0]);
                list.Clear();
                count = -1;
                button1.Enabled = false;
                button2.Enabled = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((list.Count - 2) > count)
                {
                    btn1 = true;
                    button1.Enabled = true;
                    webBrowser1.Navigate(list[++count]);
                }
            }
            catch
            {
                webBrowser1.Navigate(list[0]);
                list.Clear();
                count = -1;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }
        */
        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            Run();
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
