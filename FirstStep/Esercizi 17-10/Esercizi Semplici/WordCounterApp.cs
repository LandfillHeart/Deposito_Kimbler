using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_17_10.Esercizi_Semplici
{
	public class WordCounterApp : IGenericExercise
	{
		public string Name => "Conta parole nella frase";

		public void Execute()
		{
			Dictionary<string, int> foundWords = new Dictionary<string, int>();
			Console.WriteLine("Inserisci una frase!!");
			Program.SanitizeInput(out string sentence);
			string[] words = sentence.Split(' ', ',', '.', '!', '?');
			foreach(string typedWord in words)
			{
				string word = typedWord.ToLower();
				if(string.IsNullOrWhiteSpace(word)) continue;
				if(!foundWords.ContainsKey(word))
				{
					foundWords.Add(word, 0);
				}
				foundWords[word]++;
			}

			foreach (string word in foundWords.Keys)
			{
				Console.WriteLine($"Trovato la parola {word} un totale di {foundWords[word]} volte");
			}
		}
	}
}
