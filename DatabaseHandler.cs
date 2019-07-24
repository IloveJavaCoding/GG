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
    }
}
