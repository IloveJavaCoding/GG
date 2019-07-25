using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

        /// <summary>
        /// 获取哈希值
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

        public ListView updateListView(ImageList imageList, ArrayList contentList)
        {
            ListView listView = new ListView();

            listView.View = View.LargeIcon;
            listView.LargeImageList = imageList;

            listView.BeginUpdate();
            int i = 0;
            foreach (string content in contentList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.Text = content;
                listView.Items.Add(lvi);
                i++;
            }
            listView.EndUpdate();

            return listView;
        }

        public static string ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);

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
    }
}
