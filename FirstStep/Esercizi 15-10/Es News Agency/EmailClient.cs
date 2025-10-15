using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_News_Agency
{
	public class EmailClient : INewsSubscriber
	{
		public ClientType Type => ClientType.Email;
		public void Update(string msg)
		{
			Console.WriteLine($"Email Sent: {msg}");
		}
	}
}
