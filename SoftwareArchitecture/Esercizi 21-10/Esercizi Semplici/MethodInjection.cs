using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.Esercizi_Semplici.MethodInjection
{
	public class MethodInjection : IExecutable
	{
		public void Run() 
		{
			INotifier notifier = new EmailNotifier();
			NotificationService service = new NotificationService();
			service.SendNotification("Ray", notifier);
		}
	}

	public interface INotifier
	{
		public void Notify(string message);
	}

	public class EmailNotifier : INotifier
	{
		public void Notify(string message) 
		{ 
			Console.WriteLine($"Invio Email: {message}");
		}
	}

	public class NotificationService
	{
		public void SendNotification(string user, INotifier notifier)
		{
			notifier.Notify($"Ciao {user}, hai una nuova notifica!");
		}
	}
}
