using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_16_10.Es_Calcolatrice
{
	public class CalculatorApp : IGenericExercise
	{
		public string Name => "Calcolatrice - Strategy Pattern";

		public void Execute()
		{
			Console.WriteLine("Inserisci il primo numero");
			Program.SanitizeInput(out int nOne);

			Console.WriteLine("Inserisci il secondo numero");
			Program.SanitizeInput(out int nTwo);

			Console.WriteLine("Scegli un operatore: + - * /");
			Program.SanitizeInput(out string inputOperator);

			Calculator myCalc = new Calculator();
			myCalc.SetStrategy(inputOperator);
			Console.WriteLine($"{nOne} {inputOperator} {nTwo} = {myCalc.ExecuteOperationStrategy(nOne, nTwo)}");
		}
	}
}
