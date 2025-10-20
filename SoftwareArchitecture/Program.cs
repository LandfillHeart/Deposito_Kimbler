public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Scegli un processore del pagamento: \n 0 - PayPall \n 1 - Stripe");
		int choice = int.Parse(Console.ReadLine());
		if (choice == 0)
		{
			new PaymentProcessor(new PayPallGateway());
		}
		else 
		{
			new PaymentProcessor(new StripeGateway());
		}
	}
}

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
	public void Greet();
}

public class ConsoleGreeter : IGreeter
{
	public void Greet()
	{
		Console.WriteLine("Hello, World!");
	}
}
#endregion

#region PaymentProcessor
public class PaymentProcessor
{
	private IPaymentGateway gateway;
	public PaymentProcessor(IPaymentGateway gateway)
	{
		this.gateway = gateway;
		gateway.DisplayGateway();
	}
}

public interface IPaymentGateway
{
	public void DisplayGateway();
}

public class PayPallGateway : IPaymentGateway
{
	public void DisplayGateway()
	{
		Console.WriteLine("Hai scelto PayPall");
	}
}
public class StripeGateway : IPaymentGateway
{
	public void DisplayGateway()
	{
		Console.WriteLine("Hai scelto Stripe");
	}
}

#endregion