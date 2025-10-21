using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.Notification_System
{
	public class MessangerApp : IExecutable
	{
		public void Run()
		{
			Console.WriteLine("Scegliere il tipo di notifica:");
			Console.WriteLine("0 - SMS");
			Console.WriteLine("1 - Email");
			Console.WriteLine("2 - Push");

			string input = Console.ReadLine();
			// string -> int -> enum
			MessageType chosenType = (MessageType)int.Parse(input);
			MessagingService myService = new MessagingService(NotifierFactory.CreateNotifier(chosenType));

			myService.SendMessage("Grazie per esserti iscritto alle notifiche");
		}
	}

	public enum MessageType
	{
		SMS,
		Email,
		Push
	}

	public class MessagingService
	{
		private INotifier notifier;
		public MessagingService(INotifier notifier)
		{
			this.notifier = notifier;
		}

		public void SendMessage(string msg)
		{
			notifier.SendNotification(msg);
		}
	}

	public class NotifierFactory
	{
		public static INotifier CreateNotifier(MessageType type)
		{
			return type switch
			{
				MessageType.SMS => new SmsNotifier(),
				MessageType.Email => new EmailNotifier(),
				MessageType.Push => new PushNotifier(),
			};
		}
	}

	public interface INotifier
	{
		public MessageType MessageType { get; }
		public void SendNotification(string msg);
	}

	public class SmsNotifier : INotifier
	{
		public MessageType MessageType => MessageType.SMS;
		public void SendNotification(string msg)
		{
			Console.WriteLine($"Nuovo SMS: {msg}");
		}
	}

	public class EmailNotifier : INotifier
	{
		public MessageType MessageType => MessageType.Email;
		public void SendNotification(string msg)
		{
			Console.WriteLine($"Nuova Email: {msg}");
		}
	}

	public class PushNotifier : INotifier
	{
		public MessageType MessageType => MessageType.Push;

		public void SendNotification(string msg)
		{
			Console.WriteLine($"Notifica Pop-Up: {msg}");
		}
	}
}
