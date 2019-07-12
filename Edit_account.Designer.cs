namespace GG
{
	partial class Edit_account
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.tb_address = new System.Windows.Forms.TextBox();
			this.tb_birthday = new System.Windows.Forms.TextBox();
			this.tb_age = new System.Windows.Forms.TextBox();
			this.blood = new System.Windows.Forms.Label();
			this.address = new System.Windows.Forms.Label();
			this.birthday = new System.Windows.Forms.Label();
			this.age = new System.Windows.Forms.Label();
			this.gender = new System.Windows.Forms.Label();
			this.save = new System.Windows.Forms.Button();
			this.cb_gender = new System.Windows.Forms.ComboBox();
			this.cb_blood = new System.Windows.Forms.ComboBox();
			this.signature = new System.Windows.Forms.Label();
			this.tb_signature = new System.Windows.Forms.TextBox();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tb_signature);
			this.panel2.Controls.Add(this.signature);
			this.panel2.Controls.Add(this.cb_blood);
			this.panel2.Controls.Add(this.cb_gender);
			this.panel2.Controls.Add(this.tb_address);
			this.panel2.Controls.Add(this.tb_birthday);
			this.panel2.Controls.Add(this.tb_age);
			this.panel2.Controls.Add(this.blood);
			this.panel2.Controls.Add(this.address);
			this.panel2.Controls.Add(this.birthday);
			this.panel2.Controls.Add(this.age);
			this.panel2.Controls.Add(this.gender);
			this.panel2.Controls.Add(this.save);
			this.panel2.Location = new System.Drawing.Point(-2, 1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(368, 513);
			this.panel2.TabIndex = 8;
			// 
			// tb_address
			// 
			this.tb_address.Location = new System.Drawing.Point(114, 207);
			this.tb_address.Name = "tb_address";
			this.tb_address.Size = new System.Drawing.Size(228, 21);
			this.tb_address.TabIndex = 16;
			// 
			// tb_birthday
			// 
			this.tb_birthday.Location = new System.Drawing.Point(114, 149);
			this.tb_birthday.Name = "tb_birthday";
			this.tb_birthday.Size = new System.Drawing.Size(228, 21);
			this.tb_birthday.TabIndex = 14;
			// 
			// tb_age
			// 
			this.tb_age.Location = new System.Drawing.Point(114, 82);
			this.tb_age.Name = "tb_age";
			this.tb_age.Size = new System.Drawing.Size(228, 21);
			this.tb_age.TabIndex = 13;
			// 
			// blood
			// 
			this.blood.AutoSize = true;
			this.blood.Location = new System.Drawing.Point(29, 281);
			this.blood.Name = "blood";
			this.blood.Size = new System.Drawing.Size(71, 12);
			this.blood.TabIndex = 11;
			this.blood.Text = "Blood Type:";
			// 
			// address
			// 
			this.address.AutoSize = true;
			this.address.Location = new System.Drawing.Point(29, 216);
			this.address.Name = "address";
			this.address.Size = new System.Drawing.Size(53, 12);
			this.address.TabIndex = 10;
			this.address.Text = "Address:";
			// 
			// birthday
			// 
			this.birthday.AutoSize = true;
			this.birthday.Location = new System.Drawing.Point(29, 152);
			this.birthday.Name = "birthday";
			this.birthday.Size = new System.Drawing.Size(59, 12);
			this.birthday.TabIndex = 9;
			this.birthday.Text = "Birthday:";
			// 
			// age
			// 
			this.age.AutoSize = true;
			this.age.Location = new System.Drawing.Point(29, 91);
			this.age.Name = "age";
			this.age.Size = new System.Drawing.Size(29, 12);
			this.age.TabIndex = 8;
			this.age.Text = "Age:";
			// 
			// gender
			// 
			this.gender.AutoSize = true;
			this.gender.Location = new System.Drawing.Point(29, 33);
			this.gender.Name = "gender";
			this.gender.Size = new System.Drawing.Size(47, 12);
			this.gender.TabIndex = 7;
			this.gender.Text = "Gender:";
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(114, 455);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(96, 23);
			this.save.TabIndex = 2;
			this.save.Text = "Save";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.Save_Click);
			// 
			// cb_gender
			// 
			this.cb_gender.FormattingEnabled = true;
			this.cb_gender.Location = new System.Drawing.Point(114, 25);
			this.cb_gender.Name = "cb_gender";
			this.cb_gender.Size = new System.Drawing.Size(228, 20);
			this.cb_gender.TabIndex = 17;
			// 
			// cb_blood
			// 
			this.cb_blood.FormattingEnabled = true;
			this.cb_blood.Location = new System.Drawing.Point(114, 273);
			this.cb_blood.Name = "cb_blood";
			this.cb_blood.Size = new System.Drawing.Size(228, 20);
			this.cb_blood.TabIndex = 18;
			// 
			// signature
			// 
			this.signature.AutoSize = true;
			this.signature.Location = new System.Drawing.Point(29, 343);
			this.signature.Name = "signature";
			this.signature.Size = new System.Drawing.Size(65, 12);
			this.signature.TabIndex = 19;
			this.signature.Text = "Signature:";
			// 
			// tb_signature
			// 
			this.tb_signature.Location = new System.Drawing.Point(114, 333);
			this.tb_signature.MaxLength = 150;
			this.tb_signature.Multiline = true;
			this.tb_signature.Name = "tb_signature";
			this.tb_signature.Size = new System.Drawing.Size(228, 74);
			this.tb_signature.TabIndex = 20;
			// 
			// Edit_account
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 491);
			this.Controls.Add(this.panel2);
			this.Name = "Edit_account";
			this.Text = "Edit_account";
			this.Load += new System.EventHandler(this.Edit_account_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox tb_signature;
		private System.Windows.Forms.Label signature;
		private System.Windows.Forms.ComboBox cb_blood;
		private System.Windows.Forms.ComboBox cb_gender;
		private System.Windows.Forms.TextBox tb_address;
		private System.Windows.Forms.TextBox tb_birthday;
		private System.Windows.Forms.TextBox tb_age;
		private System.Windows.Forms.Label blood;
		private System.Windows.Forms.Label address;
		private System.Windows.Forms.Label birthday;
		private System.Windows.Forms.Label age;
		private System.Windows.Forms.Label gender;
		private System.Windows.Forms.Button save;
	}
}