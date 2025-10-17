using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_16_10.Es_Piatti_Multipattern
{
	public enum CookMethods
	{
		None = 0,
		Fried = 1 >> 0,
		Oven = 1 >> 1,
		Grilled = 1 >> 2,
	}

	public interface IDish
	{
		public CookMethods PossibleCookMethods { get; }
		public string Description { get; }
		public string Prepare(CookMethods appliedCookMethod);
	}

	public abstract class Dish : IDish
	{
		public virtual CookMethods PossibleCookMethods => CookMethods.None;

		public string Description => "Questo piatto non esiste";

		public virtual string Prepare(CookMethods appliedCookMethod)
		{
			return $" - Cottura: {CookMethodToString(appliedCookMethod)}";
		}

		public static string CookMethodToString(CookMethods method)
		{
			string msgMethod = "Nessuno";
			if((method & CookMethods.Fried) == CookMethods.Fried)
			{
				msgMethod = "Fritto";
				return msgMethod;
			}
			// TO-DO: aggiungi tutti gli enum
			return msgMethod;
		}
	}

	public class Pizza : Dish
	{
		public override CookMethods PossibleCookMethods => CookMethods.Oven | CookMethods.Fried;

		public new string Description => "Una pizza";

		public override string Prepare(CookMethods appliedCookMethod)
		{
			return "Cuciniamo una Pizza" + base.Prepare(appliedCookMethod);
		}
	}
}
