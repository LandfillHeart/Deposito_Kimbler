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
			allowedActions = Actions.None;
		}
		#endregion

		#region APPLICATION ACCESS AND PRIVILEGES
		private bool privilegesInitialized;

		private Actions allowedActions;

		#region ACCESS SERVICES
		private CreateProduct createProductService;
		private ReadProduct readProductService;
		#endregion

		public void InitializePriviliges(AccessLevel level)
		{
			switch (level)
			{
				case AccessLevel.Default:
					// the default user is our customer, so they have to be able to see all the products in the store, and create/cancel orders
					// at the same time, they can NOT interact with the DB to add new products, or to change the status of an order directly (only allowed to cancel the order)
					allowedActions = Actions.ReadProduct |
						Actions.CreateOrder | Actions.ReadOrder | Actions.DeleteOrder;
					break;
				case AccessLevel.Admin:
					// admin isn't logged-in to go shopping - they're trying to do executive functions
					// therefore we prevent risks by not giving them permissions to create orders, because that's not the use of the app on the admin's side
					// if they want to test functionalities, they should do so from a mock-up default user
					allowedActions = Actions.ReadProduct | Actions.CreateProduct | Actions.DeleteProduct |
						Actions.ReadOrder | Actions.DeleteOrder;
					break;
				default:
					// if we can't recognize the access of the user, then don't let them do NOTHING!
					allowedActions = Actions.None;
					break;
			}
		}

		private void InitializeServices()
		{
			// PRODUCT
			// IRepository has to be a param and not hard coded
			if((allowedActions & Actions.CreateProduct) == Actions.CreateProduct)
			{
				createProductService = new CreateProduct(Database.Instance);
			}

			if((allowedActions & Actions.ReadProduct) == Actions.ReadProduct)
			{
				readProductService = new ReadProduct(Database.Instance);
			}
		}
		#endregion
	}
}
