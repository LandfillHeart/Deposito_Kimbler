using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Collections_Practice
{
	internal class FindItemInArray : IGenericExercise
	{
		string IGenericExercise.Name => "Ricerca in vettore";
		private int sanitizedInput;
		private int[] ints;
		private int[] intsReversed;

		public void Execute()
		{
			Console.WriteLine("Quanti numeri vuoi inserire?");
			Program.SanitizeInput(out sanitizedInput);

			ints = new int[sanitizedInput];
			intsReversed = new int[sanitizedInput];

			SetArray(sanitizedInput);

			Console.WriteLine("Inserisci il numero da cercare");
			Program.SanitizeInput(out sanitizedInput);
		
			QueryArray(sanitizedInput);

			Console.WriteLine("Array Originale:");
			PrintArray(ints);
			Console.WriteLine("Array Invertito");
			PrintArray(intsReversed);
			
		}

		private void SetArray(int length)
		{
			
			for (int i = 0; i < length; i++)
			{
				Console.WriteLine($"Inserisci il numero nell'indice {i}");
				Program.SanitizeInput(out sanitizedInput);
				ints[i] = sanitizedInput;
				intsReversed[(length - 1) - i] = sanitizedInput;
			}
		}

		private void QueryArray(int n)
		{
			// O(n) as it scales linearly with collection size
			// Could be O(1) on fails if array is copied in hashset first to see if element is contained or not
			for(int i = 0; i < ints.Length; i++)
			{
				if (ints[i] == n)
				{
					Console.WriteLine($"Numero trovato all'indice {i}");
					return;
				}
			}

			Console.WriteLine("Elemento non trovato");

		}

		private void PrintArray(int[] array)
		{
			for(int i =0; i < array.Length; i++)
			{
				Console.WriteLine($"Indice: {i} - Numero: {array[i]}");
			}
		}

	}
}
