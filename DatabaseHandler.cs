using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG
{
    class DatabaseHandler
    {
        public static readonly SqlConnection conn
            = new SqlConnection(@"Server=MRD;Database=IMS;UId=admin;Password=aaaa");

        /// <summary>
        /// 选取相关用户的消息记录
        /// </summary>
        /// <param name="localUser">本地用户</param>
        /// <param name="remoteUser">远程用户</param>
        /// <returns>数据表</returns>
        public static DataTable SelectMsg(string localUser, string remoteUser)
        {
            conn.Open();
            SqlCommand selectMsg = new SqlCommand("select sender,target,value,time,value_type from message " +
                "where (sender = @LOCAL AND target = @REMOTE OR (sender = @REMOTE AND target = @LOCAL))", conn);
            selectMsg.Parameters.Add("@LOCAL", SqlDbType.VarChar).Value = localUser;
            selectMsg.Parameters.Add("@REMOTE", SqlDbType.VarChar).Value = remoteUser;

            SqlDataAdapter adpter = new SqlDataAdapter(selectMsg);
            DataSet ds = new DataSet();
            adpter.Fill(ds, "message");
            DataTable messageTable = ds.Tables["message"];

            adpter.Dispose();
            ds.Dispose();
            selectMsg.Dispose();
            conn.Close();

            return messageTable;
        }

        /// <summary>
        /// 更新用户图片
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pictureStr">图片的Base字符串</param>
        /// <param name="pictureType">图片类型</param>
        public static void UpdatePicture(string username, string pictureStr, string pictureType)
        {
            conn.Open();
            SqlCommand update = conn.CreateCommand();
            update.CommandType = CommandType.Text;
            if (pictureType.Equals("user_avatar"))
                update.CommandText = "update user_picture set user_avatar = @VALUE where username = @UN";
            else
                update.CommandText = "update user_picture set user_background = @VALUE where username = @UN";
            update.Parameters.Add("@VALUE", SqlDbType.VarChar).Value = pictureStr;
            update.Parameters.Add("@UN", SqlDbType.VarChar).Value = username;

            update.ExecuteNonQuery();

            update.Dispose();
            conn.Close();
        }

        /// <summary>
        /// 从数据库中提取图片
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pictureType">图片类型</param>
        /// <returns></returns>
        public static byte[] SelectPicture(string username, string pictureType)
        {
            conn.Open();
            SqlCommand select = conn.CreateCommand();
            select.CommandType = CommandType.Text;
            if (pictureType.Equals("user_avatar"))
                select.CommandText = "select user_avatar from user_picture where username = @UN";
            else
                select.CommandText = "select user_background from user_picture where username = @UN";
            select.Parameters.Add("@UN", SqlDbType.VarChar).Value = username;

            SqlDataAdapter adpter = new SqlDataAdapter(select);
            DataSet ds = new DataSet();
            adpter.Fill(ds);

            string value = ds.Tables[0].Rows[0][0].ToString();

            adpter.Dispose();
            ds.Dispose();
            select.Dispose();
            conn.Close();

            return Convert.FromBase64String(value);
        }

        public static string SelectLatestMessage(string sender, string receiver)
        {
            conn.Open();
            SqlCommand select = new SqlCommand("select top 1 * from message where sender = @SENDER AND target = @TARGET order by time desc", conn);
            select.Parameters.Add("@SENDER", SqlDbType.VarChar).Value = sender;
            select.Parameters.Add("@TARGET", SqlDbType.VarChar).Value = receiver;

            SqlDataAdapter adpter = new SqlDataAdapter(select);
            DataSet ds = new DataSet();
            adpter.Fill(ds);

            string latestMsg;
            if (ds.Tables[0].Rows.Count != 0)
                latestMsg = ds.Tables[0].Rows[0][4].ToString();
            else
                latestMsg = "";

            adpter.Dispose();
            ds.Dispose();
            select.Dispose();
            conn.Close();

            return latestMsg;
        }

        public static DataTable SelectFriend(string username)
        {
            conn.Open();
            SqlCommand select = new SqlCommand("select friend_name from user_friends where username = @UN", conn);
            select.Parameters.Add("@UN", SqlDbType.VarChar).Value = username;

            SqlDataAdapter adpter = new SqlDataAdapter(select);
            DataSet ds = new DataSet();
            adpter.Fill(ds, "friends");
            DataTable friendTable = ds.Tables["friends"];

            adpter.Dispose();
            ds.Dispose();
            select.Dispose();
            conn.Close();

            return friendTable;
        }

        public static string SelectSignature(string username)
        {
            conn.Open();
            SqlCommand select = new SqlCommand("select signature from user_info where username = @UN", conn);
            select.Parameters.Add("@UN", SqlDbType.VarChar).Value = username;

            SqlDataAdapter adpter = new SqlDataAdapter(select);
            DataSet ds = new DataSet();
            adpter.Fill(ds);

            string signature;
            if (ds.Tables[0].Rows.Count != 0)
                signature = ds.Tables[0].Rows[0][0].ToString();
            else
                signature = "Edit your signature.";


            adpter.Dispose();
            ds.Dispose();
            select.Dispose();
            conn.Close();

            return signature;
        }

        public static void Logout(string username)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update dbo.user_info set status = 0 where username = @UN";
            cmd.Parameters.Add("@UN", SqlDbType.VarChar).Value = username;
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        public static void UpdateSignature(string username, string signature)
        {
            conn.Open();
            SqlCommand update = new SqlCommand("update user_info set signature = @SIGNATURE where username = @UN", conn);
            update.Parameters.Add("@SIGNATURE", SqlDbType.VarChar).Value = signature;
            update.Parameters.Add("@UN", SqlDbType.VarChar).Value = username;

            update.ExecuteNonQuery();

            update.Dispose();
            conn.Close();
        }

        public static DataTable SelectNews(string author)
        {
            conn.Open();
            SqlCommand select = new SqlCommand("select * from user_news where author = @AUT", conn);
            select.Parameters.Add("@AUT", SqlDbType.VarChar).Value = author;

            SqlDataAdapter adapter = new SqlDataAdapter(select);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "news");

            DataTable news = ds.Tables["news"];

            adapter.Dispose();
            ds.Dispose();
            select.Dispose();
            conn.Close();

            return news;
        }

        public static void InsertNews(string author, string content, string pictureStr)
        {
            conn.Open();
            SqlCommand insert = new SqlCommand("insert into user_news (author, content, date, title_picture) values(@AUT, @CONT, @DATE, @PIC)", conn);
            insert.Parameters.Add("@AUT", SqlDbType.VarChar).Value = author;
            insert.Parameters.Add("@CONT", SqlDbType.VarChar).Value = content;
            insert.Parameters.Add("@DATE", SqlDbType.DateTime).Value = CommonHandler.GetCurrentTime();
            insert.Parameters.Add("@PIC", SqlDbType.VarChar).Value = pictureStr;

            insert.ExecuteNonQuery();

            insert.Dispose();
            conn.Close();
        }
    }
}
