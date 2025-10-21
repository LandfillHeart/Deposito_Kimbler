using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.BookHub
{
	public class OrderService
	{
		// Order Service:
		// IInventoryService
		// IPaymentProcessor
		
		// INotificationSender
		// IPricingStrategy

		private IInventoryService storeInventory; // this is set at order construction, as the StoreManager uses a strategy to find out the correct service to provide
		private IPaymentProcessor paymentProcessor; // this is set at construction, by reading user saved data
	}
}
