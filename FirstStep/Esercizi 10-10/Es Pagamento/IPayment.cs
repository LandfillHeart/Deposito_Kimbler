using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Pagamento
{
	public enum PaymentType
	{
		Undefined = 0,
		Card,
		Cash,
		Paypal
	}
	internal interface IPayment
	{
		public abstract PaymentType Type { get; }
		public void ExecutePayment(double amount);
		public void ShowMethod();
	}

	internal class CardPayment : IPayment
	{
		private string circuit;
		public PaymentType Type => PaymentType.Card;

		public CardPayment(string circuit)
		{
			this.circuit = circuit;
		}

		public void ExecutePayment(double amount)
		{
			Console.WriteLine($"Pagamento di €{amount} con carta (Circuito: {circuit})");
		}

		public void ShowMethod()
		{
			Console.WriteLine("Metodo: Carta di credito");
		}
	}

	public class CashPayment : IPayment
	{
		public PaymentType Type => PaymentType.Cash;

		public void ExecutePayment(double amount)
		{
			Console.WriteLine($"Pagamento di €{amount} in contanti");
		}

		public void ShowMethod()
		{
			Console.WriteLine("Metodo: Contanti");
		}
	}

	public class PaypalPayment : IPayment
	{
		private string email;
		public PaymentType Type => PaymentType.Paypal;

		public PaypalPayment(string email)
		{
			this.email = email;
		}

		public void ExecutePayment(double amount)
		{
			Console.WriteLine($"Pagamento €{amount} tramite PayPal da: {email}");
		}

		public void ShowMethod()
		{
			Console.WriteLine("Metodo: PayPal");
		}
	}

}
