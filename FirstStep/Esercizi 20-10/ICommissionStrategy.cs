using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_20_10
{
	public interface ITransferCommissionStrategy
	{
		public float GetCommission(Account account, float amount);
	}

	public interface IAccountTypedCommission
	{
		public float GetCommission(AccountType accountType);
	}

	// static attributes could be retrieved from BankManager/Context later
	public class WithdrawalCommission : ITransferCommissionStrategy
	{
		// nested strategies
		private float flatCommissionTreshold = 200f;
		public float GetCommission(Account account, float amount)
		{
			ITransferCommissionStrategy typeOfCommission = amount switch
			{
				float n when amount < flatCommissionTreshold => new FlatCommission(),
				_ => new PercentualCommission(),
			};

			return typeOfCommission.GetCommission(account, amount);
		}

		private class FlatCommission : ITransferCommissionStrategy
		{
			public float GetCommission(Account account, float amount)
			{
				return account.Type switch
				{
					AccountType.Base => 1f,
					AccountType.Premium => 0.3f,
					AccountType.Student => 0.45f,
				};
			}

		}

		private class PercentualCommission : ITransferCommissionStrategy
		{
			public float GetCommission(Account account, float amount)
			{
				float percentual = account.Type switch
				{
					AccountType.Base => 3f,
					AccountType.Premium => 1f,
					AccountType.Student => 1.9f,
				};

				return (amount * percentual) / 100;
			}
		}
	}

	public class DepositCommission : ITransferCommissionStrategy
	{
		private float flatCommission = 1f;
		private float commissionTreshold = 10f;
		public float GetCommission(Account account, float amount)
		{
			// if account is standard / premium / student... do something
			float commission = 0f;
			if(amount > commissionTreshold)
			{
				commission = flatCommission;
			}
			return commission;
		}
	}

	public class CreateAccountCommission : IAccountTypedCommission
	{
		private float flatCommission = 20f;
		public float GetCommission(AccountType type)
		{
			// if account is standard / premium / student... do something
			return flatCommission;
		}
	}

	// there is no point to have a context/applicable strategy here, because it will literally change with every single operation made
	// it's bettere to use this more like a factory, creating a disposable strategy and using it on the spot to get the correct commission
	// there's no use to save the strategy because the context will change constantly and saving the strategy doesn't help us
	// in this case, the programmer should be able to realize they are calling the wrong method based on the params
	// strategy is still applied because there can be a million variations on how much a withdrawal can cost (for example), but it must be explicit that a transfer is being made
	// if we didn't make explicit what type of operation we would be making, then the following would happen
	// 1. every time we want to get commission, we would have to provide a ton of context, which might not even exist when we make the operation (e.g. when creating a new account)
	// 2. every time we add a new strategy which requires a more complex context, we would have to refactor EVERY CALL TO COMMISSION CONTEXT so that it would provide the new full context
	public class CommissionContext
	{
		/// <summary>
		/// Calculates the commission for operations which involve a transfer (e.g. Deposit and Withdraw)
		/// </summary>
		/// <param name="account">The account attempting the operation</param>
		/// <param name="operationType">What operation is being attempted</param>
		/// <param name="transferAmount">The amount of money being transfered</param>
		/// <returns>Returns true if this kind of commission can be applied to this operation</returns>
		public bool GetCommission(Account account, OperationType operationType, float transferAmount, out float commission)
		{
			switch (operationType)
			{
				case OperationType.Deposit:
					commission = new DepositCommission().GetCommission(account, transferAmount);
					return true;
				case OperationType.Withdraw:
					commission = new WithdrawalCommission().GetCommission(account, transferAmount);
					return true;
				default:
					commission = 0f;
					return false;
			}
		}

		/// <summary>
		/// Calculates the commission for operations that might not have an account linked yet (e.g. creating a new account)
		/// </summary>
		/// <param name="accountType">The abstract account we will be trying to work on</param>
		/// <param name="operation">What operation is being attempted</param>
		/// <returns>Returns true if this kind of commission can be applied to this operation</returns>
		public bool GetCommission(AccountType accountType, OperationType operationType, out float commission)
		{
			switch (operationType)
			{
				case OperationType.Create:
					commission = new CreateAccountCommission().GetCommission(accountType);
					return true;
				default:
					commission = 0f;
					return false;
			}
		}
	}
}
