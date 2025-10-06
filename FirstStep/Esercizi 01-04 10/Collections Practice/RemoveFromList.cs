using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Collections_Practice
{
	internal class RemoveFromList : IGenericExercise
	{
		string IGenericExercise.Name => "Inserisci e Rimuovi dalla Lista";
		private List<int> ints = new();

		private int sanitizedInput;

		public void Execute()
		{
			ints = new();

			InputList(5);

			Console.WriteLine("Inserisci il numero da rimuovere");
			Program.SanitizeInput(out sanitizedInput);

			RemoveItem(sanitizedInput, out ints);

			Console.WriteLine("Risultato: ");
			foreach (int i in ints) 
			{ 
				Console.WriteLine(i);
			}
		}

		private void InputList(int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				Console.WriteLine($"Inserisci elemento {i + 1}");
				Program.SanitizeInput(out sanitizedInput);
				ints.Add(sanitizedInput);
			}
		}

		private void RemoveItem(int toRemove, out List<int> toClean)
		{
			List<int> newList = new();
			foreach(int item in ints)
			{
				if(item == toRemove)
				{
					continue;
				}

				newList.Add(item);
			}

			toClean = newList;

		}

	}
}
