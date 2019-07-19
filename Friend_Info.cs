using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace GG
{
	public partial class Friend_Info : Form
	{
		protected Contact main_info;
		protected string username;
		protected string friendname;
		public Friend_Info(Contact main_info, string username, string friendname)
		{
			this.main_info = main_info;
			this.username = username;
			this.friendname = friendname;
			InitializeComponent();
		}

		private void Friend_Info_Load(object sender, EventArgs e)
		{
			Backcolor_transparent();
			Data_Loading(username, friendname);
		}

		private void Backcolor_transparent()
		{
			bg_img.SendToBack();
			l_name.BackColor = Color.Transparent;
			l_name.Parent = bg_img;
			l_name.BringToFront();

			l_nick.BackColor = Color.Transparent;
			l_nick.Parent = bg_img;
			l_nick.BringToFront();

			l_sign.BackColor = Color.Transparent;
			l_sign.Parent = bg_img;
			l_sign.BringToFront();

			portrait_img.BackColor = Color.Transparent;
			portrait_img.Parent = bg_img;
			portrait_img.BringToFront();
		}

		private void Data_Loading(string username, string friendname)
		{
			SqlConnection conn = new SqlConnection(DatabaseHandler.connString_zsl);
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers, GG_Friends where GG_Friends.username=@Username and GG_Friends.friend_name=@FN and GGusers.username=GG_Friends.friend_name", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
			cmd.Parameters.Add("@FN", SqlDbType.VarChar, 50).Value = friendname;


			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			l_name.Text = friendname; 
			l_gender.Text = ds.Tables[0].Rows[0][5].ToString();
			l_birthday.Text = ds.Tables[0].Rows[0][7].ToString();
			l_nick.Text = ds.Tables[0].Rows[0][18].ToString();
			l_sign.Text = ds.Tables[0].Rows[0][9].ToString();

			string bgname = Get_bgname(friendname);
			if (bgname.Equals(""))
			{
				bgname = "default1.jpg";
			}
			bg_img.Image = Load_image(bgname);

			string portrait = Get_portraitname(friendname);
			if (portrait.Equals(""))
			{
				portrait = "default2.jpg";
			}
			portrait_img.Image = Load_image(portrait);
			Change_shap(portrait_img);
		}

		private Image Load_image(string filename)
		{
			WebClient webClient = new WebClient();
			string url = "http://localhost:55607/database/" + filename;
			var bytes = webClient.DownloadData(url);

			return Image.FromStream(new MemoryStream(bytes));
		}

		private string Get_bgname(string username)
		{
			SqlConnection conn = new SqlConnection(DatabaseHandler.connString_zsl);
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username=@Username", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			cmd.Dispose();
			conn.Close();

			return ds.Tables[0].Rows[0][13].ToString();
		}

		private string Get_portraitname(string username)
		{
			SqlConnection conn = new SqlConnection(DatabaseHandler.connString_zsl);
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username=@Username", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			cmd.Dispose();
			conn.Close();

			return ds.Tables[0].Rows[0][14].ToString();
		}

		private void Change_shap(PictureBox portrait_img)
		{
			Image image = portrait_img.Image;
			Image image1 = CutEllipse(image, new Rectangle(0, 0, 75, 75), new Size(75, 75));
			portrait_img.Image = image1;
		}

		private Image CutEllipse(Image img, Rectangle rec, Size size)
		{
			Bitmap bitmap = new Bitmap(size.Width, size.Height);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				using (TextureBrush br = new TextureBrush(img, System.Drawing.Drawing2D.WrapMode.Clamp, rec))
				{
					br.ScaleTransform(bitmap.Width / (float)rec.Width, bitmap.Height / (float)rec.Height);
					g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
					g.FillEllipse(br, new Rectangle(Point.Empty, size));
				}
			}

			return bitmap;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			tb_nick.Visible = true;
			tb_nick.Text = l_nick.Text;
		}

		private void Tb_nick_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				Update_nickneame(username, friendname, tb_nick.Text);
				l_nick.Text = tb_nick.Text;
				tb_nick.Visible = false;
				main_info.Data_bind(username);
			}
		}

		private void Update_nickneame(string username, string friendname, string nickname)
		{
			SqlConnection conn = new SqlConnection(DatabaseHandler.connString_zsl);
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GG_Friends set friend_nick = '"+ nickname +"' where username = '" + username + "' and friend_name ='"+friendname+"'";
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
		}

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chatroom chatroom = new Chatroom(username, friendname);
            chatroom.Show();
        }
    }
}
