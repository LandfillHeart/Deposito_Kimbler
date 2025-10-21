using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10
{
	public class Printer
	{
		public ILogger Logger { get; set; }

		public void Print()
		{
			Console.WriteLine("Stampa Eseguita!");
			if (Logger == null)
			{
				Console.WriteLine("Nessun dispositivo di log collegato");
				return;
			}
			Logger.Log();
		}
	}

	public interface ILogger
	{
		public void Log();
	}

	public class SimpleLogger : ILogger
	{
		public string Message { get; set; }
		public SimpleLogger(string msg)
		{
			Message = msg;
		}

		public void Log()
		{
			Console.WriteLine(Message);
		}
	}
}
