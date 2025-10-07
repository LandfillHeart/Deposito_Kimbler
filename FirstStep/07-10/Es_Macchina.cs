using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._07_10
{
	internal class Es_Macchina : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Macchina";
		private ChoiceMenu choiceMenu;

		public User user;
		public Car car;
		public Car[] cars = new Car[] { new Car(Car.CarType.Default), new Car(Car.CarType.Truck), new Car(Car.CarType.RaceCar)};

		private string? sanitizedString;
		private int sanitizedInt;

		public Es_Macchina()
		{
			user = new User();
			car = cars[0];
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new UpgradeSpeed(this), new ChangeEngine(this), new UpgradeSuspension(this), new DisplayCarInfo(this)}, header: "Scegli un opzione");
		}

		public void Execute()
		{
			if (!user.IsInitizialized())
			{
				Console.WriteLine("Benvenuto! Inserisci il tuo nome");
				Program.SanitizeInput(out sanitizedString);

				Console.WriteLine("Inserisci il tuo credito");
				Program.SanitizeInput(out sanitizedInt);

				user.Name = sanitizedString;
				user.Credits = sanitizedInt;

				Console.WriteLine("Scegli una macchina di base");
				for (int i = 0; i < cars.Length; i++)
				{
					Console.WriteLine($"{i} - {cars[i].Name}");
				}
				Program.SanitizeInput(out sanitizedInt, mustBePositive: true);

				while (sanitizedInt >= cars.Length)
				{
					Console.WriteLine("Macchina non esistente, riprovare");
					Program.SanitizeInput(out sanitizedInt);
				}

				car = cars[sanitizedInt];
				Console.Clear();
			}

			choiceMenu.DisplayMenu();
		}

	}

	internal class Car
	{
		public string Name;

		public int Speed;
		public string Engine;
		public int Suspensions;

		public Car()
		{
			Name = "Fiat Panda";
			Speed = 5;
			Engine = "Default";
			Suspensions = 1;
		}

		public Car(CarType type)
		{
			Name = "Fiat Panda"; 
			Speed = 5;
			Engine = "Default";
			Suspensions = 1;
			switch (type)
			{
				case CarType.RaceCar:
					Name = "Ferrari";
					Speed = 30; 
					Engine = "Speed Demon";
					break;
				case CarType.Truck:
					Name = "MonsterTruck";
					Suspensions = 5;
					Engine = "MAN TGX 18.640";
					break;
			}
		}

		internal enum CarType
		{
			Default = 0,
			RaceCar = 1,
			Truck = 2
		}

	}

	internal class User
	{
		private int credits;
		public string Name { get; set; }
		public int Credits
		{
			get => credits;
			set
			{
				credits = Math.Max(value, 0);
			}
		}

		public bool IsInitizialized()
		{
			return Name != null;
		}
	}

	internal class UpgradeSpeed : IGenericExercise
	{
		string IGenericExercise.Name => "Aumenta velocità di 10";
		private Es_Macchina owner;

		public UpgradeSpeed(Es_Macchina owner)
		{
			this.owner = owner;
		}

		public void Execute() 
		{
			if (owner.user.Credits == 0) 
			{
				Console.WriteLine("Non hai i crediti necessari!!");
				return;
			}
			owner.user.Credits--;
			owner.car.Speed += 10;
			Console.WriteLine("Upgrade Completato");
		}
	}

	internal class ChangeEngine : IGenericExercise
	{
		string IGenericExercise.Name => "Cambia Motore";

		private Es_Macchina owner;
		private string? sanitizedInput;

		public ChangeEngine(Es_Macchina owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			if (owner.user.Credits == 0)
			{
				Console.WriteLine("Non hai i crediti necessari!!");
				return;
			}

			Console.WriteLine("Inserisci il nuovo motore");
			Program.SanitizeInput(out sanitizedInput);

			owner.user.Credits--;
			owner.car.Engine = sanitizedInput;
			Console.WriteLine("Upgrade Completato");
		}

	}

	internal class UpgradeSuspension : IGenericExercise
	{
		string IGenericExercise.Name => "Aumenta Sospensioni";
		private Es_Macchina owner;

		public UpgradeSuspension(Es_Macchina owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			if (owner.user.Credits == 0)
			{
				Console.WriteLine("Non hai i crediti necessari!!");
				return;
			}

			owner.user.Credits--;
			owner.car.Suspensions++;
			Console.WriteLine("Upgrade Completato");
		}

	}

	internal class DisplayCarInfo : IGenericExercise
	{
		string IGenericExercise.Name => "Vedi Info Macchina e Utente";
		private Es_Macchina owner;

		public DisplayCarInfo(Es_Macchina owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			Console.WriteLine($"Utente: {owner.user.Name} - Crediti: {owner.user.Credits}");
			Console.WriteLine($"Macchina: {owner.car.Name}");
			Console.WriteLine($"Motore: {owner.car.Engine}");
			Console.WriteLine($"Velocità: {owner.car.Speed}");
			Console.WriteLine($"Sospensioni: {owner.car.Suspensions}");
		}
	}

}
