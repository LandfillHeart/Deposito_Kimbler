using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Collections_Practice
{
	internal class FindItemAndEven : IGenericExercise
	{
		const int AMOUNT = 10;

		string IGenericExercise.Name => "Trova elemento e pari";

		private Random rng = new Random();

		private int sanitizedInput;

		public void Execute()
		{
			GenerateList(AMOUNT, out int[] randoms);
			PrintList(randoms);


			Console.WriteLine();
			Console.WriteLine("Inserisci il numero da trovare");
			Program.SanitizeInput(out sanitizedInput);

			if(FindInArray(sanitizedInput, randoms, out List<int> results))
			{
				Console.WriteLine();
				Console.Write("Numero trovato ai seguenti indici: ");
				foreach(int i in results)
				{
					Console.Write(i);
					Console.Write(", ");
				}
				Console.WriteLine();
			} else
			{
				Console.WriteLine("Il numero non è presente nell'array");
			}

			if(!EvensInArray(randoms, out List<int> evens))
			{
				Console.WriteLine("Non ci sono numeri pari in questa lista");
				return;
			}
			
			Console.WriteLine($"Trovato {evens.Count} numeri pari: ");
			PrintList(evens.ToArray());

		}

		private void GenerateList(int length, out int[] result)
		{
			result = new int[length];
			for (int i = 0; i < length; i++)
			{
				result[i] = rng.Next(1, 101);
			}
		}

		private void PrintList(int[] toPrint)
		{
			for (int i = 0; i < toPrint.Length; i++)
			{
				Console.Write(toPrint[i]);
				Console.Write(", ");
			}

			Console.WriteLine();
		}

		private bool FindInArray(int toFind, int[] toQuery, out List<int> results)
		{
			results = new List<int>();
			bool found = false;
			for (int i = 0; i < toQuery.Length; i++)
			{
				if (toFind != toQuery[i]) continue;
				found = true;
				results.Add(i);
			}

			return found;

		}

		private bool EvensInArray(int[] toQuery, out List<int> results)
		{
			results = new List<int>();
			for (int i = 0; i < toQuery.Length; i++)
			{
				if (toQuery[i] % 2 != 0) continue;
				results.Add(toQuery[i]);
			}

			return results.Count > 0;
		}

	}
}
