using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities
{
	internal class Order
	{
		public List<OrderItem> OrderItems { get; private set; }
		public OrderStatus Status { get; private set; }
	}
}
