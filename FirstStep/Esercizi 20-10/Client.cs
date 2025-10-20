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

		public bool Deposit(float amount)
		{
			if (amount <= 0f) 
			{
				// Deposit cant be negative or zero
				return false;
			}

			Funds += amount;
			return true;
		}

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
		Close
	}
}
