public class Program
{
	public static void Main(string[] args)
	{
		IGreetable toGreet = new User("Ray");
		IGreeter messagePrinter = new ConsoleGreeter(toGreet);
		GreetingService myService = new GreetingService(messagePrinter);
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