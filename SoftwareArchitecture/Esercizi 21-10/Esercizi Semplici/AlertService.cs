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
			myService.SendAlert("DI Method", new SmsNotifier());

			ConstructorAlertService myCtrService = new ConstructorAlertService(new SmsNotifier());
			myCtrService.SendAlert("DI Constructor");

			SetterAlertService mySetterService = new SetterAlertService();
			mySetterService.SendAlert("Non leggerai mai questo messaggio");
			mySetterService.Notifier = new SmsNotifier();
			mySetterService.SendAlert("DI Setter");
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

	public class ConstructorAlertService
	{
		private INotifier notifier;
		public ConstructorAlertService(INotifier notifier)
		{
			this.notifier = notifier;
		}

		public void SendAlert(string message)
		{
			notifier.SendMessage(message);
		}
	}

	public class SetterAlertService
	{
		public INotifier Notifier { private get; set; }

		public void SendAlert(string message)
		{
			if(Notifier == null)
			{
				Console.WriteLine("Error: Dipendenza Mancante");
				return;
			}
			Notifier.SendMessage(message);
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
