using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_User_Manager
{
	public static class UserFactory
	{
		public static User CreateUser(string username)
		{
			return new User(username);
		}
	}
}
