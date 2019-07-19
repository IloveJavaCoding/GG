using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG
{
	class Users
	{
		private string username
		{
			get
			{
				return username;
			}
			set
			{
				username = value;
			}
		}
		private int state
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
			}
		}
		private string gender
		{
			get
			{
				return gender;
			}
			set
			{
				gender = value;
			}
		}
		private int age
		{
			get
			{
				return age;
			}
			set
			{
				age = value;
			}
		}
		private string birthday
		{
			get
			{
				return birthday;
			}
			set
			{
				birthday = value;
			}
		}
		private string signature
		{
			get
			{
				return signature;
			}
			set
			{
				signature = value;
			}
		}
		private string portrait
		{
			get
			{
				return portrait;
			}
			set
			{
				portrait = value;
			}
		}

		public Users(string username, int state, string gender, int age, string birthday, string signature, string portrait)
		{
			this.username = username;
			this.state = state;
			this.gender = gender;
			this.age = age;
			this.birthday = birthday;
			this.signature = signature;
			this.portrait = portrait;
		}

		public Users()
		{
		}

		

	}
}
