using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.Esercizi_Semplici.AlertService
{
	public class AlertServiceApp : IExecutable
	{
		public void Run()
		{
			AlertService myService = new AlertService();
			myService.SendAlert("Messaggio SPAM", new SmsNotifier());
		}
	}

	public interface INotifier
	{
		public void SendMessage(string message);
	}

	public class SmsNotifier : INotifier
	{
		public void SendMessage(string message)
		{
			Console.WriteLine($"Nuovo SMS: {message}");
		}
	}

	public class AlertService
	{
		public void SendAlert(string message, INotifier notifier)
		{
			notifier.SendMessage(message);
		}
	}
}
