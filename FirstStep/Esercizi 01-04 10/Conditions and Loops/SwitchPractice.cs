using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep
{
	internal class SwitchPractice : IChoiceMenu
	{
		string IChoiceMenu.Name => "Esercizi SWITCH";
		private float sanitizedInput;

		private void Grade()
		{
			Console.WriteLine("Perfavore, inserire un voto da 1 a 10");
			Program.SanitizeInput(out sanitizedInput);
			int grade = (int)sanitizedInput;

			while (grade < 1 || grade > 10)
			{
				Console.WriteLine("Il numero inserito non è incluso tra 1 e 10, inseriscine uno nuovo");
				Program.SanitizeInput(out sanitizedInput);
				grade = (int)sanitizedInput;
			}


			switch(grade)
			{
				case int n when (n <= 4):
					Console.WriteLine("Insufficiente");
					break;
				case int n when (n <= 6):
					Console.WriteLine("Sufficiente");
					break;
				case int n when (n <= 8):
					Console.WriteLine("Buono");
					break;
				default:
					Console.WriteLine("Ottimo");
					break;
			}
		}

		public void CalculateBMI()
		{
			Console.WriteLine("Inserisci il tuo peso in KG");
			Program.SanitizeInput(out sanitizedInput, mustBePositive: true);
			float weight = sanitizedInput;

			Console.WriteLine("Inserisci la tua altezza in metri");
			Program.SanitizeInput(out sanitizedInput, mustBePositive: true);
			float height = sanitizedInput;

			float bmi = weight / (height * height);

			switch(bmi)
			{
				case float n when (n < 0):
					Console.WriteLine("Come");
					break;
				case float n when (n < 18.5):
					Console.WriteLine("Sottopeso");
					break;
				case float n when (n < 25):
					Console.WriteLine("Normopeso");
					break;
				case float n when (n < 30):
					Console.WriteLine("Sovrappeso");
					break;
				default:
					Console.WriteLine("Obesità");
					break;
			}

		}

		public void OptionsMenu()
		{
			while(true)
			{
				Console.WriteLine("Scegli un esercizio");
				Console.WriteLine("ENTER - Chiudi programma");
				Console.WriteLine("0 - Torna al menu");
				Console.WriteLine("1 - Dai un voto");
				Console.WriteLine("2 - Calcola BMI");

				Program.SanitizeInput(out sanitizedInput);
				int pickedOption = (int)sanitizedInput;
				switch(pickedOption)
				{
					case 0:
						Console.Clear();
						return;
					case 1:
						Console.Clear();
						Grade();
						break;
					case 2:
						Console.Clear();
						CalculateBMI();
						break;
					default:
						Console.WriteLine("Esercizio non riconosciuto");
						break;
				}

				Console.WriteLine("Premi qualsiasi tasto per tornare al menu");
				Console.ReadKey(true);
				Console.Clear();

			}
			
		}

		private class TemperatureConverter : IChoiceMenu
		{
			string IChoiceMenu.Name => "Converti Temperatura";
			private float sanitizedInput;

			public void OptionsMenu()
			{
				Console.WriteLine("Scegli un opzione");
				Console.WriteLine("ENTER - Chiudi Programma");
				Console.WriteLine("1 - Fahrenheit");
				Console.WriteLine("2 - Kelvin");
				Console.WriteLine("3 - Rankine");

				Program.SanitizeInput(out sanitizedInput);
				int pickedChoice = (int)sanitizedInput;

			}
		}


	}
}
