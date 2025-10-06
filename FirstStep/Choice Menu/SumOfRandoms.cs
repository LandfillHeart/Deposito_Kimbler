using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Choice_Menu
{
	internal class SumOfRandoms : IGenericExercise
	{
		const int AMOUNT = 10;
		string IGenericExercise.Name => "Somma di casuali";
		private int[] randoms = new int[AMOUNT];

		private Random rng = new Random();

		public void Execute()
		{
			GenerateArray();
			PrintArray();
			PrintLowest();
			PrintHighest();
		}

		private void GenerateArray()
		{
			for (int i = 0; i < randoms.Length; i++)
			{
				randoms[i] = rng.Next(1, 101);
			}
		}

		private void PrintArray()
		{
			for (int i = 0; i < randoms.Length; i++)
			{
				Console.WriteLine(randoms[i]);
			}
		}

		private void PrintLowest()
		{
			int lowest = randoms[0];
			for (int i = 1; i < randoms.Length; i++)
			{
				if (lowest < randoms[i]) continue;

				lowest = randoms[i];
			}

			Console.WriteLine($"Valore Minimo: {lowest}");
		}

		private void PrintHighest()
		{
			int highest = randoms[0];
			for(int i =  1; i < randoms.Length; i++) 
			{
				if(highest > randoms[i]) continue;
				
				highest = randoms[i];
			}

			Console.WriteLine($"Valore Massimo: {highest}");
		}

	}
}
