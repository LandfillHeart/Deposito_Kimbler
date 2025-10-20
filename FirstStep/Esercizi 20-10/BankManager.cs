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
		// there desperatly needs to be a way to make this dictionaries READONLY outside of the BankManager context
		// i dont want another programmer to casually do dictionary.Clear or overwrite data without permission
		public Dictionary<int, Client> AllClients = new Dictionary<int, Client>();
		public Dictionary<int, Account> AllAccounts = new Dictionary<int, Account>();
		public Dictionary<int, List<Operation>> AccountOperations = new Dictionary<int, List<Operation>>();
		#endregion

		#region Context
		private float standardWithdrawalCommission = 1f;
		private float premiumWithdrawalCommission = 0f;

		private string currency = "€";
		#endregion

		#region Account Operations
		public void MakeDeposit(Account account, float amount)
		{
			if(!account.Deposit(amount, out string result))
			{
				LogOperation(account, OperationType.Error, result);
				OnOperationError(account, errorMessage: result);
				return;
			}

			LogOperation(account, OperationType.Deposit, $"User {account.Id} deposited {currency}{amount}");
			OnDepositMade(account, amount);
		}

		public void MakeWithdrawal(Account account, float amount)
		{
			if(!account.Withdraw(amount, out string result))
			{
				LogOperation(account, OperationType.Error, result);
				OnOperationError(account, errorMessage: result);
				return;
			}

			LogOperation(account, OperationType.Withdraw, $"User {account.Id} withdrew {currency}{amount}");
			OnWithdrawalMade(account, amount);
		}

		private void LogOperation(Account account, OperationType operationType, string result)
		{
			if (!AllAccounts.ContainsKey(account.Id)) 
			{
				Console.WriteLine("Errore: L'operazione non è associabile a nessun account. Log annullato.");
				return;
			}

			if(!AccountOperations.ContainsKey(account.Id))
			{
				AccountOperations.Add(account.Id, new List<Operation>());
			}

			AccountOperations[account.Id].Add(new Operation(operationType, metaData: result));
 		}
		#endregion

		// strategy - it isn't quite clear to me yet how the pattern is applicable here
		// if we had a global strategy applicable to multiple entities and it changed depending on some global context, that'd be cool
		// or if we an entity using a strategy depending on local and global context, that'd be cool too
		// in this istance, it's not quite a "strategy" as much as a switch statement
		// if there was a clearer scope for the project (how different contexts change the strategy drastically) then it'd be easy to understand how it's useful, and implementing the strategy interface would make sense for extension
		#region Strategy
		private void GetCommission(Account account, Operation operation)
		{

		}
		#endregion


		#region Factory
		// no reason to have the factory methods anywhere else - we don't want users to create accounts that can't be validated by the server
		// although this could be its own singleton, to respect the Single Responsability Principle
		private int nextID = 1;
		private Account CreateAccount(AccountType type)
		{
			// assign value to newID, then immediately increase by 1
			int newID = nextID++;
			return new Account(newID, type);
		}

		public void AddAccount(AccountType type)
		{
			Account account = CreateAccount(type);
			AllAccounts.Add(account.Id, account);
			LogOperation(account, OperationType.Create, result: "Account succesfully created");
			OnAccountCreated(account);
		}
		#endregion

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

		private void OnWithdrawalMade(Account account, float amount)
		{
			foreach (IAccountObserver observer in observers)
			{
				observer.WithdrawalMade(account, amount);
			}
		}
		private void OnOperationError(Account account, string errorMessage)
		{
			foreach (IAccountObserver observer in observers)
			{
				observer.OperationError(account, errorMessage);
			}
		}
		#endregion

	}
}
