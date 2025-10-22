using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Entities;
using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application
{
	internal class ApplicationService
	{
		#region Singleton
		private static ApplicationService instance;
		public static ApplicationService Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new ApplicationService();
				}
				return instance;
			}
		}
		private ApplicationService() 
		{ 
			privilegesInitialized = false;
			AllowedActions = Actions.None;
		}
		#endregion

		#region APPLICATION ACCESS AND PRIVILEGES
		private bool privilegesInitialized;

		public Actions AllowedActions { get; private set; }
		public AccessLevel AccessLevel { get; private set; }

		#region ACCESS SERVICES
		private CreateProduct createProductService;
		private ReadProduct readProductService;
		private UpdateProduct updateProductService;
		#endregion

		public void InitializePriviliges(AccessLevel level)
		{
			AccessLevel = level;
			switch (level)
			{
				case AccessLevel.Default:
					// the default user is our customer, so they have to be able to see all the products in the store, and create/cancel orders
					// at the same time, they can NOT interact with the DB to add new products, or to change the status of an order directly (only allowed to cancel the order)
					AllowedActions = Actions.ReadProduct |
						Actions.CreateOrder | Actions.ReadOrder | Actions.DeleteOrder;
					break;
				case AccessLevel.Admin:
					// admin isn't logged-in to go shopping - they're trying to do executive functions
					// therefore we prevent risks by not giving them permissions to create orders, because that's not the use of the app on the admin's side
					// if they want to test functionalities, they should do so from a mock-up default user
					AllowedActions = Actions.ReadProduct | Actions.CreateProduct | Actions.UpdateProduct | Actions.DeleteProduct |
						Actions.ReadOrder | Actions.DeleteOrder;
					break;
				default:
					// if we can't recognize the access of the user, then don't let them do NOTHING!
					AllowedActions = Actions.None;
					break;
			}
			InitializeServices();
		}

		private void InitializeServices()
		{
			// PRODUCT
			// IRepository has to be a param and not hard coded
			// here, like in consoleUI, we could use a factory/strategy to create these services based on an interface
			// this way, we can have them change depending on context like more specific user actions, or by passing in test objects
			if((AllowedActions & Actions.CreateProduct) == Actions.CreateProduct)
			{
				createProductService = new CreateProduct(Database.Instance);
			}

			if((AllowedActions & Actions.ReadProduct) == Actions.ReadProduct)
			{
				readProductService = new ReadProduct(Database.Instance);
			}

			if((AllowedActions & Actions.UpdateProduct) == Actions.UpdateProduct) 
			{
				updateProductService = new UpdateProduct(Database.Instance);
			}
		}
		#endregion

		#region Domain Interface - Product
		public bool CreateProduct(string name, float price, out string message)
		{
			if((AllowedActions & Actions.CreateProduct) != Actions.CreateProduct)
			{
				message = "ERROR: No permissions for creation of products";
				return false;
			}

			if(createProductService == null)
			{
				message = "ERROR: CreateProduct service not initialized. Re-attempt verification or contact your provider";
				return false;
			}

			return createProductService.CreateNewProduct(name, price, out message);
		}

		public bool CreateProduct(string name, string price, out string message)
		{
			if (!float.TryParse(price, out float sanitizedFloat))
			{
				message = "ERROR: price is in invalid format";
				return false;
			}

			return CreateProduct(name, sanitizedFloat, out message);
		}

		public bool ReadProduct(string id, out Product product, out string message)
		{
			if((AllowedActions & Actions.ReadProduct) != Actions.ReadProduct)
			{
				message = "ERROR: No permissions to view products";
				product = null;
				return false;
			}

			if(readProductService == null)
			{
				message = "ERROR: service not initialized";
				product = null;
				return false;
			}

			return readProductService.GetProduct(id, out product, out message);
		}

		public List<Product> ReadAllProducts()
		{
			List<Product> toReturn = new();
			foreach(string id in Database.Instance.ProductIDs)
			{
				toReturn.Add(Database.Instance.ReadProduct(id));
			}
			return toReturn;
		}

		public bool UpdateProduct(string productId, string newName, float newPrice, out string message) 
		{
			if((AllowedActions & Actions.UpdateProduct) != Actions.UpdateProduct)
			{
				message = "ERROR: no permission to update. DB will not be updated";
				return false;
			}

			if(updateProductService == null)
			{
				message = "ERROR: service not initialized";
				return false;
			}

			return updateProductService.Update(productId, newName, newPrice, out message);
		}

		public bool UpdateProduct(string productId, string newName, string newPrice, out string message)
		{
			if (!float.TryParse(newPrice, out float sanitizedFloat))
			{
				message = "ERROR: price is in invalid format";
				return false;
			}

			return UpdateProduct(productId, newName, sanitizedFloat, out message);
		}

		#endregion
	}
}
