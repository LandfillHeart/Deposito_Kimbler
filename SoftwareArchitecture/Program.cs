using SoftwareArchitecture.Esercizi_20_10;

namespace SoftwareArchitecture
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// in entrambi i casi stiamo facendo riferimento allo stesso singleton, ma nel secondo abbiamo la possibilità di sovrascrivere config se necessario
			OrderService firstOrderService = new OrderService(new LoggerService(), new List<string>() { "Ordine #12 in arrivo domani!", "Ordine #98 Annullato", "Ordine #77 in arrivo tra 3 giorni" });
			OrderService secondOrderService = new OrderService(new LoggerService(OrderAppContext.Instance), new List<string>() { "Ordine #8 annullato!", "Ordine #11 in arrivo tra 6 giorni"});

			firstOrderService.GetOrderStatus();
			secondOrderService.GetOrderStatus();
		}
	}
}
