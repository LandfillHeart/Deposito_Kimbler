using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public class DisplayMobile : IObserver
	{
		private static int mobilesCreated = 0;
		private int mobileID;

		public DisplayMobile() 
		{
			mobileID = ++mobilesCreated;
		}

		public void Update(string msg)
		{
			Console.WriteLine($"Notifica: {msg} - ID Dispositivo Mobile: {mobileID}");
		}
	}
}
