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

	/// <summary>
	/// Chiede all'utente un valore in loop, finché non inserisce un numero reale (float)
	/// </summary>
	/// <param name="sanitizedInput">Risultato, assicurato di essere un float</param>
	/// <param name="mustBePositive">Opzionale, forza l'inserimento di un numero positivo. Default false</param>
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

	/// <summary>
	/// Chiede all'utente un valore in loop, finché non riceve un numero intero (int)
	/// </summary>
	/// <param name="sanitizedInput">Risultato, assicurato di essere un int</param>
	/// <param name="mustBePositive">Opzionale, forza l'inserimento di un numero positivo. Default false</param>
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

	/// <summary>
	/// Chiede all'utente un valore in loop, finché non inserisce un numero reale con il PUNTO(double)
	/// </summary>
	/// <param name="sanitizedInput">Risultato, assicurato di essere un double</param>
	/// <param name="mustBePositive">Opzionale, forza l'inserimento di un numero positivo. Default false</param>
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

	/// <summary>
	/// Chiede in loop una stringa all'utente, finché non inserisce una stringa non vuota (solo enter)
	/// </summary>
	/// <param name="sanitizedInput">La stringa, assicurata di non essere NullOrEmpty</param>
	public static void SanitizeInput(out string? sanitizedInput)
	{
		while (true)
		{
			sanitizedInput = Console.ReadLine();
			if(string.IsNullOrEmpty(sanitizedInput))
			{
				Console.WriteLine("Perfavore inserisci un contenuto per la stringa");
				continue;
			}

			break;
		}
	}

}
