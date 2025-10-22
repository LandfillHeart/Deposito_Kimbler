using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Enums;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities
{
	internal class Order
	{
		public string ID { get; private set; }
		public List<OrderItem> OrderItems { get; private set; }
		public OrderStatus Status { get; private set; }

		public Order() 
		{
			OrderItems = new List<OrderItem>();
			Status = OrderStatus.New;
			ID = ID_Helper.CreateID(CategoryID.Order);
		}
	}
}
