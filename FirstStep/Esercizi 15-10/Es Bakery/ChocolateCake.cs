using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bakery
{
	public class ChocolateCake : ICake
	{
		public CakeType Type => CakeType.Chocolate;

		public string Description()
		{
			return "Torta al cioccolato\n";
		}
	}
}
