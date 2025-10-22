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

		private List<IPresentationAction> actions = new List<IPresentationAction>();

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
			InitializeActions();
		}

		// What I actually would like to do here:
		// 1 - Have a list of an interface which gives me a generic run menu or whatnot
		// 2 - Based on access level, populate the list
		// 3 - Iterate through the list, creating a menu
		// 4 - When an option is chosen, it runs a func inside the object similar to what we find below

		private void InitializeActions()
		{
			ApplicationService serviceCache = ApplicationService.Instance;
			// technically here the actions could be dictated by a factory/strategy method, depending on other factors
			// this could be if our app context is telling us to use test objects, or if we need different users to complete the same actions differently
			// everything can always be more granular, more complex, more detailed. it's all on a per-need basis
			if((serviceCache.AllowedActions & Actions.CreateProduct) == Actions.CreateProduct)
			{
				actions.Add(new CreateProduct(serviceCache));
			}

			if ((serviceCache.AllowedActions & Actions.ReadProduct) == Actions.ReadProduct)
			{
				actions.Add(new ReadProduct(serviceCache));
				actions.Add(new ReadAllProducts(serviceCache));
			}

			if ((serviceCache.AllowedActions & Actions.UpdateProduct) == Actions.UpdateProduct)
			{
				actions.Add(new UpdateProduct(serviceCache));
			}
		}

		public void InteractiveMenu()
		{
			while (true) 
			{
				Console.Clear();
				Console.WriteLine("Pick an option:");
				Console.WriteLine("ENTER - Close Program");
				for (int i = 0; i < actions.Count; i++)
				{
					Console.WriteLine($"{i} - {actions[i].MenuItemName}");
				}
				string? input = Console.ReadLine();
				if (string.IsNullOrEmpty(input))
				{
					Console.WriteLine("Thank you, goodbye!");
					Environment.Exit(0);
				}

				if (!int.TryParse(input, out int index))
				{
					Console.WriteLine("Invalid string, press any button to continue");
					Console.ReadKey(true);
					continue;
				}

				if (index >= actions.Count)
				{
					Console.WriteLine("Invalid choice, press any button to continue");
					Console.ReadKey(true);
					continue;
				}

				actions[index].Run();
				// action will exit with return on completion, so capture key to allow user time to read result
				Console.WriteLine("Press any key to continue");
				Console.ReadKey(true);
			}
		}
	}
}
