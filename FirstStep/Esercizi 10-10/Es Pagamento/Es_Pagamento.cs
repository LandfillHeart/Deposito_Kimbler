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

		private User user;

		public void Execute()
		{
			if (user == null)
			{
				Console.WriteLine("Benvenuto, esegui la registrazione");
				Console.WriteLine("Inserisci il tuo nome");
				Program.SanitizeInput(out string username);
				Console.WriteLine("Inserisci una password");
				Program.SanitizeInput(out string password);

				user = new User(username, password);
			}

			foreach (IPayment payment in payments)
			{
				MakePayment(user, payment);
			}

			Console.WriteLine("Pagamenti effettuati");
			foreach (IPayment payment in user.PaymentHistory)
			{
				payment.ShowMethod();
			}
		}

		private void MakePayment(User user, IPayment payment)
		{

			Console.WriteLine("Sei costretto ad eseguire questo pagamento");
			payment.ShowMethod();
			Console.WriteLine("Inserisci la tua password per validare il pagamento");
			Program.SanitizeInput(out string pw);
			if(!user.ValidateSession(pw))
			{
				Console.WriteLine("Hai sbagliato password, pagamento annullato");
				return;
			}

			Console.WriteLine("Inserisci l'importo");
			Program.SanitizeInput(out double amount, mustBePositive: true);
			user.ExecutePayment(payment, amount);
		}
	}
}
