using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Enums;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities
{
	internal class Product
	{
		public string ID { get; private set; }
		public string Name { get; set; }
		public float Price { get; set; }

		public Product(string name, float price)
		{
			Name = name;
			Price = price;
			ID = ID_Helper.CreateID(CategoryID.Product);
		}
	}
}
