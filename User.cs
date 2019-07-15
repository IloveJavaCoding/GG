using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace GG
{
	public partial class User : Form
	{
		protected string username = "";
		protected Color colors;
		public User(string name)
		{
			InitializeComponent();
			username = name;
			colors = Color.FromArgb(112, 224, 255);
		}

		private void User_Load(object sender, EventArgs e)
		{
			userToolStripMenuItem.Checked = true;
			userToolStripMenuItem.BackColor = colors;
			
			Account_info_bind(username);
			Change_shap();

			string bgname = Get_bgname(username);
			if (!bgname.Equals(""))
			{
				Load_bgimg(bgname);
			}
		}

		private void MessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Homepage homepage = new Homepage(username);
			homepage.StartPosition = FormStartPosition.CenterScreen;
			homepage.Show();
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

		private void Account_info_bind(string name)
		{
			label1.Text = name;
			label2.Text = "Online";
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username=@Username", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = name;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			l_gender.Text = ds.Tables[0].Rows[0][5].ToString();
			l_age.Text = ds.Tables[0].Rows[0][6].ToString();
			l_birthday.Text = ds.Tables[0].Rows[0][7].ToString();
			l_address.Text = ds.Tables[0].Rows[0][8].ToString();
			signature.Text = ds.Tables[0].Rows[0][9].ToString();
			l_blood.Text = ds.Tables[0].Rows[0][10].ToString();

			cmd.Dispose();
			conn.Close();
		}

		private void Load_bgimg(string name)
		{
			WebClient webClient = new WebClient();
			
			//var bytes = webClient.DownloadData("MyDatabase/CourseData/" + name);
			//Image img = Image.FromStream(new MemoryStream(bytes));

			string path = Get_Folder_Path()+name;
			string url = "https://202.188.18.188:8888/" + name;
			//_ = WebRequest.Create(url);
			webClient.DownloadFile(@url, @path);
			Image img = Image.FromFile(path);
			pictureBox1.Image = img;
		}

		private string Get_Folder_Path()
		{
			string path = Application.StartupPath;
			string folder = Path.Combine(path, "Image");
			bool folderExist = Directory.Exists(folder);
			if (!folderExist)
			{
				try
				{
					Directory.CreateDirectory(folder);
				}
				catch
				{
					MessageBox.Show("No find!", "Exception");
				}
			}
			return folder+"/";
		}

		private string Get_bgname(string username)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = new SqlCommand("select * from GGusers where username=@Username", conn);
			cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			adapter.Fill(ds);

			return ds.Tables[0].Rows[0][13].ToString();
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			Edit_account edit_Account = new Edit_account(this, username);
			edit_Account.Show();
		}

		private void Change_password_Click(object sender, EventArgs e)
		{
			Change_password change = new Change_password(this, username);
			change.Show();
		}

		private void PictureBox2_DoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image|*.jpg;*.png";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Image img = Image.FromFile(openFileDialog.FileName);
				pictureBox2.Image = img;

				Change_shap();
			}
		}

		private void Change_bg_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image|*.jpg;*.png";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Image img = Image.FromFile(openFileDialog.FileName);
				pictureBox1.Image = img;
				string path = openFileDialog.FileName;
				Upload_img(path);
			}
		}

		private void Upload_img(string path)
		{
			WebClient webClient = new WebClient();
			webClient.UploadFile("https://localhost:44376/Home.aspx", "POST", path);
			
			Update_bgname(username, path.Substring(path.LastIndexOf("\\") + 1));
		}

		private void Update_bgname(string name,string bg)
		{
			SqlConnection conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			conn.Open();

			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set bgname = '"+ bg +"' where username = '" + name + "'";
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure to logout?", "GG", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				LogoutAccount();
				Application.Exit();
			}
		}

		private void Change_shap()
		{
			Image image = pictureBox2.Image;
			Image image1 = CutEllipse(image, new Rectangle(0, 0, 75, 75), new Size(75, 75));
			pictureBox2.Image = image1;
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

		public void Refresh_window(string username)
		{
			Account_info_bind(username);
		}

		private void User_FormClosed(object sender, FormClosedEventArgs e)
		{
			LogoutAccount();
			Application.Exit();
		}

	}
}
