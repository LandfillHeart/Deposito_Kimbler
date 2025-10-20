using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_20_10
{

	#region GreetingService
	public class GreetingService
	{
		private IGreeter myGreeter;
		public GreetingService(IGreeter greeter)
		{
			myGreeter = greeter;
			greeter.Greet();
		}
	}

	public interface IGreeter
	{
		public IGreetable ToGreet { get; }
		public void Greet();
	}

	public class ConsoleGreeter : IGreeter
	{
		public IGreetable ToGreet { get; private set; }
		public void Greet()
		{
			Console.WriteLine($"Ciao, {ToGreet.Name}!");
		}
		public ConsoleGreeter(IGreetable toGreet)
		{
			ToGreet = toGreet;
		}
	}

	public interface IGreetable
	{
		public string Name { get; }
	}

	public class User : IGreetable
	{
		public string Name { get; private set; }
		public User(string name)
		{
			Name = name;
		}
	}
	#endregion

	#region PaymentProcessor
	public class PaymentProcessor
	{
		private IPaymentGateway gateway;
		private IBank bank;
		public PaymentProcessor(IPaymentGateway gateway, IBank bank)
		{
			this.gateway = gateway;
			this.bank = bank;
		}

		public void ProcessPayment()
		{
			Console.WriteLine($"Pagamento effettuato tramite {gateway.GetGateway()} verso {bank.Name}");
		}
	}

	public interface IPaymentGateway
	{
		public string GetGateway();
	}

	public class PayPallGateway : IPaymentGateway
	{
		public string GetGateway()
		{
			return "Paypall";
		}
	}
	public class StripeGateway : IPaymentGateway
	{
		public string GetGateway()
		{
			return "Stripe";
		}
	}

	public interface IBank
	{
		public string Name { get; }
	}

	public class SanpaoloBank : IBank
	{
		public string Name => "Sanpaolo";
	}

	public class AllianzBank : IBank
	{
		public string Name => "Allianz";
	}


	#endregion
}
