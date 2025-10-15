using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_User_Manager
{
	public class UserManager : IUserCreationNotifier
	{
		#region Singleton
		private static UserManager instance;
		public static UserManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new UserManager();
				}
				return instance;
			}
		}

		// quando andiamo a creare il nostro UserManager, sappiamo che MarketingManager e LogManager devono essere iscritti
		// per questro motivo li iscriviamo nel costruttore, così che già dalla prima chiamata possono essere notificati dei cambiamenti di stato
		private UserManager() 
		{
			AddSubscriber(MarketingManager.Instance);
			AddSubscriber(LogManager.Instance);
		}
		#endregion

		private HashSet<IUserCreationObserver> observers = new HashSet<IUserCreationObserver>();

		private List<User> users = new List<User>();

		public void CreateUser(string name)
		{
			User newUser = (UserFactory.CreateUser(name));
			users.Add(newUser);
			Notify(newUser);
		}

		#region Notifier
		public void AddSubscriber(IUserCreationObserver observer)
		{
			observers.Add(observer);
		}
		public void RemoveSubscriber(IUserCreationObserver observer)
		{
			observers.Remove(observer);
		}

		public void Notify(User newUser)
		{
			foreach (IUserCreationObserver observer in observers) 
			{
				observer.NotifyCreation(newUser);
			}
		}
		#endregion
	}
}
