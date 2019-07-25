using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GG
{
    public partial class Friend_Info : Form
    {
        Functions functions;
        private SqlConnection conn;

        protected Contact main_info;
        private string username;
        private string friendname;

        public Friend_Info(Contact main_info, string username, string friendname)
        {
            this.main_info = main_info;
            this.username = username;
            this.friendname = friendname;
            InitializeComponent();

            functions = new Functions();
            conn = functions.conn;
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
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from user_info, user_friends where user_friends.username=@Username and user_friends.friend_name=@FN and user_info.username=user_friends.friend_name", conn);
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
            cmd.Parameters.Add("@FN", SqlDbType.VarChar, 50).Value = friendname;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            cmd.Dispose();
            conn.Close();

            l_name.Text = friendname;
            l_gender.Text = ds.Tables[0].Rows[0][5].ToString();
            l_birthday.Text = ds.Tables[0].Rows[0][7].ToString();
            l_nick.Text = ds.Tables[0].Rows[0][16].ToString();
            l_sign.Text = ds.Tables[0].Rows[0][9].ToString();

            bg_img.Image = CommonHandler.LoadImage(friendname, "user_background");
            portrait_img.Image = functions.Change_shap(CommonHandler.LoadImage(friendname, "user_avatar"));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            tb_nick.Visible = true;
            tb_nick.Text = l_nick.Text;
        }

        private void Tb_nick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Update_nickneame(username, friendname, tb_nick.Text);
                l_nick.Text = tb_nick.Text;
                tb_nick.Visible = false;
                main_info.Data_bind(username);
            }
        }

        private void Update_nickneame(string username, string friendname, string nickname)
        {
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update dbo.user_friends set friend_nick = '" + nickname + "' where username = '" + username + "' and friend_name ='" + friendname + "'";
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            if (!Contact.chatKey.ContainsKey(friendname))
            {
                Contact.chatKey.Add(friendname, new Chatroom(username, friendname));
            }
            if(Contact.chatKey.Count == 1)
                Contact.chatKey.Values.First().StartPosition =  FormStartPosition.CenterScreen;
            CommonHandler.UpdateShowing(friendname);
        }
    }
}
