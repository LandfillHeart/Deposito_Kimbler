using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class CalculatePower : IGenericExercise
	{
		string IGenericExercise.Name => "Calcolo Potenza";
		private int sanititzedInput;

		public void Execute()
		{
			Console.WriteLine("Inserisci un numero");
			Program.SanitizeInput(out sanititzedInput);
			int baseNum = sanititzedInput;

			Console.WriteLine("Inserisci un esponent");
			Program.SanitizeInput(out sanititzedInput);
			int exp = sanititzedInput;
			
			Console.WriteLine($"{baseNum} ^ {exp} = {PowerOf(baseNum, exp)}");
		}

		private int PowerOf(int baseNum, int exponent)
		{
			return (int)Math.Pow(baseNum, exponent);
		}

	}
}
