using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_20_10
{
	public class BankManager
	{
		#region Singleton
		private static BankManager instance;
		public static BankManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new BankManager();
				}
				return instance;
			}
		}
		private BankManager() 
		{
			AddObserver(LogManager.Instance);
		}
		#endregion

		#region Dictionaries
		public Dictionary<int, Client> AllClients = new Dictionary<int, Client>();
		public Dictionary<int, Account> AllAccounts = new Dictionary<int, Account>();
		public Dictionary<int, List<Operation>> AccountOperations = new Dictionary<int, List<Operation>>();
		#endregion

		#region Context
		#endregion

		// strategy - hidden to program
		// factory - visible to program

		#region Observers
		private HashSet<IAccountObserver> observers = new HashSet<IAccountObserver>();
		public void AddObserver(IAccountObserver observer)
		{
			observers.Add(observer);
		}

		public void RemoveObserver(IAccountObserver observer)
		{
			observers.Remove(observer);
		}

		private void OnAccountCreated(Account account) 
		{
			foreach (IAccountObserver observer in observers) 
			{ 
				observer.AccountCreated(account);
			}
		}

		private void OnAccountClosed(Account account)
		{
			foreach (IAccountObserver observer in observers)
			{
				observer.AccountClosed(account);
			}
		}

		private void OnDepositMade(Account account, float amount)
		{
			foreach (IAccountObserver observer in observers)
			{
				observer.DepositMade(account, amount);
			}
		}
		#endregion

	}
}
