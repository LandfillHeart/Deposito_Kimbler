using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._08_10.Esercizio_Soldato
{
	// in questo caso possiamo tenere soldato non astratto, visto che potremmo volere un istanza più generica 
	internal class Soldier
	{
		// VARS
		private string name;
		private string rank;
		private int yearsOfService;

		// PROPERTIES
		public string Name
		{
			get => name;
			set => name = value;
		}

		public string Rank
		{
			get => rank;
			set => rank = value;
		}

		public int YearsOfService
		{
			get => yearsOfService;
			set
			{
				if(value >= 0)
				{
					yearsOfService = value;
				}
			}
		}

		public virtual SoldierType Type => SoldierType.None;

		public Soldier(string name, string rank, int yearsOfService)
		{
			this.name = name;
			this.rank = rank;
			this.yearsOfService = yearsOfService;
		}

		public virtual void Description()
		{
			// grazie ad override, viene chiamato il ToString delle classe figlie se applicabile
			Console.WriteLine(ToString());
		}

		public override string ToString()
		{
			return $"Nome: {Name} - Grado: {Rank} - Anni di Servizio: {YearsOfService}";
		}

	}

	internal class Infantryman : Soldier
	{
		private string weapon;

		public string Weapon
		{
			get => weapon;
			set => weapon = value;
		}

		public override SoldierType Type => SoldierType.Infantryman;

		public Infantryman(string name, string rank, int yearsOfService, string weapon) : base(name, rank, yearsOfService)
		{
			this.weapon = weapon;
		}

		public override string ToString()
		{
			return $"{base.ToString()} - Arma: {Weapon}";
		}
	}

	internal class Gunner : Soldier
	{
		private int caliber;

		public int Caliber
		{
			get => caliber;
			set
			{
				if (value >= 0)
				{
					caliber = value;
				}
			}
		}

		public override SoldierType Type => SoldierType.Gunner;

		public Gunner(string name, string rank, int yearsOfService, int caliber) : base(name, rank, yearsOfService)
		{
			this.caliber = caliber;
		}

		public override string ToString()
		{
			return $"{base.ToString()} - Calibro: {Caliber}";
		}
	}

	internal enum SoldierType
	{
		None = 0,
		Infantryman = 1,
		Gunner = 2
	}

}
