using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_13_10_Design_Pattern.Es_Singleton
{
	public class Es_LogSingleton : IGenericExercise
	{
		public string Name => "Esercizio Log Console Singleton";
		// in questo caso, stiamo inserendo il riferimento in una variabile, per poi dimostrare che stiamo facendo riferimento allo stesso oggetto
		private LogManager logManagerCache = LogManager.Instance;
		private string messageOne = "Chiamo singleton da una metodo";
		private string messageTwo = "Chiamo singleton da un secondo metodo";

		public void Execute()
		{
			logManagerCache.PrintMessage(messageOne);
			PrintMessage();

			// paragoniamo i riferimenti
			Console.WriteLine($"Stiamo facendo riferimento allo stesso oggetto? {logManagerCache.Equals(LogManager.Instance)}");
		}

		public void PrintMessage()
		{
			LogManager.Instance.PrintMessage(messageTwo);
		}
	}

	public class LogManager
	{
		private static LogManager instance;
		public static LogManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new LogManager();
				}

				return instance;
			}
		}

		private LogManager() { }

		public void PrintMessage(string msg)
		{
			Console.WriteLine($"{msg} - {DateTime.Now}");
		}
	}
}
