using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_13_10_Design_Pattern.Es_Singleton.Log_History
{
	public sealed class LogHistoryManager
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
}
