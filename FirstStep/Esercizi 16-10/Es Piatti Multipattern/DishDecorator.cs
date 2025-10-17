using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_16_10.Es_Piatti_Multipattern
{
	public enum DecoratorTypes
	{
		None = 0,
		WithCheese = 1 >> 0,
		WithBacon = 1 >> 1,
		WithSauce = 1 >> 2,
	}

	public abstract class DishDecorator : Dish
	{
		protected IDish dishComponent;
		public DecoratorTypes AppliedDecorators = DecoratorTypes.None;

		public DishDecorator(IDish dishComponent)
		{
			this.dishComponent = dishComponent;
			if(dishComponent is DishDecorator)
			{
				// if we just received a decorator as a component, we keep track of all decorators used
				AppliedDecorators |= (dishComponent as DishDecorator).AppliedDecorators;
			}
		}
	}

	public class WithBacon : DishDecorator
	{
		public new DecoratorTypes AppliedDecorators = DecoratorTypes.WithBacon;
		public WithBacon(IDish dishComponent) : base(dishComponent)
		{
		}

		public override string Prepare(CookMethods appliedCookMethod)
		{
			return base.Prepare(appliedCookMethod) + "\ncon Bacon";
		}
	}
}
