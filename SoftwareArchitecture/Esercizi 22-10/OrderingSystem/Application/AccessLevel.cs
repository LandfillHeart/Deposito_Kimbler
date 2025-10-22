using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Application
{
	// don't focus too hard on semantics, the associated value is just for visualization purposes
	// it's just so if we do:
	// Default = 100,
	// Premium,
	// Admin = 200
	// then we know that premium is an addendum/variety of default, but doesn't compare to admin
	// it adds a teeny tiny bit of readability
	internal enum AccessLevel
	{
		None = 0,
		Default = 100,
		Admin = 200,
	}
}
