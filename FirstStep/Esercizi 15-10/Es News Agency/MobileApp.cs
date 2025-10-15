using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_News_Agency
{
	public class MobileApp : INewsSubscriber
	{
		public ClientType Type => ClientType.Mobile;
		public void Update(string msg)
		{
			Console.WriteLine($"Notification on mobile: {msg}");
		}
	}
}
