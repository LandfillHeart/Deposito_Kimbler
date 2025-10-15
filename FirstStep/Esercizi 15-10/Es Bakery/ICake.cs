using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bakery
{
	public interface ICake
	{
		public CakeType Type { get; }
		public string Description();
	}

	public enum CakeType
	{
		Chocolate,
		Fruit,
		Vanilla
	}

}
