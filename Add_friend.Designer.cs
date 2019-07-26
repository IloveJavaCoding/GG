namespace GG
{
	partial class Add_friend
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
			this.search = new System.Windows.Forms.Button();
			this.tb_input = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.p_info = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.l_signature = new System.Windows.Forms.Label();
			this.l_birthday = new System.Windows.Forms.Label();
			this.l_gender = new System.Windows.Forms.Label();
			this.l_name = new System.Windows.Forms.Label();
			this.portrait = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.result = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.p_info.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.portrait)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.search);
			this.panel1.Controls.Add(this.tb_input);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(612, 42);
			this.panel1.TabIndex = 0;
			// 
			// search
			// 
			this.search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.search.Location = new System.Drawing.Point(411, 10);
			this.search.Name = "search";
			this.search.Size = new System.Drawing.Size(75, 23);
			this.search.TabIndex = 1;
			this.search.Text = "Search";
			this.search.UseVisualStyleBackColor = false;
			this.search.Click += new System.EventHandler(this.Search_Click);
			// 
			// tb_input
			// 
			this.tb_input.Location = new System.Drawing.Point(77, 12);
			this.tb_input.Name = "tb_input";
			this.tb_input.Size = new System.Drawing.Size(300, 21);
			this.tb_input.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.p_info);
			this.panel2.Controls.Add(this.result);
			this.panel2.Location = new System.Drawing.Point(0, 42);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(612, 323);
			this.panel2.TabIndex = 1;
			// 
			// p_info
			// 
			this.p_info.BackColor = System.Drawing.Color.Transparent;
			this.p_info.Controls.Add(this.panel3);
			this.p_info.Controls.Add(this.button1);
			this.p_info.Location = new System.Drawing.Point(77, 49);
			this.p_info.Name = "p_info";
			this.p_info.Size = new System.Drawing.Size(483, 162);
			this.p_info.TabIndex = 1;
			this.p_info.Visible = false;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.panel3.Controls.Add(this.l_signature);
			this.panel3.Controls.Add(this.l_birthday);
			this.panel3.Controls.Add(this.l_gender);
			this.panel3.Controls.Add(this.l_name);
			this.panel3.Controls.Add(this.portrait);
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(258, 154);
			this.panel3.TabIndex = 6;
			// 
			// l_signature
			// 
			this.l_signature.AutoSize = true;
			this.l_signature.Location = new System.Drawing.Point(31, 125);
			this.l_signature.Name = "l_signature";
			this.l_signature.Size = new System.Drawing.Size(59, 12);
			this.l_signature.TabIndex = 4;
			this.l_signature.Text = "signature";
			// 
			// l_birthday
			// 
			this.l_birthday.AutoSize = true;
			this.l_birthday.Location = new System.Drawing.Point(149, 83);
			this.l_birthday.Name = "l_birthday";
			this.l_birthday.Size = new System.Drawing.Size(53, 12);
			this.l_birthday.TabIndex = 3;
			this.l_birthday.Text = "birthday";
			// 
			// l_gender
			// 
			this.l_gender.AutoSize = true;
			this.l_gender.Location = new System.Drawing.Point(149, 50);
			this.l_gender.Name = "l_gender";
			this.l_gender.Size = new System.Drawing.Size(41, 12);
			this.l_gender.TabIndex = 2;
			this.l_gender.Text = "gender";
			// 
			// l_name
			// 
			this.l_name.AutoSize = true;
			this.l_name.Location = new System.Drawing.Point(149, 20);
			this.l_name.Name = "l_name";
			this.l_name.Size = new System.Drawing.Size(53, 12);
			this.l_name.TabIndex = 1;
			this.l_name.Text = "username";
			// 
			// portrait
			// 
			this.portrait.Location = new System.Drawing.Point(33, 20);
			this.portrait.Name = "portrait";
			this.portrait.Size = new System.Drawing.Size(75, 75);
			this.portrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.portrait.TabIndex = 0;
			this.portrait.TabStop = false;
			// 
			// button1
			// 
			this.button1.ForeColor = System.Drawing.Color.Blue;
			this.button1.Location = new System.Drawing.Point(317, 84);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "+ Add ";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// result
			// 
			this.result.AutoSize = true;
			this.result.ForeColor = System.Drawing.Color.Red;
			this.result.Location = new System.Drawing.Point(111, 108);
			this.result.Name = "result";
			this.result.Size = new System.Drawing.Size(23, 12);
			this.result.TabIndex = 0;
			this.result.Text = "...";
			this.result.Visible = false;
			// 
			// Add_friend
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 361);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "Add_friend";
			this.Text = "Add_friend";
			this.Load += new System.EventHandler(this.Add_friend_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.p_info.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.portrait)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button search;
		private System.Windows.Forms.TextBox tb_input;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label result;
		private System.Windows.Forms.Panel p_info;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label l_signature;
		private System.Windows.Forms.Label l_birthday;
		private System.Windows.Forms.Label l_gender;
		private System.Windows.Forms.Label l_name;
		private System.Windows.Forms.PictureBox portrait;
		private System.Windows.Forms.Panel panel3;
	}
}