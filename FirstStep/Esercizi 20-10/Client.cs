using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_20_10
{
	public class Client
	{
		public string Name { get; private set; }
	}

	public class Account
	{
		public int Id { get; private set; }
		public AccountType Type { get; private set; }
		public float Funds { get; private set; }

		public Account(int id, AccountType type)
		{
			Id = id;
			Type = type;
			Funds = 0f;
		}

		/// <summary>
		/// Adds Funds to Account. 
		/// </summary>
		/// <param name="amount">The amount to be added to Funds</param>
		/// <param name="result">Result or Error message</param>
		/// <returns>Returns false if amount <= 0</returns>
		public bool Deposit(float amount, out string result)
		{
			if (amount <= 0f) 
			{
				result = "Deposit can't be negative or zero";
				return false;
			}

			Funds += amount;
			result = "Deposit Completed";
			return true;
		}

		/// <summary>
		/// Removes Funds from Account.
		/// </summary>
		/// <param name="amount">The amount to be removed from Funds</param>
		/// <param name="result">Result of Error message</param>
		/// <returns>Returns false if amount > funds, or if amount <= 0 </returns>
		public bool Withdraw(float amount, out string result)
		{
			if (amount <= 0f) 
			{
				result = "Invalid Withdrawal: Negative or Zero";
				return false;
			}

			if (Funds - amount < 0f)
			{
				result = "Insufficient Funds";
				return false;
			}

			Funds -= amount;
			result = "Withdrawal Completed";
			return true;
		}
	}

	public struct Operation
	{
		public OperationType Type { get; private set; }
		public string MetaData { get; private set; }
		public DateTime TimeStamp { get; private set; }
		public Operation(OperationType type, string metaData)
		{
			Type = type;
			MetaData = metaData;
		}
	}

	public enum AccountType
	{
		Base,
		Premium,
		Student
	}

	public enum OperationType
	{
		Withdraw,
		Deposit,
		Create,
		Close,
		Error
	}
}
