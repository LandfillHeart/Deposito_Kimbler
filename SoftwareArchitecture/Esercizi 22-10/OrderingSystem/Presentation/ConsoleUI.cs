using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Presentation
{
	internal class ConsoleUI
	{
		#region Singleton
		private static ConsoleUI instance;
		public static ConsoleUI Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new ConsoleUI();
				}
				return instance;
			}
		}

		private ConsoleUI() { }
		#endregion

		#region Dependency Injection
		// TODO: Replace ApplicationService.Instance with a DI of a generic interface
		#endregion

		private List<Actions> actions = new();

		public void StartSession()
		{
			Console.WriteLine("Hello. Are you a user or admin? user/admin");
			string choice = Console.ReadLine();
			if ("admin".Contains(choice))
			{
				ApplicationService.Instance.InitializePriviliges(AccessLevel.Admin);
				goto LogSession;
				return;
			}

			if ("user".Contains(choice))
			{
				ApplicationService.Instance.InitializePriviliges(AccessLevel.Default);
				goto LogSession;
				return;
			}

			ApplicationService.Instance.InitializePriviliges(AccessLevel.None);

		LogSession:
			Console.WriteLine($"Session Start - Your access level: {ApplicationService.Instance.AccessLevel.ToString()}");
			
		}

		public void CreateProduct()
		{
			Console.WriteLine("New Product Name: ");
			string name = Console.ReadLine();

			Console.WriteLine("New Product Price: ");
			string price = Console.ReadLine();

			ApplicationService.Instance.CreateProduct(name, price, out string message);
			// TODO: Log message
			Console.WriteLine(message);
		}

		public void ReadProduct()
		{
			Console.WriteLine("Find product by ID: ");
			string ID = Console.ReadLine();

			if(ApplicationService.Instance.ReadProduct(ID, out Product product, out string message))
			{
				Console.WriteLine(product.Name);
			}
			Console.WriteLine(message);
		}
	}
}
