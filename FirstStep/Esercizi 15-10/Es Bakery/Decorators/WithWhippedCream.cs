using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bakery.Decorators
{
	public class WithWhippedCream : CakeDecorator
	{
		protected override DecoratorType DecoratorType => DecoratorType.WithWhippeCream;

		public WithWhippedCream(ICake cakeComponent) : base(cakeComponent)
		{
			DecoratorsApplied.Add(DecoratorType);
		}

		public override string Description()
		{
			return base.Description() + "con panna\n";
		}
	}
}
