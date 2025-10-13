using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_13_10_Design_Pattern.Es_Singleton.Log_History
{
	public class Es_LogHistory : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Singleton Lista di Log";

		public void Execute()
		{
			LogHistoryManager.Instance.CreateLog("Il mio primo messaggio");
			LogHistoryManager.Instance.CreateLog("Il mio secondo messaggio");
			Console.WriteLine("Tutti i log finora: ");
			LogHistoryManager.Instance.PrintLogHistory();

			PopulateLocationManager();
			Console.WriteLine($"Ti saluta un utente da {LocationManager.Instance.GetRandomLocation()}");

			Console.WriteLine("Oggi ti raccomandiamo i seguenti libri di Stephen King");
			BookStoreManager.Instance.PrintBooksByAuthor("Stephen King");
		}

		private void PopulateLocationManager()
		{
			LocationManager.Instance.AddLocation("Napoli");
			LocationManager.Instance.AddLocation("Bologna");
			LocationManager.Instance.AddLocation("Milano");
			LocationManager.Instance.AddLocation("Roma");
			LocationManager.Instance.AddLocation("Venezia");
		}
	}

	public class LoggedMessage
	{
		public string Message { get; private set; }
		public DateTime Time { get; private set; }

		public LoggedMessage(string message)
		{
			this.Message = message;
			Time = DateTime.Now;
		}

		public override string ToString()
		{
			return $"{Message} - {Time}";
		}
	}
}
