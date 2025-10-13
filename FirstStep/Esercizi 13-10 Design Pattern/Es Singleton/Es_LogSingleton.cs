using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FirstStep.Esercizi_13_10_Design_Pattern.Es_Singleton
{
	public class Es_LogSingleton : IGenericExercise
	{
		public string Name => "Esercizio Log Console Singleton";
		// in questo caso, stiamo inserendo il riferimento in una variabile, per poi dimostrare che stiamo facendo riferimento allo stesso oggetto
		private LogManager logManagerCache = LogManager.Instance;
		private string messageOne = "Chiamo singleton da una metodo";
		private string messageTwo = "Chiamo singleton da un secondo metodo";

		public void Execute()
		{
			logManagerCache.PrintMessage(messageOne);
			PrintMessage();

			// paragoniamo i riferimenti
			Console.WriteLine($"Stiamo facendo riferimento allo stesso oggetto? {logManagerCache.Equals(LogManager.Instance)}");

			// utilizziamo User per chiamare UserManager
			User userOne = new User("Ray", "Formatemp".GetHashCode());
			User userTwo = new User("Mirko", "CSHARP".GetHashCode());

			userOne.MessageUser();
			userTwo.MessageUser();

			UserManager.Instance.LogIn(userOne, "Formatemp".GetHashCode());
			// chiamiamo entrambi i metodi per dimostrare che si tratta della stessa istanza
			UserManager.Instance.SendMessage(userOne);
			userOne.MessageUser();
		}

		public void PrintMessage()
		{
			LogManager.Instance.PrintMessage(messageTwo);
		}
	}

	public class UserManager
	{
		private static UserManager instance;
		public static UserManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new UserManager();
				}

				return instance;
			}
		}

		// if a user is logged in, they are present in this set
		// once they act, their session is invalid and they must be removed from this set
		// to act again, they must login
		private HashSet<User> validUserSessions = new HashSet<User>();

		public void LogIn(User user, int password)
		{
			if(UserSessionValid(user))
			{
				Console.WriteLine("Nessun accesso necessario, sei già online");
				return;
			}

			if(user.Password == password)
			{
				Console.WriteLine($"Accesso eseguito, benvenuto {user.Name}");
				validUserSessions.Add(user);
				return;
			}
			Console.WriteLine("Password Errata");
		}

		public void SendMessage(User user)
		{
			if(!UserSessionValid(user))
			{
				Console.WriteLine("Bisogna fare il log-in per fare questa azione!");
				return;
			}

			InvalidateUserSession(user);
			LogManager.Instance.PrintMessage($"Inviamo un messaggo al carissimo utente {user.Name}");
		}


		public bool UserSessionValid(User user)
		{
			return validUserSessions.Contains(user);
		}

		private void InvalidateUserSession(User user)
		{
			// removing missing object from hashset is safe by default
			validUserSessions.Remove(user);
		}
	}

	public class LogManager
	{
		private static LogManager instance;
		public static LogManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new LogManager();
				}

				return instance;
			}
		}

		private LogManager() { }

		public void PrintMessage(string msg)
		{
			Console.WriteLine($"{msg} - {DateTime.Now}");
		}
	}

	public class User
	{
		private string name;
		private int password;

		public string Name => name;
		public int Password => password;

		public User(string name, int password)
		{
			this.name = name;
			this.password = password;
		}

		public void MessageUser()
		{
			UserManager.Instance.SendMessage(this);
		}
	}
}
