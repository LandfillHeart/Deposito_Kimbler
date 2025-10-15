using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bakery
{
	public class FruitCake : ICake
	{
		public CakeType Type => CakeType.Fruit;

		public string Description()
		{
			return "Torta di frutta\n";
		}
	}
}
