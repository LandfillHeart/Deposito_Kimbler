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
