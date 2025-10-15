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
