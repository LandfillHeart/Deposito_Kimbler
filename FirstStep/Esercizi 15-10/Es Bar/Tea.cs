using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bar
{
	public class Tea : IBeverage
	{
		private float cost => 2.5f;
		public string Description()
		{
			return $"Questo è un té: {cost}\n";
		}

		public float GetCost()
		{
			return cost;
		}
	}
}
