using SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10.OrderingSystem.Infrastructure
{
	/// <summary>
	/// Creates a new ID on-demand based on the category and a static incremental ID
	/// </summary>
	internal static class ID_Helper
	{
		private static Dictionary<CategoryID, int> NextID = new Dictionary<CategoryID, int>() {
			{CategoryID.Product, 1},
			{CategoryID.Order, 1},
			{CategoryID.Customer, 1},
		};

		public static string CreateID(CategoryID category)
		{
			return $"{CategoryToTag(category)}_{category + NextID[category]}";
		}

		private static string CategoryToTag(CategoryID category)
		{
			return category switch
			{
				CategoryID.Product => "PRO",
				CategoryID.Order => "ORD",
				CategoryID.Customer => "CUS",
			};
		}
	}
}
