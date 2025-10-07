using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._07_10.Es_Garage
{
	internal class Es_VehicleInheritance : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Veicolo Eriditarietà";
		private ChoiceMenu choiceMenu;

		public Garage garage = new();

		public Es_VehicleInheritance()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new AddVehicle(this), new PrintAllVehicles(this) });
		}
		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}
	}

	internal class PrintAllVehicles : IGenericExercise
	{
		string IGenericExercise.Name => "Visualizza Garage";
		private Es_VehicleInheritance owner;
		public PrintAllVehicles(Es_VehicleInheritance owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			foreach(Vehicle vehicle in owner.garage.Vehicles)
			{
				Console.WriteLine(vehicle.ToString());
			}
		}
	}

	internal class AddVehicle : IGenericExercise
	{
		string IGenericExercise.Name => "Aggiungi un veicolo";
		private Es_VehicleInheritance owner;

		private int sanitizedInt;
		private string sanitizedString;

		private Vehicle vehicle;

		public AddVehicle(Es_VehicleInheritance owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			while(true)
			{
				Console.WriteLine("Scegli un opzione");
				Console.WriteLine("0 - Torna al menu");
				Console.WriteLine("1 - Aggiungi una macchina");
				Console.WriteLine("2 - Aggiungi una moto");

				Program.SanitizeInput(out sanitizedInt);
				if(sanitizedInt > 2)
				{
					Console.WriteLine("Opzione non riconosciuta, riprova");
					continue;
				}

				if(sanitizedInt == 0)
				{
					Console.Clear();
					return;
				}

				if(sanitizedInt == 1)
				{
					Console.Clear();

					vehicle = new Car();
					SetVehicleData();
					SetCarData();
					owner.garage.Cars.Add(vehicle as Car);
					Console.WriteLine("Operazione Completata");
					return;
				}

				Console.Clear();

				vehicle = new Bike();
				SetVehicleData();
				SetBikeData();
				owner.garage.Bikes.Add(vehicle as Bike);
				Console.WriteLine("Operazione Completata");
				return;

			}
		}

		private void SetVehicleData()
		{
			Console.WriteLine("Inserisci la marca del veicolo");
			Program.SanitizeInput(out sanitizedString);
			vehicle.Brand = sanitizedString;
			Console.WriteLine("Inserisci il modello");
			Program.SanitizeInput(out sanitizedString);
			vehicle.Model = sanitizedString;
		}

		private void SetCarData()
		{
			Console.WriteLine("Inserisci il numero di porte");
			Program.SanitizeInput(out sanitizedInt);
			Car car = vehicle as Car;
			car.NumberOfDoors = sanitizedInt;
		}

		private void SetBikeData()
		{
			Console.WriteLine("Inserisci il tipo di manubrio");
			Program.SanitizeInput(out sanitizedString);
			Bike bike = vehicle as Bike;
			bike.HandlebarType = sanitizedString;
		}

	}

	internal class Garage
	{
		public List<Car> Cars = new();
		public List<Bike> Bikes = new();

		public List<Vehicle> Vehicles
		{
			get
			{
				List<Vehicle> all = new List<Vehicle>();
				all.AddRange(Cars);
				all.AddRange(Bikes);
				return all;
			}
		}
	}

	internal abstract class Vehicle
	{
		public string Brand;
		public string Model;

		public override string ToString()
		{
			return $"Marca: {Brand} - Modello: {Model}";
		}
	}

	internal class Car : Vehicle
	{
		public int NumberOfDoors;

		public override string ToString()
		{
			return $"{base.ToString()} - Numero Porte: {NumberOfDoors}";
		}
	}

	internal class Bike : Vehicle
	{
		public string HandlebarType;

		public override string ToString()
		{
			return $"{base.ToString()} - Tipo di Manubrio: {HandlebarType}";
		}
	}

}
