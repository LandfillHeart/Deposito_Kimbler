using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_13_10_Design_Pattern.Es_Singleton
{
	public class Es_LogHistory : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Singleton Lista di Log";

		public void Execute()
		{
			LogHistoryManager.Instance.CreateLog("Il mio primo messaggio");
			Console.WriteLine("Tutti i log finora: ");
			LogHistoryManager.Instance.PrintLogHistory();
			CreateLog("Il mio secondo messaggio");
			Console.WriteLine("Tutti i log finora: ");
			LogHistoryManager.Instance.PrintLogHistory();
		}

		private void CreateLog(string msg)
		{
			LogHistoryManager.Instance.CreateLog(msg);
		}
	}

	public class LogHistoryManager
	{
		private static LogHistoryManager instance;
		public static LogHistoryManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new LogHistoryManager();
				}
				return instance;
			}
		}

		private LogHistoryManager() { }

		private List<LoggedMessage> logHistory = new List<LoggedMessage>();

		public void CreateLog(string msg)
		{
			logHistory.Add(new LoggedMessage(msg));
		}

		public void CreateLog(LoggedMessage msg)
		{
			logHistory.Add(msg);
		}

		public void PrintLogHistory()
		{
			foreach (LoggedMessage log in logHistory)
			{
				Console.WriteLine(log.ToString());
			}
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
