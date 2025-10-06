using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Collections_Practice
{
	internal class GroceryList : IGenericExercise
	{
		string IGenericExercise.Name => "Lista della spesa";
		private List<string?> groceryList = new();
		
		public void Execute()
		{
			int listLength = 5;
			groceryList.Clear();
			InputList(listLength);
			Console.WriteLine();
			PrintList();

		}

		private void InputList(int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				Console.WriteLine($"Inserisci elemento {i+1}");
				groceryList.Add(Console.ReadLine());
			}
		}

		private void PrintList()
		{
			foreach(string item in groceryList)
			{
				Console.WriteLine(item);
			}
		}

	}
}
