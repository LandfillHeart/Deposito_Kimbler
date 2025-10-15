using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bar.Decorators
{
	public abstract class BeverageDecorator : IBeverage
	{
		protected IBeverage beverageComponent;

		public BeverageDecorator(IBeverage toDecorate)
		{
			this.beverageComponent = toDecorate;
		}

		public virtual float GetCost()
		{
			return beverageComponent.GetCost();
		}

		public virtual string Description()
		{
			return beverageComponent.Description();
		}
	}
}
