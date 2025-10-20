public class Program
{
	public static void Main(string[] args)
	{
		GreetingService myService = new GreetingService(new ConsoleGreeter());
	}
}

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