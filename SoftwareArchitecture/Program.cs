using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Presentation;

namespace SoftwareArchitecture
{
	public class Program
	{
		
		public static void Main(string[] args)
		{
			ConsoleUI.Instance.StartSession();
			ConsoleUI.Instance.InteractiveMenu();
		}
	}

	// piuttosto che riscrivere il main ogni volta, preferisco creare un oggetto di questa interfaccia e farlo girare nel main
	public interface IExecutable
	{
		public void Run();
	}
}
