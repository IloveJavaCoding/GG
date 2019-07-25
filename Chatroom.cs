using System;
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

        public Chatroom(string user, string friend)
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;

            localUser = user;
            remoteUser = friend;
            updateContent();
            Text = friend;
        }

        public void updateContent()
        {
            DataTable messageTable = DatabaseHandler.SelectMsg(localUser, remoteUser).Copy();
            foreach (DataRow row in messageTable.Rows)
            {
                textBox3.Text += row[0].ToString() + ": " + row[3].ToString() + "\r\n" + row[2] + "\r\n";
            }
        }

        public void newMessage(Dictionary<string, string> messageSet)
        {
            textBox3.Text += messageSet["sender"] + ": " + messageSet["time"] + "\r\n" + messageSet["value"] + "\r\n";
        }

        private void Send_Click(object sender, EventArgs e)
        {
            Homepage.client.SendMsg(localUser, "text", textBox4.Text, remoteUser, CommonHandler.GetCurrentTime().ToString());
        }

        private void Chatroom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
