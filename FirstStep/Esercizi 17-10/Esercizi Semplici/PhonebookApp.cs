using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_17_10.Esercizi_Semplici
{
	public class PhonebookApp : IGenericExercise
	{
		string IGenericExercise.Name => "Rubrica con dizionario";

		public void Execute()
		{
			Dictionary<string, string> contacts = new Dictionary<string, string>();

			for (int i = 1; i <= 3; i++)
			{
				Console.WriteLine($"Inserisci il contatto numero {i}");
				Program.SanitizeInput(out string name);
				while (contacts.ContainsKey(name))
				{
					Console.WriteLine("Hai già questo contatto in rubrica! Inseriscine un altro");
					Program.SanitizeInput(out name);
				}
				
				Console.WriteLine("Inserisci il numero di telefono");
				Program.SanitizeInput(out string number);
				
				contacts.Add(name, number);
			}

			foreach (string name in contacts.Keys)
			{
				Console.WriteLine($"{name} - {contacts[name]}");
			}
		}
	}
}
