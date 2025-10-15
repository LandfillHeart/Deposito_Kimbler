using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstStep.Esercizi_15_10.Es_Bakery.Decorators;

namespace FirstStep.Esercizi_15_10.Es_Bakery
{
	public static class CakeFactory
	{
		public static ICake CreateCake(CakeType type)
		{
			return type switch
			{
				CakeType.Chocolate => new ChocolateCake()
			};
		}

		public static ICake DecorateCake(ICake toDecorate, DecoratorType decoratorType)
		{
			// se abbiamo già applicato questo decorator specifico, ritorniamo indietro l'oggetto
			if(toDecorate is CakeDecorator)
			{
				if((toDecorate as CakeDecorator).DecoratorsApplied.Contains(decoratorType))
				{
					return toDecorate;
				} 
			}

			return decoratorType switch
			{
				DecoratorType.WithStrawberries => new WithStrawberries(toDecorate)
			};
		}
	}
}
