using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep
{
	internal class ChoiceMenu
	{
		private int sanitizedInput;
		private bool isMainMenu;
		private string header;

		public IGenericExercise[] exercises = new IGenericExercise[0];

		public ChoiceMenu(IGenericExercise[] exercises, string header = "Seleziona un esercizio", bool isMainMenu = false) 
		{
			this.exercises = exercises;
			this.header = header;
			this.isMainMenu = isMainMenu;
		}

		public void DisplayMenu()
		{

			while(true) 
			{
				Console.WriteLine(header);
				Console.WriteLine("ENTER - Chiudi il programma");

				if(!isMainMenu)
				{
					Console.WriteLine("0 - Torna al menu");
				}

				for (int i = 0; i < exercises.Length; i++)
				{
					Console.WriteLine($"{i + 1} - {exercises[i].Name}");
				}

				Program.SanitizeInput(out sanitizedInput);

				if (sanitizedInput == 0)
				{
					ClassMenu.ReturnWithoutDialogue = true;
					Console.Clear();
					return;
				}

				sanitizedInput--;

				
				if (sanitizedInput > exercises.Length - 1 || sanitizedInput < 0)
				{
					Console.WriteLine("Esercizio non riconosciuto");
					continue;
				}

				Console.Clear();
				exercises[sanitizedInput].Execute();

				Console.WriteLine("Premi qualsiasi tasto per tornare al menu");
				Console.ReadKey(true);
				Console.Clear();

			}

		}

	}
}
