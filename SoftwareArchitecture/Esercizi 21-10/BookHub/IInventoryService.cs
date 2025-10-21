using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.BookHub
{
	public interface IInventoryService
	{
		public bool HasStock(out string stockDetails);
	}

	public class StoreInventory : IInventoryService
	{
		public bool HasStock(out string stockDetails)
		{
			// if the physical store has a physical copy of the book, then the book is available

			stockDetails = string.Empty;
			return true;
		}
	}

	public class DigitalInventory : IInventoryService
	{
		public bool HasStock(out string stockDetails)
		{
			// if the digital store has the license to sell the book, then the book is available

			stockDetails = string.Empty;
			return true;
		}
	}

	public class DropshipInventory : IInventoryService
	{
		public bool HasStock(out string stockDetails)
		{
			// the store can buy a physical or digital copy from another vendor for you, but you'll have to pay a surprice 

			stockDetails = string.Empty;
			return true;
		}
	}
}
