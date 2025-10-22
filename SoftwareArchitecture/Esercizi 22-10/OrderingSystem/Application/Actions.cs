using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application
{
	[Flags]
	internal enum Actions
	{
		None = 0,
		
		// Products
		CreateProduct = 1,
		ReadProduct = 2,
		UpdateProduct = 4,
		DeleteProduct = 8,

		// Orders
		CreateOrder = 16,
		ReadOrder = 32,
		UpdateOrder = 64,
		DeleteOrder = 128,
	}
}
