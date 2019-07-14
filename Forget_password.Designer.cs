namespace GG
{
	partial class Forget_password
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
			this.cancel = new System.Windows.Forms.Label();
			this.tb2 = new System.Windows.Forms.TextBox();
			this.answer = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cb2 = new System.Windows.Forms.CheckBox();
			this.cb1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tb4 = new System.Windows.Forms.TextBox();
			this.tb3 = new System.Windows.Forms.TextBox();
			this.tb1 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cancel);
			this.panel1.Controls.Add(this.tb2);
			this.panel1.Controls.Add(this.answer);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cb2);
			this.panel1.Controls.Add(this.cb1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.tb4);
			this.panel1.Controls.Add(this.tb3);
			this.panel1.Controls.Add(this.tb1);
			this.panel1.Location = new System.Drawing.Point(0, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(656, 377);
			this.panel1.TabIndex = 14;
			// 
			// cancel
			// 
			this.cancel.AutoSize = true;
			this.cancel.ForeColor = System.Drawing.Color.Blue;
			this.cancel.Location = new System.Drawing.Point(23, 19);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(41, 12);
			this.cancel.TabIndex = 13;
			this.cancel.Text = "Cancel";
			this.cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// tb2
			// 
			this.tb2.Location = new System.Drawing.Point(220, 156);
			this.tb2.Name = "tb2";
			this.tb2.Size = new System.Drawing.Size(173, 21);
			this.tb2.TabIndex = 12;
			// 
			// answer
			// 
			this.answer.AutoSize = true;
			this.answer.Location = new System.Drawing.Point(123, 159);
			this.answer.Name = "answer";
			this.answer.Size = new System.Drawing.Size(89, 12);
			this.answer.TabIndex = 11;
			this.answer.Text = "Secret Answer:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Viner Hand ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label4.Location = new System.Drawing.Point(149, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(336, 31);
			this.label4.TabIndex = 9;
			this.label4.Text = "Fill the boxs to reset your password";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(105, 249);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "Password Confirm:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(129, 206);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "New Password:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(153, 123);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "Username:";
			// 
			// cb2
			// 
			this.cb2.AutoSize = true;
			this.cb2.Location = new System.Drawing.Point(413, 245);
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
			this.cb1.Location = new System.Drawing.Point(413, 205);
			this.cb1.Name = "cb1";
			this.cb1.Size = new System.Drawing.Size(48, 16);
			this.cb1.TabIndex = 4;
			this.cb1.Text = "view";
			this.cb1.UseVisualStyleBackColor = true;
			this.cb1.CheckedChanged += new System.EventHandler(this.Cb1_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(220, 294);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(173, 32);
			this.button1.TabIndex = 3;
			this.button1.Text = "Reset";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// tb4
			// 
			this.tb4.Location = new System.Drawing.Point(220, 243);
			this.tb4.Name = "tb4";
			this.tb4.PasswordChar = '*';
			this.tb4.Size = new System.Drawing.Size(173, 21);
			this.tb4.TabIndex = 2;
			// 
			// tb3
			// 
			this.tb3.Location = new System.Drawing.Point(220, 200);
			this.tb3.Name = "tb3";
			this.tb3.PasswordChar = '*';
			this.tb3.Size = new System.Drawing.Size(173, 21);
			this.tb3.TabIndex = 1;
			// 
			// tb1
			// 
			this.tb1.Location = new System.Drawing.Point(220, 114);
			this.tb1.Name = "tb1";
			this.tb1.Size = new System.Drawing.Size(173, 21);
			this.tb1.TabIndex = 0;
			// 
			// Forget_password
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 377);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.Name = "Forget_password";
			this.Text = "Forget_password";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Forget_password_FormClosed);
			this.Load += new System.EventHandler(this.Forget_password_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tb2;
		private System.Windows.Forms.Label answer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cb2;
		private System.Windows.Forms.CheckBox cb1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tb4;
		private System.Windows.Forms.TextBox tb3;
		private System.Windows.Forms.TextBox tb1;
		private System.Windows.Forms.Label cancel;
	}
}