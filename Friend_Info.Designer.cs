namespace GG
{
	partial class Friend_Info
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_nick = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.l_gender = new System.Windows.Forms.Label();
            this.l_birthday = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.l_sign = new System.Windows.Forms.Label();
            this.l_name = new System.Windows.Forms.Label();
            this.portrait_img = new System.Windows.Forms.PictureBox();
            this.l_nick = new System.Windows.Forms.Label();
            this.bg_img = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portrait_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg_img)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tb_nick);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.l_sign);
            this.panel1.Controls.Add(this.l_name);
            this.panel1.Controls.Add(this.portrait_img);
            this.panel1.Controls.Add(this.l_nick);
            this.panel1.Controls.Add(this.bg_img);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 449);
            this.panel1.TabIndex = 0;
            // 
            // tb_nick
            // 
            this.tb_nick.BackColor = System.Drawing.Color.White;
            this.tb_nick.Location = new System.Drawing.Point(349, 220);
            this.tb_nick.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_nick.Name = "tb_nick";
            this.tb_nick.Size = new System.Drawing.Size(132, 25);
            this.tb_nick.TabIndex = 10;
            this.tb_nick.Visible = false;
            this.tb_nick.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_nick_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.l_gender);
            this.panel2.Controls.Add(this.l_birthday);
            this.panel2.Location = new System.Drawing.Point(189, 224);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(136, 15);
            this.panel2.TabIndex = 9;
            // 
            // l_gender
            // 
            this.l_gender.AutoSize = true;
            this.l_gender.ForeColor = System.Drawing.Color.White;
            this.l_gender.Location = new System.Drawing.Point(77, 0);
            this.l_gender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_gender.Name = "l_gender";
            this.l_gender.Size = new System.Drawing.Size(55, 15);
            this.l_gender.TabIndex = 3;
            this.l_gender.Text = "gender";
            // 
            // l_birthday
            // 
            this.l_birthday.AutoSize = true;
            this.l_birthday.ForeColor = System.Drawing.Color.White;
            this.l_birthday.Location = new System.Drawing.Point(1, 0);
            this.l_birthday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_birthday.Name = "l_birthday";
            this.l_birthday.Size = new System.Drawing.Size(71, 15);
            this.l_birthday.TabIndex = 4;
            this.l_birthday.Text = "birthday";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 359);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 40);
            this.button2.TabIndex = 8;
            this.button2.Text = "Modify Remark";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(88, 359);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "Send Message";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // l_sign
            // 
            this.l_sign.Location = new System.Drawing.Point(-3, 262);
            this.l_sign.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_sign.Name = "l_sign";
            this.l_sign.Size = new System.Drawing.Size(641, 28);
            this.l_sign.TabIndex = 6;
            this.l_sign.Text = "signature";
            this.l_sign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_name
            // 
            this.l_name.BackColor = System.Drawing.Color.Transparent;
            this.l_name.Font = new System.Drawing.Font("华文楷体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_name.ForeColor = System.Drawing.Color.White;
            this.l_name.Location = new System.Drawing.Point(212, 162);
            this.l_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(200, 34);
            this.l_name.TabIndex = 5;
            this.l_name.Text = "username";
            this.l_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // portrait_img
            // 
            this.portrait_img.BackColor = System.Drawing.Color.Transparent;
            this.portrait_img.Location = new System.Drawing.Point(261, 65);
            this.portrait_img.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portrait_img.Name = "portrait_img";
            this.portrait_img.Size = new System.Drawing.Size(100, 94);
            this.portrait_img.TabIndex = 1;
            this.portrait_img.TabStop = false;
            // 
            // l_nick
            // 
            this.l_nick.AutoSize = true;
            this.l_nick.Location = new System.Drawing.Point(347, 224);
            this.l_nick.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_nick.Name = "l_nick";
            this.l_nick.Size = new System.Drawing.Size(39, 15);
            this.l_nick.TabIndex = 2;
            this.l_nick.Text = "nick";
            // 
            // bg_img
            // 
            this.bg_img.BackColor = System.Drawing.SystemColors.Control;
            this.bg_img.Location = new System.Drawing.Point(-4, -4);
            this.bg_img.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bg_img.Name = "bg_img";
            this.bg_img.Size = new System.Drawing.Size(643, 451);
            this.bg_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg_img.TabIndex = 0;
            this.bg_img.TabStop = false;
            // 
            // Friend_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 450);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Friend_Info";
            this.Text = "GG";
            this.Load += new System.EventHandler(this.Friend_Info_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portrait_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg_img)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label l_sign;
		private System.Windows.Forms.Label l_name;
		private System.Windows.Forms.Label l_birthday;
		private System.Windows.Forms.Label l_gender;
		private System.Windows.Forms.Label l_nick;
		private System.Windows.Forms.PictureBox portrait_img;
		private System.Windows.Forms.PictureBox bg_img;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox tb_nick;
	}
}