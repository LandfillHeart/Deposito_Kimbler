using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class AnalyzeStringOverloaded : IGenericExercise
	{
		string IGenericExercise.Name => "Analizza Stringa Overload";

		public void Execute()
		{
			Console.WriteLine("Inserisci una stringa da analizzare");
			string? input = Console.ReadLine();

			Console.WriteLine("Inserisci un carattere da trovare");
			ConsoleKeyInfo query = Console.ReadKey();
			Console.WriteLine();

			Console.WriteLine("Cosa vuoi contare");
			Console.WriteLine("Y: vocali | N: consonanti");
			ConsoleKeyInfo choice = Console.ReadKey();
			Console.WriteLine();

			Analyze(input);
			Analyze(input, query.KeyChar);
			Analyze(input, char.ToLower(choice.KeyChar) == 'y');

		}

		private void Analyze(string text) 
		{
			string output = "";
			foreach(char c in text)
			{
				if(char.IsWhiteSpace(c)) {
					continue;
				}

				output += c;
			}

			Console.WriteLine("La frase senza spazi: " + output);
		}

		private void Analyze(string text, char query)
		{
			int i = 0; 

			foreach(char c in text)
			{
				if(c == query)
				{
					i++;
				}
			}

			Console.WriteLine($"Hai usato la lettera {query} un totale di {i} volte");

		}

		private void Analyze(string text, bool countVowels)
		{
			int i = 0;
			bool isVowel = false;

			foreach (char c in text)
			{
				if(!char.IsLetter(c))
				{
					continue;
				}

				isVowel = "aeiou".Contains(char.ToLower(c));

				i += isVowel == countVowels ? 1 : 0;
			
			}

			string msg = countVowels ? "vocali" : "consonanti";

			Console.WriteLine($"Hai inserito {i} {msg}");	

		}

	}
}
