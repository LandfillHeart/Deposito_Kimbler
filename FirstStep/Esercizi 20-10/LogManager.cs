using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_20_10
{
	// observer
	public class LogManager : IAccountObserver
	{
		#region Singleton
		private static LogManager instance;
		public static LogManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new LogManager();
				}
				return instance;
			}
		}
		private LogManager() { }

		public void AccountCreated(Account newAccount)
		{
			Console.WriteLine($"Caro admin, è stato creato un nuovo conto - ID: ");
		}

		public void AccountClosed(Account closedAccount)
		{
			Console.WriteLine($"Caro admin, è stato chiuso un conto");
		}

		public void DepositMade(Account account, float amount)
		{
			Console.WriteLine($"Caro admin, un cliente ha fatto un deposito");
		}

		public void WithdrawalMade(Account account, float amount)
		{
			Console.WriteLine($"Caro admin, un cliente ha fatto un ritiro");
		}

		public void OperationError(Account account, string error)
		{
			Console.WriteLine($"Caro admin, un operazione non è andata a buon fine");
			Console.WriteLine($"User ID: {account.Id} - Error Message: {error}");
		}
		#endregion


	}

	public interface IAccountObserver
	{
		public void AccountCreated(Account newAccount);
		public void AccountClosed(Account closedAccount);
		public void DepositMade(Account account, float amount);
		public void WithdrawalMade(Account account, float amount);
		public void OperationError(Account account, string error);
	}

}
