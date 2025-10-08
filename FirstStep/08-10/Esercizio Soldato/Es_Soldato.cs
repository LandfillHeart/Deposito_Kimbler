using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._08_10.Esercizio_Soldato
{
	internal class Es_Soldato : IGenericExercise
	{
		string IGenericExercise.Name => "Esempio Soldato";
		private ChoiceMenu choiceMenu;

		public Army myArmy = new Army();

		public Es_Soldato()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { 
				new AddSoldier(SoldierType.Infantryman, this),
				new AddSoldier(SoldierType.Gunner, this),
				new PrintAllSoldiers(this),
				new PrintSoldierType(SoldierType.Infantryman, this),
				new PrintSoldierType(SoldierType.Gunner, this)
			});
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}

	}

	internal class AddSoldier : IGenericExercise
	{
		private string name;
		string IGenericExercise.Name => name;
		private Es_Soldato owner;
		private SoldierType type;

		public AddSoldier(SoldierType type, Es_Soldato owner) 
		{ 
			this.owner = owner;
			this.type = type;
			switch(type)
			{
				case SoldierType.Infantryman:
					name = "Crea Fante";
					break;
				case SoldierType.Gunner:
					name = "Crea Artigliere";
					break;
				default:
					name = "Crea Soldato";
					break;
			}
		}

		// come al solito preferisco creare una singola funzione/classe e decidere come funziona in base ad altro (ie un enum)
		public void Execute() 
		{
			Console.WriteLine("Inserisci il nome del soldato");
			Program.SanitizeInput(out string name);

			Console.WriteLine("Inserisci il grado");
			Program.SanitizeInput(out string rank);

			Console.WriteLine("Inserisci gli anni di servizio");
			Program.SanitizeInput(out int yearsOfService, mustBePositive: true);

			switch(type)
			{
				case SoldierType.Infantryman:
					Console.WriteLine("Inserisci l'arma");
					Program.SanitizeInput(out string weapon);
					Infantryman infantryman = new Infantryman(name, rank, yearsOfService, weapon);
					owner.myArmy.AddSoldier(infantryman);
					break;
				case SoldierType.Gunner:
					Console.WriteLine("Inserisci il calibro");
					Program.SanitizeInput(out int caliber, mustBePositive: true);
					Gunner gunner = new Gunner(name, rank, yearsOfService, caliber);
					owner.myArmy.AddSoldier(gunner);
					break;
				default:
					Soldier soldier = new Soldier(name, rank, yearsOfService);
					owner.myArmy.AddSoldier(soldier);
					break;
			}

			Console.WriteLine("Operazione completata");

		}

	}

	internal class PrintAllSoldiers : IGenericExercise
	{
		string IGenericExercise.Name => "Visualizza tutti i soldati";
		private Es_Soldato owner;

		public PrintAllSoldiers(Es_Soldato owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			List<Soldier> toPrint = new();
			toPrint = owner.myArmy.GetAllSoldiers();
			if (toPrint.Count == 0)
			{
				Console.WriteLine("Non hai un esercito");
				return;
			}

			foreach(Soldier soldier in toPrint)
			{
				soldier.Description();
			}
		}
	}

	internal class PrintSoldierType : IGenericExercise
	{
		private string name;
		public string Name => name;
		private Es_Soldato owner;
		private SoldierType type;
		public PrintSoldierType(SoldierType type, Es_Soldato owner)
		{
			this.type = type;
			this.owner = owner;

			switch (type)
			{
				case SoldierType.Infantryman:
					name = "Visualizza tutti i fanti";
					break;
				case SoldierType.Gunner:
					name = "Visualizza tutti gli artiglieri";
					break;
				default:
					name = "Visualizza tutti i soldati non importanti";
					break;
			}

		}
		public void Execute()
		{
			List<Soldier> toPrint = new();
			toPrint = owner.myArmy.GetSoldiersByType(type);
			if (toPrint.Count == 0)
			{
				Console.WriteLine("Non hai un esercito");
				return;
			}

			foreach (Soldier soldier in toPrint)
			{
				soldier.Description();
			}
		}
	}

}
