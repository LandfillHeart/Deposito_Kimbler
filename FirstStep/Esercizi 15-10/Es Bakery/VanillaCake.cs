using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bakery
{
	public class VanillaCake : ICake
	{
		public CakeType Type => CakeType.Vanilla;

		public string Description()
		{
			return "Torta alla vaniglia\n";
		}
	}
}
