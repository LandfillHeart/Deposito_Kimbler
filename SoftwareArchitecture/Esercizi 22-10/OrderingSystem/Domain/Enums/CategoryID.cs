using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Enums
{
	// when we create a new item of any category, we add the CategoryID and ID Prefix to the ID to help differentiate them
	internal enum CategoryID
	{
		None = 0,
		Product = 10_000,
		Order = 20_000,
		Customer = 30_000
	}
}
