using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Collections_Practice
{
	internal class OrderUniques : IGenericExercise
	{
		const int AMOUNT = 15;
		string IGenericExercise.Name => "Rimuovi duplicati e ordina";
		private Random rng = new Random();

		public void Execute()
		{
			GenerateList(AMOUNT, out List<int> randoms);
			PrintList(randoms);

			RemoveDuplicates(randoms);

			Sort(randoms);
			Console.WriteLine();
			PrintList(randoms);
		}

		private void GenerateList(int length, out List<int> result)
		{
			result = new List<int>();
			for (int i = 0; i < length; i++)
			{
				result.Add(rng.Next(1, 21));
			}
		}

		private void Sort(List<int> toSort)
		{
			bool sorted = false;
			int cap = toSort.Count - 1;
			while(!sorted)
			{
				for(int i = 0; i < cap; i++)
				{
					if (toSort[i] > toSort[i + 1])
					{
						int bubbleSave = toSort[i];
						int nSave = toSort[i + 1];
						toSort[i] = nSave;
						toSort[i + 1] = bubbleSave;
					}
				}
				cap--;
				sorted = cap == 0;
			}
		}

		private void RemoveDuplicates(List<int> toClean)
		{

			// O(2n) time
			HashSet<int> unique = new HashSet<int>();

			for(int i = 0; i < toClean.Count; i++)
			{
				unique.Add(toClean[i]);
			}

			toClean.Clear();
			
			foreach(int i in unique)
			{
				toClean.Add(i);
			}

		}
		private void PrintList(List<int> toPrint)
		{
			for (int i = 0; i < toPrint.Count; i++)
			{
				Console.Write(toPrint[i]);
				Console.Write(", ");
			}

			Console.WriteLine();
		}
	}
}
