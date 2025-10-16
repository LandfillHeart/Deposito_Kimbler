using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_16_10.Es_Calcolatrice
{
	public class CalculatorUser
	{
		private static CalculatorUser instance;
		public static CalculatorUser Instance
		{
			get 
			{
				if(instance == null)
				{
					instance = new CalculatorUser();
				}
				return instance;
			}
		}

		private CalculatorUser() 
		{
			LoggedIn = false;
		}

		public bool LoggedIn { get; private set; }
		public string UserName { get; private set; }

		public void LogIn()
		{
			if (LoggedIn)
			{
				Console.WriteLine("Log In non necessario: utente già online");
			}
			Console.WriteLine("Inserisci il tuo account per fare log-in");
			Program.SanitizeInput(out string username);
			UserName = username;
			LoggedIn = true;
		}

		public void LogOut()
		{
			LoggedIn = false;
		}

		public void Operate()
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
