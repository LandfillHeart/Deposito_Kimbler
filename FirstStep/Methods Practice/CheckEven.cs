using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class CheckEven : IGenericExercise
	{
		string IGenericExercise.Name => "Controllo Pari";
		private int sanitizedInput;

		public void Execute()
		{
			Console.WriteLine("Inserisci un numero intero");
			Program.SanitizeInput(out sanitizedInput);
			IsEven(sanitizedInput);
		}

		private void IsEven(int n)
		{
			string msg = n % 2 == 0 ? "pari" : "dispari";
			Console.WriteLine($"Il numero inserito è {msg}");
		}

	}
}
