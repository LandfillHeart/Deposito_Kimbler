using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Interfaces
{
	internal interface IProductRepository
	{
		public void CreateProduct(string name, float price);
		public bool ContainsProduct(string id);
		public Product ReadProduct(string id);
		public void UpdateProduct(string id, string newName, float price);
		public void DeleteProduct(string id);
	}
}
