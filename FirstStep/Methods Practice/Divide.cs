using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class Divide : IGenericExercise
	{
		string IGenericExercise.Name => "Dividi";
		private int sanitizedInput;

		public void Execute()
		{
			Console.WriteLine("Inserisci il dividendo");
			Program.SanitizeInput(out sanitizedInput);
			int divider = sanitizedInput;

			Console.WriteLine("Inserisci il divisore");
			Program.SanitizeInput(out sanitizedInput);
			int divisor = sanitizedInput;

			if (DivideInts(divider, divisor, out int result, out int mod)) 
			{
				Console.WriteLine($"{divider} / {divisor} = {result} mod {mod}");
			}
			else
			{
				Console.WriteLine("Non è possibile dividere per zero");
				return;
			}
		}
	
		private bool DivideInts(int divider, int divisor, out int result, out int mod)
		{
			result = 0;
			mod = 0;
			if (divisor == 0)
			{
				return false;
			}

			result = divider / divisor;
			mod = divider % divisor;
			return true;

		}

	}
}
