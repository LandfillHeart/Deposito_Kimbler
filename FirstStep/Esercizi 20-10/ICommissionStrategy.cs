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

	public class WithdrawalCommission : ITransferCommissionStrategy
	{
		private float flatCommission = 1f;
		public float GetCommission(Account account, float amount)
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
			commission = 0f;
			return true;
		}

		/// <summary>
		/// Calculates the commission for operations that might not have an account linked yet (e.g. creating a new account)
		/// </summary>
		/// <param name="accountType">The abstract account we will be trying to work on</param>
		/// <param name="operation">What operation is being attempted</param>
		/// <returns>Returns true if this kind of commission can be applied to this operation</returns>
		public bool GetCommission(AccountType accountType, OperationType operationType, out float commission)
		{
			commission = 0f;
			return true;
		}
	}
}
