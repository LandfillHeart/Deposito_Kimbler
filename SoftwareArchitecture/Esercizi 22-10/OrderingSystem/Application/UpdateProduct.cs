using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application
{
	internal class UpdateProduct
	{
		#region Dependency Injection
		private IProductRepository repository;
		public UpdateProduct(IProductRepository repository)
		{
			this.repository = repository;
		}
		#endregion

		public bool Update(string id, string newName, float newPrice, out string result)
		{
			if(!repository.ContainsProduct(id))
			{
				result = "ERROR: product not found";
				return false;
			}

			if (string.IsNullOrEmpty(newName))
			{
				result = "ERROR: invalid name. No update applied to DB";
				return false;
			}

			if (newPrice <= 0f)
			{
				result = "ERROR: price is negative or zero. No update applied to DB";
				return false;
			}

			repository.UpdateProduct(id, newName, newPrice);
			result = "Item Updated";
			return true;
		}
	}
}
