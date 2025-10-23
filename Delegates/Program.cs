public class Program
{
	public delegate int Operation(int x, int y);

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

	public static void Main()
	{
		Console.WriteLine("Inserisci il tuo nome");
		string user = Console.ReadLine();

		Console.WriteLine("Quale tipo di operazione vuoi effettuare? +/*");
		string op = Console.ReadLine();



		Operation sumDelegate = op.Contains("*") ? Mult : Sum;

		int x = 5;
		int y = 10;
		Console.WriteLine($"{user} ha eseguito l'operazione {x} {op} {y} = {ExecuteOperation(sumDelegate, x, y)}");
	}
}