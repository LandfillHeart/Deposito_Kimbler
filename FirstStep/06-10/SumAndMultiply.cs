using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._06_10
{
	internal class SumAndMultiply : IGenericExercise
	{
		string IGenericExercise.Name => "Somma e Moltiplica";
		private int sanitizedInput;	

		public void Execute()
		{
			Console.WriteLine("Inserisci il primo numero");
			Program.SanitizeInput(out sanitizedInput);
			int a = sanitizedInput;

			Console.WriteLine("Inserisci il secondo numero");
			Program.SanitizeInput(out sanitizedInput);

			PrintResult("Somma", Sum(a, sanitizedInput));
			PrintResult("Moltiplicazione", Multiply(a, sanitizedInput));

		}

		private int Sum(int a, int b)
		{
			return a + b;
		}

		private int Multiply(int a, int b)
		{
			return a * b;
		}

		private void PrintResult(string operation, int result)
		{
			Console.WriteLine($"Il risultato dell'operazione {operation} è: {result}");
		}

	}
}
