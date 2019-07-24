using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GG
{
	class Functions
	{
		public SqlConnection conn;
		public Color colors;
		public const int SALT_BYTE_SIZE = 32;
		public const int HASH_BYTE_SIZE = 32;
		public const int PBKDF2_ITERATIONS = 1000;

		public Functions()
		{
			conn = new SqlConnection("Server=NEPALESE\\SQLEXPRESS;database=mydatabase;UId=Nepalese;password=zsl142857");
			colors = Color.FromArgb(112, 224, 255);
		}

		public string Get_Host_IP()
		{
			string ipv4 = "";
			string hostName = Dns.GetHostName();
			IPHostEntry iPHostEntry = Dns.GetHostEntry(hostName);
			for (int i = 0; i < iPHostEntry.AddressList.Length; i++)
			{
				if (iPHostEntry.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					ipv4 = iPHostEntry.AddressList[i].ToString();//IPv4
				}
			}
			return ipv4;
		}

		public string Get_salt()
		{
			RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
			byte[] salt = new byte[SALT_BYTE_SIZE];
			csprng.GetBytes(salt);

			return Convert.ToBase64String(salt, 0, 24); ;
		}

		public string Get_hash(string password, string str)
		{
			byte[] salt = Convert.FromBase64String(str);
			byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);

			return Convert.ToBase64String(hash, 0, 24);
		}

		public static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
		{
			Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
			pbkdf2.IterationCount = iterations;
			return pbkdf2.GetBytes(outputBytes);
		}

		public void Change_shap(PictureBox portrait_img)
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



		public void Logout_Account(string username)
		{
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = "update dbo.GGusers set state = 0 where username = '" + username + "'";
			cmd.ExecuteNonQuery();

			cmd.Dispose();
			conn.Close();
		}
	}
}
