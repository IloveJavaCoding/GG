using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG
{
    class DatabaseHandler
    {
        private static readonly SqlConnection conn
            = new SqlConnection(@"Server=MRD\SQLEXPRESS;Database=IMS;UId=admin;Password=aaaa");

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
    }
}
