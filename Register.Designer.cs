namespace GG
{
	partial class Register
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
			this.tb1 = new System.Windows.Forms.TextBox();
			this.tb2 = new System.Windows.Forms.TextBox();
			this.tb3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.cb1 = new System.Windows.Forms.CheckBox();
			this.cb2 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.answer = new System.Windows.Forms.Label();
			this.tb4 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tb1
			// 
			this.tb1.Location = new System.Drawing.Point(220, 114);
			this.tb1.Name = "tb1";
			this.tb1.Size = new System.Drawing.Size(173, 21);
			this.tb1.TabIndex = 0;
			// 
			// tb2
			// 
			this.tb2.Location = new System.Drawing.Point(220, 154);
			this.tb2.Name = "tb2";
			this.tb2.PasswordChar = '*';
			this.tb2.Size = new System.Drawing.Size(173, 21);
			this.tb2.TabIndex = 1;
			// 
			// tb3
			// 
			this.tb3.Location = new System.Drawing.Point(220, 197);
			this.tb3.Name = "tb3";
			this.tb3.PasswordChar = '*';
			this.tb3.Size = new System.Drawing.Size(173, 21);
			this.tb3.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(220, 294);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(173, 32);
			this.button1.TabIndex = 3;
			this.button1.Text = "Register";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// cb1
			// 
			this.cb1.AutoSize = true;
			this.cb1.Location = new System.Drawing.Point(413, 159);
			this.cb1.Name = "cb1";
			this.cb1.Size = new System.Drawing.Size(48, 16);
			this.cb1.TabIndex = 4;
			this.cb1.Text = "view";
			this.cb1.UseVisualStyleBackColor = true;
			this.cb1.CheckedChanged += new System.EventHandler(this.Cb1_CheckedChanged);
			// 
			// cb2
			// 
			this.cb2.AutoSize = true;
			this.cb2.Location = new System.Drawing.Point(413, 199);
			this.cb2.Name = "cb2";
			this.cb2.Size = new System.Drawing.Size(48, 16);
			this.cb2.TabIndex = 5;
			this.cb2.Text = "view";
			this.cb2.UseVisualStyleBackColor = true;
			this.cb2.CheckedChanged += new System.EventHandler(this.Cb2_CheckedChanged);
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(153, 159);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(105, 203);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "Password Confirm:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Viner Hand ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label4.Location = new System.Drawing.Point(131, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(356, 31);
			this.label4.TabIndex = 9;
			this.label4.Text = "Welcome to Regester A New Account";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(10, 11);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 32);
			this.button2.TabIndex = 10;
			this.button2.Text = "Login";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// answer
			// 
			this.answer.AutoSize = true;
			this.answer.Location = new System.Drawing.Point(123, 246);
			this.answer.Name = "answer";
			this.answer.Size = new System.Drawing.Size(89, 12);
			this.answer.TabIndex = 11;
			this.answer.Text = "Secret Answer:";
			// 
			// tb4
			// 
			this.tb4.Location = new System.Drawing.Point(220, 243);
			this.tb4.Name = "tb4";
			this.tb4.Size = new System.Drawing.Size(173, 21);
			this.tb4.TabIndex = 12;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tb4);
			this.panel1.Controls.Add(this.answer);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cb2);
			this.panel1.Controls.Add(this.cb1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.tb3);
			this.panel1.Controls.Add(this.tb2);
			this.panel1.Controls.Add(this.tb1);
			this.panel1.Location = new System.Drawing.Point(2, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(644, 380);
			this.panel1.TabIndex = 13;
			// 
			// Register
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(643, 378);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.Name = "Register";
			this.Text = "Register";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Register_FormClosed);
			this.Load += new System.EventHandler(this.Register_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tb1;
		private System.Windows.Forms.TextBox tb2;
		private System.Windows.Forms.TextBox tb3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox cb1;
		private System.Windows.Forms.CheckBox cb2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label answer;
		private System.Windows.Forms.TextBox tb4;
		private System.Windows.Forms.Panel panel1;
	}
}