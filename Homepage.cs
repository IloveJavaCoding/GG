using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace GG
{
    public partial class Homepage : Form
    {
        Functions functions;
        protected SqlConnection conn;
        protected string username = "";
        protected Color colors;
        private DataTable friends;

        public static ClientService client = new ClientService();
        public static Image image;
        public static string signature;

        public Homepage(string name)
        {
            InitializeComponent();

            username = name;
            functions = new Functions();
            conn = functions.conn;
            colors = functions.colors;
            image = CommonHandler.ChangeShape(CommonHandler.LoadImage(username, "user_avatar"), new Size(75, 75));
            signature = DatabaseHandler.SelectSignature(username);

            pictureBox1.Image = image;
            label1.Text = username;
            textBox2.Text = signature;
            friends = DatabaseHandler.SelectFriend(username).Copy();
            UpdateTalkingList();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            messageToolStripMenuItem.Checked = true;
            messageToolStripMenuItem.BackColor = colors;
        }

        /// <summary>
        /// 更新交谈队列
        /// </summary>
        public void UpdateTalkingList()
        {
            ArrayList contentList = new ArrayList();
            imageList1.Images.Clear();
            foreach (DataRow row in friends.Rows)
            {
                Image img = CommonHandler.ChangeShape(CommonHandler.LoadImage(row[0].ToString(), "user_avatar"), new Size(45, 45));
                imageList1.Images.Add(img);
                string latestMsg = row[0].ToString() + " says: " + DatabaseHandler.SelectLatestMessage(row[0].ToString(), username);
                if (latestMsg.Length > 30)
                    latestMsg = latestMsg.Substring(0, 30);
                contentList.Add(latestMsg);
            }

            UpdateListView(imageList1, contentList);
        }

        private void UpdateListView(ImageList imageList, ArrayList contentList)
        {
            listViewEx1.Items.Clear();
            listViewEx1.LargeImageList = imageList;

            listViewEx1.BeginUpdate();
            int i = 0;
            foreach (string content in contentList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = content;
                listViewEx1.Items.Add(lvi);
                i++;
            }
            listViewEx1.EndUpdate();
        }

        private void ContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Contact contact = new Contact(username)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            contact.Show();
        }

        private void NewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            News news = new News(username)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            news.Show();
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

        private void Homepage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                functions.Logout_Account(username);
                CommonHandler.SafelyExit();
            }
            else
                e.Cancel = true;
        }

        private void ListViewEx1_MouseClick(object sender, MouseEventArgs e)
        {
            string[] strArr = listViewEx1.SelectedItems[0].SubItems[0].Text.Split(':');
            strArr[0] = strArr[0].Remove(strArr[0].Length - 5);
            if (!Contact.chatKey.ContainsKey(strArr[0]))
            {
                Contact.chatKey.Add(strArr[0], new Chatroom(username, strArr[0]));
            }
            if (Contact.chatKey.Count == 1)
                Contact.chatKey.Values.First().StartPosition = FormStartPosition.CenterScreen;
            CommonHandler.UpdateShowing(strArr[0]);
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool find = false;
                foreach (DataRow row in friends.Rows)
                {
                    if (textBox1.Text.Equals(row[0].ToString()))
                    {
                        find = true;
                        if (!Contact.chatKey.ContainsKey(textBox1.Text))
                        {
                            Contact.chatKey.Add(textBox1.Text, new Chatroom(username, textBox1.Text));
                        }
                        if (Contact.chatKey.Count == 1)
                            Contact.chatKey.Values.First().StartPosition = FormStartPosition.CenterScreen;
                        CommonHandler.UpdateShowing(textBox1.Text);
                        textBox1.Text = "";
                        break;
                    }
                }
                if (!find)
                    MessageBox.Show("You don't have this friend!", "Warnning!");
            }

        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DatabaseHandler.UpdateSignature(username, textBox2.Text);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            User user = new User(username)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            user.Show();
        }
    }
}
