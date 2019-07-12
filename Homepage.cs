using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
	public partial class Homepage : Form
	{
		protected string username = "";
		protected Color colors;
		public Homepage(string name)
		{
			InitializeComponent();
			this.username = name;
			colors = Color.FromArgb(112,224,255);
		}

		private void Homepage_Load(object sender, EventArgs e)
		{
			label1.Text = username;
			Get_Host_IP();
			messageToolStripMenuItem.Checked = true;
			messageToolStripMenuItem.BackColor = colors;
		}

		private void Get_Host_IP()
		{
			string hostName = Dns.GetHostName();
			hostname.Text = hostName;
			IPHostEntry iPHostEntry = Dns.GetHostEntry(hostName);
			for(int i=0; i < iPHostEntry.AddressList.Length; i++)
			{
				if(iPHostEntry.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					ip.Text = iPHostEntry.AddressList[i].ToString();//IPv4
				}
			}
			
			//IPHostEntry localhost = Dns.GetHostEntry(hostName);//ipv6;
			//IPHostEntry localhost = Dns.GetHostByName(hostName);//ipv4
			//IPAddress localaddr = localhost.AddressList[0];
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

		private void UserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			User user = new User(username);
			user.StartPosition = FormStartPosition.CenterScreen;
			user.Show();
		}

		private void LogoutAccount()
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set statue = 0 where username = '" + username + "'";
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
		}

		private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
		{
			LogoutAccount();
			Application.Exit();
		}
	}
}
