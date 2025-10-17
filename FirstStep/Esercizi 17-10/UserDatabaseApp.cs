using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_17_10
{
	public class UserDatabaseApp : IGenericExercise
	{
		string IGenericExercise.Name => "Database con Utenti - Dictionary";
		public void Execute()
		{
			while (true)
			{
				Console.WriteLine("Scegli un opzione:");
				Console.WriteLine("0 - Esci");
				Console.WriteLine("1 - Crea Utente");
				Console.WriteLine("2 - Visiona Utente");
				Console.WriteLine("3 - Visionat tutti gli Utenti");
				Console.WriteLine("4 - Log-In con utente");
				Console.WriteLine("5 - Log-Out con utente");
				Console.WriteLine("6 - Visiona Log Utente");
				Console.WriteLine("7 - Visiona tutti i Log");
				Program.SanitizeInput(out int choice, mustBePositive: true);

				if (choice > 7) { Console.WriteLine("Commando non riconosciuto"); break; }

				switch (choice) 
				{
					case 0:
						Console.WriteLine("Ciao Ciao");
						return;
					case 1:
						CreateUser();
						break;
					case 2:
						ViewUser();
						break;
					case 3:
						ViewAllUsers();
						break;
					case 4:
						LogIn();
						break;
					case 5:
						LogOut();
						break;
					case 6:
						ViewUserLogs();
						break;
					case 7:
						ViewAllLogs();
						break;
				}
			}
		}

		private void CreateUser()
		{
			Console.WriteLine("Inserisci username");
			Program.SanitizeInput(out string username);
			Console.WriteLine("Inserisci la tua email");
			Program.SanitizeInput(out string email);
			UserManager.Instance.AddUser(username, email);
		}

		private void ViewUser()
		{
			Console.WriteLine("Inserisci l'ID dell'utente che vuoi visionare");
			Program.SanitizeInput(out int id);
			UserManager.Instance.ViewUser(id);
		}

		private void LogIn()
		{
			Console.WriteLine("Inserisci l'ID del utente al quale fare login");
			Program.SanitizeInput(out int id);
			UserManager.Instance.LogIn(id);
		}

		private void LogOut()
		{
			Console.WriteLine("Inserisci l'ID del utente al quale fare logout");
			Program.SanitizeInput(out int id);
			UserManager.Instance.LogOut(id);
		}

		private void ViewAllUsers()
		{
			foreach(User user in UserManager.Instance.GetAllUsers()) 
			{
				Console.WriteLine($"{user.ID} - {user.Name} - {user.Email}");
			}
		}

		private void ViewUserLogs()
		{
			Console.WriteLine("Inserisci l'ID del utente del quale vuoi vedere i log");
			Program.SanitizeInput(out int id);
			foreach(ActionLog log in UserManager.Instance.ViewLogsByUser(id))
			{
				PrintLog(log);
			}
		}

		private void ViewAllLogs()
		{
			foreach(User user in UserManager.Instance.GetAllUsers())
			{
				foreach(ActionLog log in UserManager.Instance.ViewLogsByUser(user.ID))
				{
					PrintLog(log);
				}
			}
		}

		private void PrintLog(ActionLog toPrint)
		{
			Console.WriteLine($"{toPrint.TimeStamp} - {toPrint.MetaData}");
		}
	}
}