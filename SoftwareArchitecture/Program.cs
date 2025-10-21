using SoftwareArchitecture.Esercizi_21_10.Esercizi_Semplici;
using SoftwareArchitecture.Esercizi_21_10.Esercizi_Semplici.AlertService;

namespace SoftwareArchitecture
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// in entrambi i casi stiamo facendo riferimento allo stesso singleton, ma nel secondo abbiamo la possibilità di sovrascrivere config se necessario

			new DataExporterApp().Run();
		}
	}

	// piuttosto che riscrivere il main ogni volta, preferisco creare un oggetto di questa interfaccia e farlo girare nel main
	public interface IExecutable
	{
		public void Run();
	}
}
