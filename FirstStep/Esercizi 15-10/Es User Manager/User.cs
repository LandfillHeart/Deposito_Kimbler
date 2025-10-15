using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_User_Manager
{
	public class User
	{
		public string Name { get; private set; }
		public DateTime DateOfCreation { get; private set; }
		public User(string username)
		{
			Name = username;
			DateOfCreation = DateTime.Now;
		}

		public void ReceiveMessage(string msg)
		{
			Console.WriteLine($"Nuovo messaggio: {msg}");
		}

		public override string ToString()
		{
			return $"Utente {Name} creato il {DateOfCreation}";
		}
	}
}
