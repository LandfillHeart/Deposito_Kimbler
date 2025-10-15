using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_User_Manager
{
	public class UserCreationApp : IGenericExercise
	{
		public string Name => "Crea Utenti - Multi Pattern";

		public void Execute()
		{
			while(true)
			{
				Console.Clear();
				Console.WriteLine("Inserisci un nuovo utente, oppure premi ENTER per uscire");

				string? input = Console.ReadLine();
				if(string.IsNullOrEmpty(input))
				{
					Console.WriteLine("Grazie per aver usato la mia app!");
					return;
				}

				UserManager.Instance.CreateUser(input.Trim());

				Console.WriteLine();
				Console.WriteLine("Premi un qualsiasi tasto per continuare");
				Console.ReadKey();
			}
		}
	}
}
