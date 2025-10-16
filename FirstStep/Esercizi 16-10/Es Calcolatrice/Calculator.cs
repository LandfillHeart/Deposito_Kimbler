using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_16_10.Es_Calcolatrice
{
	public class Calculator
	{
		private IOperationStrategy currentStrategy;

		public Calculator()
		{
			currentStrategy = new SumStrategy(); // default value - no null reference error
		}

		public void SetStrategy(IOperationStrategy operationStrategy)
		{
			currentStrategy = operationStrategy;
		}

		public void SetStrategy(string chosenOperator)
		{
			if (string.IsNullOrWhiteSpace(chosenOperator))
			{
				Console.WriteLine("Operatore non riconosciuto");
				return;
			}

			switch (chosenOperator.Trim())
			{
				case "+":
					currentStrategy = new SumStrategy();
					break;
				case "-":
					currentStrategy = new SubtractionStrategy();
					break;
				case "*":
					currentStrategy = new MultiplicationStrategy();
					break;
				case "/":
					currentStrategy = new DivisionStrategy();
					break;
				default:
					Console.WriteLine("Operatore non riconosciuto");
					break;
			}
		}

		public float ExecuteOperationStrategy(float a, float b) 
		{
			if (currentStrategy == null)
			{
				Console.WriteLine("Strategia Mancante");
				return 0f;
			}
			return currentStrategy.Operate(a, b);
		}
	}
}
