using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application
{
	internal class ReadProduct
	{
		#region Dependency Injection
		private IProductRepository repository;
		public ReadProduct(IProductRepository repository) 
		{
			this.repository = repository;
		}
		#endregion

		// overload so we dont force programmers to declare a result they dont need
		public bool GetProduct(string id, out Product product)
		{
			return GetProduct(id, out product);
		}

		public bool GetProduct(string id, out Product product, out string result)
		{
			if(!repository.ContainsProduct(id))
			{
				product = null;
				result = "Couldn't find item in repository";
				return false;
			}

			product = repository.ReadProduct(id);
			result = "Item found";
			return true;
		}
	}
}
