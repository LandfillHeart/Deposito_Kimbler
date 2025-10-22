using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Infrastructure
{
	internal class Database : IProductRepository
	{
		#region
		private static Database instance;
		public static Database Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new Database();
				}
				return instance;
			}
		}
		private Database() { }
		#endregion

		private Dictionary<string, Product> products = new Dictionary<string, Product>();
		private Dictionary<string, Order> orders = new Dictionary<string, Order>();
		private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();

		public ReadOnlyCollection<string> ProductIDs => products.Keys.ToList().AsReadOnly();
		// Database has to be as gullible and clueless as possibile
		// It has to be possible to do whatever kind of destructive mess we want right here
		// That's because, all logic to make sure something is correct, MUST HAPPEN on the Application layer
		#region CRUD - Products
		public void CreateProduct(string name, float price)
		{
			Product newProd = new Product(name, price);
			products.Add(newProd.ID, newProd);
		}

		public bool ContainsProduct(string id)
		{
			return products.ContainsKey(id);
		}

		public Product ReadProduct(string id)
		{
			return products[id];
		}

		public void UpdateProduct(string id, string newName, float newPrice)
		{
			products[id].Name = newName;
			products[id].Price = newPrice;
		}

		public void DeleteProduct(string id)
		{  
			products.Remove(id); 
		}
		#endregion
	}
}
