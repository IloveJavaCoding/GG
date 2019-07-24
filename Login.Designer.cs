namespace GG
{
	partial class Login
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.username = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.B_login = new System.Windows.Forms.Button();
			this.register = new System.Windows.Forms.Label();
			this.forget_pass = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cb1 = new System.Windows.Forms.CheckBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(1, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(490, 176);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(154, 199);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(208, 21);
			this.username.TabIndex = 1;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(154, 226);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(209, 21);
			this.password.TabIndex = 2;
			// 
			// B_login
			// 
			this.B_login.Location = new System.Drawing.Point(154, 269);
			this.B_login.Name = "B_login";
			this.B_login.Size = new System.Drawing.Size(207, 34);
			this.B_login.TabIndex = 3;
			this.B_login.Text = "Login";
			this.B_login.UseVisualStyleBackColor = true;
			this.B_login.Click += new System.EventHandler(this.B_login_Click);
			// 
			// register
			// 
			this.register.AutoSize = true;
			this.register.ForeColor = System.Drawing.SystemColors.Highlight;
			this.register.Location = new System.Drawing.Point(15, 335);
			this.register.Name = "register";
			this.register.Size = new System.Drawing.Size(53, 12);
			this.register.TabIndex = 4;
			this.register.Text = "Register";
			this.register.Click += new System.EventHandler(this.Register_Click);
			// 
			// forget_pass
			// 
			this.forget_pass.AutoSize = true;
			this.forget_pass.ForeColor = System.Drawing.Color.Red;
			this.forget_pass.Location = new System.Drawing.Point(205, 320);
			this.forget_pass.Name = "forget_pass";
			this.forget_pass.Size = new System.Drawing.Size(101, 12);
			this.forget_pass.TabIndex = 5;
			this.forget_pass.Text = "Forget password?";
			this.forget_pass.Click += new System.EventHandler(this.Forget_pass_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(86, 202);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "Username:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(86, 229);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 7;
			this.label3.Text = "Password:";
			// 
			// cb1
			// 
			this.cb1.AutoSize = true;
			this.cb1.Location = new System.Drawing.Point(369, 231);
			this.cb1.Name = "cb1";
			this.cb1.Size = new System.Drawing.Size(48, 16);
			this.cb1.TabIndex = 8;
			this.cb1.Text = "view";
			this.cb1.UseVisualStyleBackColor = true;
			this.cb1.CheckedChanged += new System.EventHandler(this.Cb1_CheckedChanged);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 361);
			this.Controls.Add(this.cb1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.forget_pass);
			this.Controls.Add(this.register);
			this.Controls.Add(this.B_login);
			this.Controls.Add(this.password);
			this.Controls.Add(this.username);
			this.Controls.Add(this.pictureBox1);
			this.MaximizeBox = false;
			this.Name = "Login";
			this.Text = "GG";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
			
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Button B_login;
		private System.Windows.Forms.Label register;
		private System.Windows.Forms.Label forget_pass;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox cb1;
		private System.Windows.Forms.ImageList imageList1;
	}
}

