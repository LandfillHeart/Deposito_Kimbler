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
			commissionContext.GetCommission(account, OperationType.Deposit, amount, out float commission);
			// we take a small amount from their deposit to pay for the commission
			amount -= commission;
			if (amount <= 0f)
			{
				string error = "L'importo inserito risulta non superare la commissione per deposito, operazione annullata";
				LogOperation(account, OperationType.Error, error);
				OnOperationError(account, error);
			}

			if (!account.Deposit(amount, out string result))
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
			commissionContext.GetCommission(account, OperationType.Withdraw, amount, out float commission);
			if (!account.Withdraw(amount + commission, out string result))
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
		private CommissionContext commissionContext = new CommissionContext();
		#endregion


		#region Factory / CRUD
		// no reason to have the factory methods anywhere else - we don't want users to create accounts that can't be validated by the server
		// although this could be its own singleton, to respect the Single Responsability Principle
		private int nextID = 1;
		private Account CreateAccount(AccountType type)
		{
			// assign value to newID, then immediately increase by 1
			int newID = nextID++;
			return new Account(newID, type);
		}

		/// <summary>
		/// Creates a new account if the user pays the creation commission
		/// </summary>
		/// <param name="type"></param>
		/// <param name="accountDeposit"></param>
		/// <param name="accountID">The ID of the account, if successful</param>
		/// <returns>Returns true if the funds meet the requirements for creating the account</returns>
		public bool AddAccount(AccountType type, float accountDeposit, out int accountID)
		{
			commissionContext.GetCommission(type, OperationType.Create, out float commission);
			accountID = -1;

			if(accountDeposit < commission)
			{
				Console.WriteLine($"Cannot create account, cost of account creation not met");
				Console.WriteLine($"Cost of creating {type} account: {commission}. Deposit made: {accountDeposit}");
				Console.WriteLine("Your deposit will be returned");
				// no reason to log this - there is no account to be associated
				return false;
			}

			Account account = CreateAccount(type);
			AllAccounts.Add(account.Id, account);
			Console.WriteLine(AllAccounts[account.Id]);
			LogOperation(account, OperationType.Create, result: "Account succesfully created");
			OnAccountCreated(account);
			accountID = account.Id;
			return true;
		}

		public void RemoveAccoubt(int accountID)
		{
			if(!AllAccounts.ContainsKey(accountID))
			{
				Console.WriteLine($"Cannot delete account, it can't be found!");
				return;
			}

			float existingFunds = AllAccounts[accountID].Funds;
			Console.WriteLine($"Account Chiuso. Ti saranno resituiti i tuoi fondi: {currency}{existingFunds}");
			LogOperation(AllAccounts[accountID], OperationType.Close, "Account Chiuso da Utente");
			OnAccountClosed(AllAccounts[accountID]);
			AllAccounts.Remove(accountID);
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
