using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		#endregion

		public void StartSession()
		{
			Console.WriteLine("Hello. Are you a user or admin? user/admin");
			string choice = Console.ReadLine();
			if ("admin".Contains(choice))
			{
				ApplicationService.Instance.InitializePriviliges(AccessLevel.Admin);
				return;
			}

			if ("user".Contains(choice))
			{
				ApplicationService.Instance.InitializePriviliges(AccessLevel.Default);
				return;
			}

			ApplicationService.Instance.InitializePriviliges(AccessLevel.None);

		}

		// once we have developed a service distribution system, then we don't need 2 different menu classes
		// we only provide services to the ui, which will then display them
		// in this way, we can add/remove services for different users IN THE BACK-END without needing to update the client application
		
		public void AdminMenu()
		{
			Console.WriteLine("Pick an option: \n" +
				"0 - Close Program \n" +
				"1 - Create Product \n" +
				"2 - View Product \n" +
				"3 - Update Product \n" +
				"4 - Delete Product \n"); 
		}

		public void UserMenu()
		{
			Console.WriteLine("Pick an option: \n" +
				"0 - Close Program \n" +
				"1 - Add item to order \n" +
				"2 - Remove item from order \n" +
				"3 - Complete Order \n" +
				"4 - Delete Order \n");
		}
		
	}
}
