using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bakery.Decorators
{
	public abstract class CakeDecorator : ICake
	{
		protected ICake cakeComponent { get; private set; }
		public CakeType Type => cakeComponent.Type;

		protected virtual DecoratorType DecoratorType => DecoratorType.None;
		public HashSet<DecoratorType> DecoratorsApplied = new();

		public CakeDecorator(ICake cakeComponent)
		{
			this.cakeComponent = cakeComponent;
			DecoratorsApplied.Add(DecoratorType);
			if (cakeComponent is CakeDecorator)
			{
				foreach (var decoratorApplied in (cakeComponent as CakeDecorator).DecoratorsApplied)
				{
					DecoratorsApplied.Add(decoratorApplied);
				}
			}
		}

		public virtual string Description()
		{
			return cakeComponent.Description();
		}
	}

	public enum DecoratorType
	{
		None,
		WithStrawberries,
		WithWhippeCream,
		WithIcing
	}
}
