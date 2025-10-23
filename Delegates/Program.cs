public class Program
{
	public static event Action<string> LogOperation;
	public delegate int Operation(int x, int y);
	public delegate void Logger(string msg);

	public static int Sum(int x, int y)
	{
		return x + y;
	}

	public static int Mult(int x, int y)
	{
		return x * y;
	}

	public static int ExecuteOperation(Operation delegateOperation, int x, int y)
	{
		return delegateOperation(x, y);
	}

	public static void ConsoleLog(string message)
	{
		Console.WriteLine($"Nuovo messaggio console: {message}");
	}

	public static void FileLog(string message)
	{
		Console.WriteLine($"Log salvato su file: {message}");
	}

	public static void Main()
	{
		LogOperation += ConsoleLog;
		LogOperation += FileLog;

		Logger logDelegate = ConsoleLog;
		logDelegate += FileLog;


		Console.WriteLine("Inserisci il tuo nome");
		string user = Console.ReadLine();

		Console.WriteLine("Quale tipo di operazione vuoi effettuare? +/*");
		string op = Console.ReadLine();

		Operation opDelegate = op.Contains("*") ? Mult : Sum;

		int x = 5;
		int y = 10;
		LogOperation?.Invoke($"{user} ha eseguito l'operazione {x} {op} {y} = {opDelegate(x, y)}");
		logDelegate($"Delegate dice: {user} ha eseguito l'operazione {x} {op} {y} = {ExecuteOperation(opDelegate, x, y)}");
	}
}