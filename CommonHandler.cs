using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GG
{
    class CommonHandler
    {
        private const int HASH_BYTE_SIZE = 32;
        private const int PBKDF2_ITERATIONS = 1000;
        private const int SALT_BYTE_SIZE = 32;

        /// <summary>
        /// 获取盐值
        /// </summary>
        /// <returns></returns>
        public static string Get_salt()
        {
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            return Convert.ToBase64String(salt, 0, 24); ;
        }

        /// <summary>
        /// 获取加盐哈希值
        /// </summary>
        /// <param name="password"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Get_hash(string password, string str)
        {
            byte[] salt = Convert.FromBase64String(str);
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);

            return Convert.ToBase64String(hash, 0, 24);
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns>当前时间</returns>
        public static DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

        /// <summary>
        /// 将信息内容转换为xml信息
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="content_type">内容类型</param>
        /// <param name="value">内容</param>
        /// <param name="time">发送时间</param>
        /// <param name="target">接收者</param>
        /// <returns>原生包含信息内容的xml字符串</returns>
        public static string CreateXmlString(string sender, string content_type, string value, string time, string target)
        {
            string content = "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>";
            //字符串"System"为系统保留ID
            if (sender.Equals("System"))
                content += "<message type=\"system\">";
            else
                content += "<message type=\"user\">";
            content += "<sender>" + sender + "</sender>";
            if (content_type.Equals("text"))
            {
                content += "<content type=\"text\">" +
                    "<value>" + value + "</value>" +
                    "<time>" + time + "</time></content>" +
                    "<target>" + target + "</target></message>";
            }

            return content;
        }

        /// <summary>
        /// 解析信息
        /// </summary>
        /// <param name="message">原生包含信息内容的xml字符串</param>
        /// <returns>返回一个messageSet，其中包含"sender","value","time","target"四个键</returns>
        public static Dictionary<string, string> ResolveMessage(string message)
        {
            Dictionary<string, string> messageSet = new Dictionary<string, string>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(message);
            XmlElement root = doc.DocumentElement;

            XmlNode sender = root.SelectSingleNode("/message/sender");
            messageSet.Add("sender", sender.InnerText);

            XmlNode content_type = root.SelectSingleNode("/message/content");
            if (content_type.Attributes["type"].InnerText.Equals("text"))
            {
                XmlNode value = root.SelectSingleNode("/message/content/value");
                XmlNode time = root.SelectSingleNode("/message/content/time");
                XmlNode target = root.SelectSingleNode("/message/target");

                messageSet.Add("value", value.InnerText);
                messageSet.Add("time", time.InnerText);
                messageSet.Add("target", target.InnerText);
            }

            return messageSet;
        }

        /// <summary>
        /// 将图片转换为Base64字符串
        /// </summary>
        /// <param name="ImagePath">基于CommonHandler.cs文件的图片路径</param>
        /// <returns></returns>
        public static string ImgToBase64String(string ImagePath)
        {
            try
            {
                Bitmap bmp = new Bitmap(ImagePath);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warnning!");
                return null;
            }
        }

        /// <summary>
        /// 将图片转换为Base64字符串
        /// </summary>
        /// <param name="img">源图片</param>
        /// <returns></returns>
        public static string ImgToBase64String(Image img)
        {
            try
            {
                Bitmap bmp = (Bitmap)img;

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warnning!");
                return null;
            }
        }

        public static Image Base64StringToImg(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            MemoryStream memStream = new MemoryStream(bytes);

            return Image.FromStream(memStream);
        }

        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="imgType">图片类型</param>
        /// <returns></returns>
        public static Image LoadImage(string name, string imgType)
        {
            var bytes = DatabaseHandler.SelectPicture(name, imgType);

            return Image.FromStream(new MemoryStream(bytes));
        }

        public static void UpdateFriendList(string username, string friendname)
        {
            if (!Contact.chatKey.ContainsKey(friendname))
            {
                Contact.chatKey.Add(friendname, new Chatroom(username, friendname));
            }
            Contact.chatKey[friendname].UpdateTalkingList();
            foreach (var item in Contact.chatKey)
            {
                if (item.Key.Equals(friendname))
                {
                    item.Value.watching = true;
                    item.Value.StartPosition = FormStartPosition.CenterScreen;
                    item.Value.Show();
                }
                else
                {
                    item.Value.watching = false;
                    item.Value.Hide();
                }
            }
        }


        public static Image ResizeImage(System.Drawing.Image img, Size size)
        {
            //获取图片宽度
            int sourceWidth = img.Width;
            //获取图片高度
            int sourceHeight = img.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //计算宽度的缩放比例
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //计算高度的缩放比例
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //期望的宽度
            int destWidth = (int)(sourceWidth * nPercent);
            //期望的高度
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //绘制图像
            g.DrawImage(img, 0, 0, destWidth, destHeight);
            g.Dispose();
            return b;
        }

        /// <summary>
        /// 改变图片形状
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rec">要求小于或等于size</param>
        /// <param name="size">要求大于或等于rec</param>
        /// <returns></returns>
        public static Image ChangeShape(Image img, Rectangle rec, Size size)
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

        public static void UpdateShowing(string friendname)
        {
            foreach (var item in Contact.chatKey)
            {
                if (item.Key.Equals(friendname))
                {
                    item.Value.watching = true;
                    foreach (var chat in Contact.chatKey)
                        chat.Value.Location = Contact.chatKey.Values.First().Location;
                    item.Value.Show();
                }
                else
                {
                    item.Value.watching = false;
                    item.Value.Hide();
                }
            }

            foreach (var item in Contact.chatKey)
                item.Value.UpdateTalkingList();
        }

        public static void SafelyExit()
        {
            try
            {
                Homepage.client.CloseClient();
                List<string> list = new List<string>(Contact.chatKey.Keys);
                for (int i = 0; i < Contact.chatKey.Count(); i++)
                    Contact.chatKey[list[i]].Close();
                Contact.chatKey.Clear();
                System.Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Warnning!");
                System.Environment.Exit(0);
            }
        }
    }
}
