using FirstStep;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
	static void Main(string[] args)
	{
		Console.Clear();

		ClassMenu methodMenu = new ClassMenu();

		methodMenu.OptionsMenu();

		return;

	}

	public static void SanitizeInput(out float sanitizedInput, bool mustBePositive = false)
	{
		while (true)
		{
			string? input = Console.ReadLine();
			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Grazie per aver usato la mia applicazione. A dopo!");
				Environment.Exit(0);
			}

			if (!float.TryParse(input, out sanitizedInput))
			{
				Console.WriteLine("Perfavore, inserisci un numero reale senza caratteri non-numerici");
				continue;
			}

			if(mustBePositive && sanitizedInput < 0)
			{
				Console.WriteLine("Perfavore, inserisci un numero positivo (maggiore di zero)");
				continue;
			}

			break;
		}
	}

	public static void SanitizeInput(out int sanitizedInput, bool mustBePositive = false)
	{
		while (true)
		{
			string? input = Console.ReadLine();
			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Grazie per aver usato la mia applicazione. A dopo!");
				Environment.Exit(0);
			}

			if (!int.TryParse(input, out sanitizedInput))
			{
				Console.WriteLine("Perfavore, inserisci un numero reale intero senza caratteri non-numerici");
				continue;
			}

			if (mustBePositive && sanitizedInput < 0)
			{
				Console.WriteLine("Perfavore, inserisci un numero positivo (maggiore di zero)");
				continue;
			}

			break;
		}
	}

	public static void SanitizeInput(out double sanitizedInput, bool mustBePositive = false)
	{
		while (true)
		{
			string? input = Console.ReadLine();
			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Grazie per aver usato la mia applicazione. A dopo!");
				Environment.Exit(0);
			}

			if(input.Contains(',')) {
				Console.WriteLine("Perfavore, inserire numero double con il PUNTO, non la VIRGOLA");
				continue;
			}

			if (!double.TryParse(input, out sanitizedInput))
			{
				Console.WriteLine("Perfavore, inserisci un numero reale intero senza caratteri non-numerici");
				continue;
			}

			if (mustBePositive && sanitizedInput < 0)
			{
				Console.WriteLine("Perfavore, inserisci un numero positivo (maggiore di zero)");
				continue;
			}

			break;
		}
	}

}
