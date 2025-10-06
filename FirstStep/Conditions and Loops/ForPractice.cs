using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep
{
	internal class ForPractice : IChoiceMenu
	{
		string IChoiceMenu.Name => "Esercizi FOR";

		private ChoiceMenu choiceMenu;

		public ForPractice()
		{
			choiceMenu = new(new IGenericExercise[] { new TimesTable(), new AverageOfIntegers(), new Factorial(), new FindDigits(), new RemoveWhiteSpace(), new CountVowels(), new ValidatePassword(), new StringAnalyzer() });
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}
	}

	public class TimesTable : IGenericExercise
	{
		private int sanitizedInput;

		string IGenericExercise.Name => "Tabellina";

		public void Execute()
		{
			Console.WriteLine("Inserisci un numero intero");
			Program.SanitizeInput(out sanitizedInput);

			for (int i = 1; i <= 10; i++)
			{
				Console.WriteLine($"{sanitizedInput} * {i} = {sanitizedInput * i}");
			}

		}
	}

	public class AverageOfIntegers : IGenericExercise
	{
		string IGenericExercise.Name => "Media di Input";

		private float sum;
		private int sanitizedInput;

		public void Execute()
		{
			Console.WriteLine("Inserire la quantità di numeri necessari");
			Program.SanitizeInput(out sanitizedInput);
			int tot = sanitizedInput;

			for(int i = 1; i <= tot; i++) 
			{
				Console.WriteLine($"Inserisci il numero {i}");
				Program.SanitizeInput(out sanitizedInput);
				sum += sanitizedInput;
			}

			Console.WriteLine($"La media dei numeri inseriti è {sum/tot}");
		}
	}

	public class Factorial : IGenericExercise
	{
		string IGenericExercise.Name => "Fattoriale";

		private int sanitizedInput;
		private int factorial = 1;

		public void Execute()
		{
			factorial = 1;
			Console.WriteLine("Inserisci un numero");
			Program.SanitizeInput(out sanitizedInput, mustBePositive: true);
			for(int i = sanitizedInput; i > 0; i--)
			{
				factorial *= i;
			}

			Console.WriteLine($"Il fattoriale di {sanitizedInput} è {factorial}");
		}
	}

	public class FindDigits : IGenericExercise
	{
		string IGenericExercise.Name => "Trova cifre";

		public void Execute()
		{
			Console.WriteLine("Inserisci una frase");
			string? input = Console.ReadLine();
			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Hai inserito 0 cifre");
				return;
			}
			int i = 0;
			foreach (char character in input)
			{
				if (char.IsDigit(character))
				{
					i++;
				}
			}

			Console.WriteLine($"Hai inserito {i} cifre");
		}
	}

	public class RemoveWhiteSpace : IGenericExercise 
	{
		string IGenericExercise.Name => "Rimuvoi Spazi";

		public void Execute()
		{
			Console.WriteLine("Inserisci una frase");
			string? input = Console.ReadLine();

			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Potevi almeno scrivere qualcosa dai");
				return;
			}

			string output = "";
			foreach(char character in input)
			{
				if(char.IsWhiteSpace(character))
				{
					continue;
				}

				output += character;
			}

			Console.WriteLine(output);

		}
	}

	public class CountVowels : IGenericExercise
	{
		string IGenericExercise.Name => "Conta Vocabili";

		public void Execute() 
		{ 
			Dictionary<char, int> vowelCounter = new Dictionary<char, int>();
			vowelCounter.Add('a', 0);
			vowelCounter.Add('e', 0);
			vowelCounter.Add('i', 0);
			vowelCounter.Add('o', 0);
			vowelCounter.Add('u', 0);

			Console.WriteLine("Inserisci una frase");
			string? input = Console.ReadLine();

			if(string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Non hai inserito nessuna frase");
				return;
			}

			char charCache;
			foreach (char character in input) 
			{
				charCache = char.ToLower(character);
				if(!vowelCounter.ContainsKey(charCache)) 
				{
					continue;
				}

				vowelCounter[charCache]++;
			}

			foreach (char key in vowelCounter.Keys)
			{	
				Console.WriteLine($"Hai inserito la vocale {char.ToUpper(key)} un totale di {vowelCounter[key]} volte");
			}

		}
	}

	public class ValidatePassword : IGenericExercise 
	{
		const int MIN_LENGTH = 8;

		string IGenericExercise.Name => "Valida Password";

		public void Execute()
		{
			Console.WriteLine("Inserisci una Password");
			Console.WriteLine("Requisiti: 1 lettera maiuscola, 1 cifra, 8 caratteri minimo, nessuno spazio ad inizio o fine");

			string? input = Console.ReadLine();

			bool hasUppercase = false;
			bool hasDigit = false;

			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Campo vuoto, per favore riprovare");
				return;
			}

			if (input.Length < MIN_LENGTH) 
			{
				Console.WriteLine("La password non rispetta la dimensione minima"); 
				return;
			}

			if (char.IsWhiteSpace(input[0]) || char.IsWhiteSpace(input[input.Length - 1]))
			{
				Console.WriteLine("La Password non può iniziare o finire con uno spazio");
				return;
			}

			foreach (char character in input)
			{

				if (!hasUppercase && char.IsUpper(character))
				{
					hasUppercase = true;
				}

				if(!hasDigit && char.IsDigit(character))
				{
					hasDigit = true;
				}

				if (hasUppercase && hasDigit)
				{
					Console.WriteLine("La Password rispetta tutti i parametri!");
					return;
				}
			}

			Console.WriteLine("La Password non rispetta i seguenti parametri:");
			if (!hasUppercase) Console.WriteLine("Lettera Maiuscola");
			if (!hasDigit) Console.WriteLine("Cifra");
		}
	}

	public class StringAnalyzer : IGenericExercise
	{
		string IGenericExercise.Name => "Analizza Stringa";

		public void Execute()
		{
			// numero di parole = Split
			// char alfabetici = isLetter
			// numero di spazi
			// punteggiatura = isPunctuaction

			Console.WriteLine("Scrivi una frase");
			string? input = Console.ReadLine();
			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Stringa vuota...");
				return;
			}

			int alphabeticalChars = 0;
			int punctuationChars = 0;
			int whiteSpace = 0;

			foreach (char character in input)
			{
				if (char.IsLetter(character))
				{
					alphabeticalChars++;
					continue;
				}

				if (char.IsPunctuation(character))
				{
					punctuationChars++;
					continue;
				}

				if (char.IsWhiteSpace(character))
				{
					whiteSpace++;
					continue;
				}
			}

			Console.WriteLine($"Lettere inserite: {alphabeticalChars}");
			Console.WriteLine($"Segni di punteggiatura inseriti: {punctuationChars}");
			Console.WriteLine($"Spazi inseriti: {whiteSpace}");
			Console.WriteLine($"Parole inserite: {input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length}");

		}

	}


}
