namespace GG
{
	partial class Change_password
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
			this.cb3 = new System.Windows.Forms.CheckBox();
			this.tb2 = new System.Windows.Forms.TextBox();
			this.answer = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cb2 = new System.Windows.Forms.CheckBox();
			this.cb1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tb4 = new System.Windows.Forms.TextBox();
			this.tb3 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cb3);
			this.panel1.Controls.Add(this.tb2);
			this.panel1.Controls.Add(this.answer);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cb2);
			this.panel1.Controls.Add(this.cb1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.tb4);
			this.panel1.Controls.Add(this.tb3);
			this.panel1.Location = new System.Drawing.Point(-98, -32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(471, 517);
			this.panel1.TabIndex = 15;
			// 
			// cb3
			// 
			this.cb3.AutoSize = true;
			this.cb3.Location = new System.Drawing.Point(412, 158);
			this.cb3.Name = "cb3";
			this.cb3.Size = new System.Drawing.Size(48, 16);
			this.cb3.TabIndex = 13;
			this.cb3.Text = "view";
			this.cb3.UseVisualStyleBackColor = true;
			this.cb3.CheckedChanged += new System.EventHandler(this.Cb3_CheckedChanged);
			// 
			// tb2
			// 
			this.tb2.Location = new System.Drawing.Point(220, 156);
			this.tb2.Name = "tb2";
			this.tb2.PasswordChar = '*';
			this.tb2.Size = new System.Drawing.Size(173, 21);
			this.tb2.TabIndex = 12;
			// 
			// answer
			// 
			this.answer.AutoSize = true;
			this.answer.Location = new System.Drawing.Point(129, 159);
			this.answer.Name = "answer";
			this.answer.Size = new System.Drawing.Size(83, 12);
			this.answer.TabIndex = 11;
			this.answer.Text = "Old Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(105, 283);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "Password Confirm:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(129, 222);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "New Password:";
			// 
			// cb2
			// 
			this.cb2.AutoSize = true;
			this.cb2.Location = new System.Drawing.Point(413, 279);
			this.cb2.Name = "cb2";
			this.cb2.Size = new System.Drawing.Size(48, 16);
			this.cb2.TabIndex = 5;
			this.cb2.Text = "view";
			this.cb2.UseVisualStyleBackColor = true;
			this.cb2.CheckedChanged += new System.EventHandler(this.Cb2_CheckedChanged);
			// 
			// cb1
			// 
			this.cb1.AutoSize = true;
			this.cb1.Location = new System.Drawing.Point(413, 221);
			this.cb1.Name = "cb1";
			this.cb1.Size = new System.Drawing.Size(48, 16);
			this.cb1.TabIndex = 4;
			this.cb1.Text = "view";
			this.cb1.UseVisualStyleBackColor = true;
			this.cb1.CheckedChanged += new System.EventHandler(this.Cb1_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(220, 334);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(173, 32);
			this.button1.TabIndex = 3;
			this.button1.Text = "Change";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// tb4
			// 
			this.tb4.Location = new System.Drawing.Point(220, 277);
			this.tb4.Name = "tb4";
			this.tb4.PasswordChar = '*';
			this.tb4.Size = new System.Drawing.Size(173, 21);
			this.tb4.TabIndex = 2;
			// 
			// tb3
			// 
			this.tb3.Location = new System.Drawing.Point(220, 216);
			this.tb3.Name = "tb3";
			this.tb3.PasswordChar = '*';
			this.tb3.Size = new System.Drawing.Size(173, 21);
			this.tb3.TabIndex = 1;
			// 
			// Change_password
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 483);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.Name = "Change_password";
			this.Text = "Change_password";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox cb3;
		private System.Windows.Forms.TextBox tb2;
		private System.Windows.Forms.Label answer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox cb2;
		private System.Windows.Forms.CheckBox cb1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tb4;
		private System.Windows.Forms.TextBox tb3;
	}
}