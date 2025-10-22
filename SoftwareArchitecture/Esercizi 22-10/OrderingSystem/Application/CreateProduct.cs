using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Interfaces;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application
{
	internal class CreateProduct
	{
		#region Dependency Injection
		// a CreateProduct instance has to be linked to a repository to work, and likely we dont want to change repo past construction
		private IProductRepository repository;
		public CreateProduct(IProductRepository repository)
		{
			this.repository = repository;
		}
		#endregion

		// overload so we don't force others to declare the result when calling the func when they don't want/need it
		public bool CreateNewProduct(string productName, float productPrice)
		{
			return CreateNewProduct(productName, productPrice, out string dumpResult);
		}

		public bool CreateNewProduct(string productName, float productPrice, out string result)
		{
			if (string.IsNullOrWhiteSpace(productName))
			{
				result = "ERROR: product name is null or white space. Will not add to DB";
				return false;
			}

			if (productPrice <= 0f)
			{
				result = "ERROR: product price is negative or zero. Will not add to DB";
				return false;
			}

			repository.CreateProduct(productName, productPrice);
			result = "Item successfully added to DB";
			return true;
		}
	}
}
