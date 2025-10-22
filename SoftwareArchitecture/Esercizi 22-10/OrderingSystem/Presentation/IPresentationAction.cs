using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Presentation
{
	internal interface IPresentationAction
	{
		public string MenuItemName { get; }
		public void Run();
	}

	internal class CreateProduct : IPresentationAction
	{
		public string MenuItemName => "Create a new product";

		private ApplicationService applicationService;

		// TODO: replace application service with an interface
		// even better yet if ApplicationService itself extends multiple interfaces, to apply Interface Segregation 
		public CreateProduct(ApplicationService applicationService)
		{
			this.applicationService = applicationService;
		}

		public void Run() 
		{
			Console.WriteLine("New Product Name: ");
			string name = Console.ReadLine();

			Console.WriteLine("New Product Price: ");
			string price = Console.ReadLine();

			applicationService.CreateProduct(name, price, out string message);
			// TODO: Log message
			Console.WriteLine(message);
		}
	}

	internal class ReadProduct : IPresentationAction
	{
		public string MenuItemName => "Find a product by ID";
		private ApplicationService applicationService;
		public ReadProduct(ApplicationService applicationService)
		{
			this.applicationService = applicationService;
		}

		public void Run()
		{
			Console.WriteLine("Find product by ID: ");
			string ID = Console.ReadLine();

			if (ApplicationService.Instance.ReadProduct(ID, out Product product, out string message))
			{
				Console.WriteLine(product.Name);
			}
			Console.WriteLine(message);
		}
	}

	internal class ReadAllProducts : IPresentationAction
	{
		public string MenuItemName => "See product catalogue";
		private ApplicationService applicationService;
		public ReadAllProducts(ApplicationService applicationService)
		{
			this.applicationService = applicationService;
		}

		public void Run()
		{
			List<Product> toDisplay = applicationService.ReadAllProducts();
			foreach (Product product in toDisplay)
			{
				Console.WriteLine($"{product.ID} - {product.Name}");
			}
		}
	}
}
