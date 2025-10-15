using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bar
{
	public class Coffee : IBeverage
	{
		private float cost => 2.5f;

		#region IBeverage
		public string Description()
		{
			return $"Questo è un caffè: €{cost}\n";
		}

		public float GetCost()
		{
			return cost;
		}
		#endregion
	}
}
