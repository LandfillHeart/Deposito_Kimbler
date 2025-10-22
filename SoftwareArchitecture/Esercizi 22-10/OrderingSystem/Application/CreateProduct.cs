using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Interfaces;
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

		public void CreateNewProduct(string productName, float productPrice)
		{

		}
	}
}
