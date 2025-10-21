using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.BookHub
{
	public class StoreManager
	{
		#region Singleton
		private static StoreManager instance;
		public static StoreManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new StoreManager();
				}
				return instance;
			}
		}
		private StoreManager() { }
		#endregion


		// List of StockedBooks
		// List of digital books licensed
	}

	public class StockedBook
	{
		private int availableStock;
		public PhysicalBook Book { get; private set; }
		public int AvailableStock
		{
			get => availableStock;
			set => availableStock = Math.Max(0, value);
		}
	}
}
