using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Pagamento
{
	internal class Es_Pagamento : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Pagamento";
		private List<IPayment> payments = new List<IPayment>() { 
			new CardPayment("Visa"),
			new CashPayment(),
			new PaypalPayment("tester@formatemp.net")
		};

		public void Execute()
		{
			foreach (IPayment payment in payments)
			{ 
				MakePayment(payment);
			} 
		}

		private void MakePayment(IPayment payment)
		{
			Console.WriteLine("Sei costretto ad eseguire questo pagamento");
			payment.ShowMethod();
			Console.WriteLine("Inserisci l'importo");
			Program.SanitizeInput(out double amount, mustBePositive: true);
			payment.ExecutePayment(amount);
		}
	}
}
