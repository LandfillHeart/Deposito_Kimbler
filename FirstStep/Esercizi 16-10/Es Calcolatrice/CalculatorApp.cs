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
			CalculatorUser.Instance.LogIn();
			while(true)
			{
				Console.WriteLine("Vuoi effettuare un operazione? \n0 - No \n1 - Si");
				Program.SanitizeInput(out int choice);
				if (choice == 0)
				{
					Console.WriteLine("Grazie per aver usato la mia calcolatrice");
					CalculatorUser.Instance.LogOut();
					break;
				}
				CalculatorUser.Instance.Operate();
 			}
		}
	}
}
