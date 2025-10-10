using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Pagamento
{
	public class User
	{
		private int password;

		private int id;
		public int ID => id;

		private string name;
		public string Name => name;

		private double credit;
		public double Credit => credit;

		private List<IPayment> paymentHistory = new(); 
		public ReadOnlyCollection<IPayment> PaymentHistory => paymentHistory.AsReadOnly();

		public User(string name, string password)
		{
			this.password = password.GetHashCode();
			this.name = name;
			this.id = HashCode.Combine(name, DateTime.Now);
			credit = 100d;
		}

		public void ExecutePayment(IPayment payment, double amount)
		{
			if(payment.ExecutePayment(this, amount))
			{
				credit -= amount;
				paymentHistory.Add(payment);
			}
		}

		public bool ValidateSession(string password)
		{
			return this.password == password.GetHashCode();
		}
	}
}
