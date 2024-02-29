using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semytskyi1.Models
{
    internal class UserBirthday
    {
		private DateTime _birthday;

		public DateTime Birthday
		{
			get { return _birthday; }
			set { _birthday = value;}
		}
	}
}
