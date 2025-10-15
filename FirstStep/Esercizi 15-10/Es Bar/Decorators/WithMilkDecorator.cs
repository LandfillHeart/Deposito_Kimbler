using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bar.Decorators
{
	public class WithMilkDecorator : BeverageDecorator
	{
		private float cost => 0.5f;

		public WithMilkDecorator(IBeverage toDecorate) : base(toDecorate)
		{

		}

		public override float GetCost()
		{
			return base.GetCost() + cost;
		}

		public override string Description()
		{
			return base.Description() + $"con latte: +€{cost} \n";
		}

	}
}
