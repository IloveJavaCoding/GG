using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
    public partial class Chatroom : Form
    {
        public static string localUser; //本地用户
        public string remoteUser; //远程用户
        public bool watching = false;

        public Chatroom(string user, string friend)
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;

            localUser = user;
            remoteUser = friend;

            Text = friend;
            watching = true;

            UpdateContent();
        }

        /// <summary>
        /// 更新历史消息
        /// </summary>
        private void UpdateContent()
        {
            DataTable messageTable = DatabaseHandler.SelectMsg(localUser, remoteUser).Copy();
            foreach (DataRow row in messageTable.Rows)
            {
                textBox3.Text += row[0].ToString() + ": " + row[3].ToString() + "\r\n" + row[2] + "\r\n";
            }
        }

        /// <summary>
        /// 更新交谈队列
        /// </summary>
        public void UpdateTalkingList()
        {
            ArrayList contentList = new ArrayList();
            imageList1.Images.Clear();
            foreach (string key in Contact.chatKey.Keys)
            {
                Image img = CommonHandler.LoadImage(key, "user_avatar");
                imageList1.Images.Add(img);
                string latestMsg = key + ":\n" + DatabaseHandler.SelectLatestMessage(key, localUser);
                if (latestMsg.Length > 30)
                    latestMsg = latestMsg.Substring(0, 30) + "...";
                contentList.Add(latestMsg);
            }

            UpdateListView(imageList1, contentList);
        }

        private void UpdateListView(ImageList imageList, ArrayList contentList)
        {
            string watchingKey = "";
            listView1.Items.Clear();
            listView1.SmallImageList = imageList;

            foreach (string key in Contact.chatKey.Keys)
                if (Contact.chatKey[key].watching)
                    watchingKey = key;

            listView1.BeginUpdate();
            int i = 0;
            foreach (string content in contentList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = content;
                listView1.Items.Add(lvi);
                i++;
            }
            listView1.EndUpdate();

            foreach (ListViewItem item in listView1.Items)
            {
                string[] strArr = item.Text.Split(':');
                if (strArr[0].Equals(watchingKey))
                {
                    item.Selected = true;
                    item.EnsureVisible();
                }
                listView1.Select();
            }
        }

        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            string[] strArr = listView1.SelectedItems[0].SubItems[0].Text.Split(':');
            CommonHandler.UpdateShowing(strArr[0]);
        }

        /// <summary>
        /// 更新新消息
        /// </summary>
        /// <param name="messageSet">新消息</param>
        public void NewMessage(Dictionary<string, string> messageSet)
        {
            textBox3.Text += messageSet["sender"] + ": " + messageSet["time"] + "\r\n" + messageSet["value"] + "\r\n";
        }

        private void Send_Click(object sender, EventArgs e)
        {
            SendMsg();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
        }

        private void TextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMsg();
            }
        }

        private void SendMsg()
        {
            if (textBox4.Text != "")
            {
                string time = CommonHandler.GetCurrentTime().ToString();
                Homepage.client.SendMsg(localUser, "text", textBox4.Text, remoteUser, time);
                textBox3.Text += localUser + ": " + time + "\r\n" + textBox4.Text + "\r\n";
                textBox4.Text = "";
            }
            else
                MessageBox.Show("Message can't be empty", "Warnning!");
        }

        private void Close_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>(Contact.chatKey.Keys);
            if (Contact.chatKey.Count() > 1)
            {
                Contact.chatKey.Remove(remoteUser);
                CommonHandler.UpdateShowing(Contact.chatKey.Keys.First());
            }
            else
            {
                Hide();
                Contact.chatKey.Remove(remoteUser);
            }
        }

        private void Chatroom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Contact.chatKey.Count() > 1)
            {
                if (MessageBox.Show("Existing mutiple windows, are you sure to exit?", "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Hide();
                    Contact.chatKey.Clear();
                }
                else
                    e.Cancel = true;
            }
            else
            {
                Hide();
                Contact.chatKey.Remove(remoteUser);
            }

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
        }
    }
}
