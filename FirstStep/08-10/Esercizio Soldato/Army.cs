using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._08_10.Esercizio_Soldato
{
	internal class Army
	{
		private List<Soldier> soldiers = new();

		public List<Soldier> GetAllSoldiers()
		{
			return soldiers;
		}

		public List<Soldier> GetSoldiersByType(SoldierType type)
		{
			List<Soldier> toReturn = new List<Soldier>();
			foreach(Soldier s in soldiers)
			{
				if(s.Type == type)
				{
					toReturn.Add(s);
				}
			}

			return toReturn;
		}

		public void AddSoldier(Soldier soldier)
		{
			soldiers.Add(soldier);
		}

	}
}
