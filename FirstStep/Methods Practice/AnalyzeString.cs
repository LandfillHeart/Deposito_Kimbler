using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class AnalyzeString : IGenericExercise
	{
		string IGenericExercise.Name => "Analizza Parola";

		public void Execute()
		{
			Console.WriteLine("Inserisci una stringa");
			string? input = Console.ReadLine();

			Analyze(input, out int vCount, out int cCount, out int wsCount);
			Console.WriteLine($"Hai inserito {vCount} vocali, {cCount} consonanti, e {wsCount} spazi");
		}

		private void Analyze(string? input, out int vowelCount, out int consonantCount, out int whiteSpaceCount)
		{
			vowelCount = 0;
			consonantCount = 0;
			whiteSpaceCount = 0;
			if(string.IsNullOrEmpty(input))
			{
				return;
			}

			foreach(char c in input)
			{
				if(char.IsWhiteSpace(c))
				{
					whiteSpaceCount++;
					continue;
				}

				if(!char.IsLetter(c))
				{
					continue;
				}

				if("aeiou".Contains(char.ToLower(c)))
				{
					vowelCount++;
					continue;
				}

				consonantCount++;

			}

		}

	}
}
