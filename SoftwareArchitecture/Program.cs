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

			Printer myPrinter = new Printer();
			myPrinter.Print();

			myPrinter.Logger = new SimpleLogger("App Stampante: Hai stampato");
			myPrinter.Print();

			myPrinter.Logger = new SimpleLogger("App Desktop: Hai stampato");
			myPrinter.Print();

			#region CSTR Injection con Decorator
			/*
			OrderService firstOrderService = new OrderService(new LoggerService(), new List<string>() { 
				"Ordine #12 in arrivo domani!", "Ordine #98 Annullato", "Ordine #77 in arrivo tra 3 giorni" });

			IAppConfig defaultConfig = OrderAppContext.Instance;
			IAppConfig betaConfig = new BetaContext(defaultConfig);

			OrderService secondOrderService = new OrderService(new LoggerService(betaConfig), new List<string>() { 
				"Ordine #8 annullato!", "Ordine #11 in arrivo tra 6 giorni"});

			firstOrderService.GetOrderStatus();
			secondOrderService.GetOrderStatus();
			*/
			#endregion
		}
	}
}
