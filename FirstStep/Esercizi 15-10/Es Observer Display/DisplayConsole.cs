using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public class DisplayConsole : IObserver
	{

		public void Update(string msg)
		{
			Console.WriteLine($"Log: {msg}");
		}
	}
}
