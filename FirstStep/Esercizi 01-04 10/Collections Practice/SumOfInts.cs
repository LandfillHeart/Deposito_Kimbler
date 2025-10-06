using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Collections_Practice
{
	internal class SumOfInts : IGenericExercise
	{
		string IGenericExercise.Name => "Somma di interi";

		private int sanitizedInput;
		private List<int> ints = new();

		public void Execute()
		{
			Console.WriteLine("Inserisci quantità di numeri");
			Program.SanitizeInput(out sanitizedInput);

			SetList(sanitizedInput);
			Console.WriteLine("La somma di tutti gli elementi equivale a: " + GetSum());
		}

		private void SetList(int length)
		{
			ints.Clear();
			for (int i = 0; i < length; i++)
			{
				Console.WriteLine($"Inserisci il numero {i+1}");
				Program.SanitizeInput(out sanitizedInput);
				ints.Add(sanitizedInput);
			}
		}

		private int GetSum()
		{
			int sum = 0;
			foreach (int i in ints)
			{
				sum += i;
			}

			return sum;

		}


	}
}
