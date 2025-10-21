using SoftwareArchitecture.Esercizi_20_10;
using SoftwareArchitecture.Esercizi_21_10;
using ILogger = SoftwareArchitecture.Esercizi_21_10.ILogger;

namespace SoftwareArchitecture
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// in entrambi i casi stiamo facendo riferimento allo stesso singleton, ma nel secondo abbiamo la possibilità di sovrascrivere config se necessario
			
			FileUploaderApp myApp = new FileUploaderApp();
			myApp.Run();
		}
	}

	// piuttosto che riscrivere il main ogni volta, preferisco creare un oggetto di questa interfaccia e farlo girare nel main
	public interface IExecutable
	{
		public void Run();
	}
}
