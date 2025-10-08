using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._08_10.Esercizio_Officina
{
	internal abstract class Vehicle
	{
		public string Plate { get; set; }

		public Vehicle(string plate)
		{
			Plate = plate;
		}

		public virtual void Repair()
		{
			Console.WriteLine("Il veicolo viene controllato.");
		}
	}

	internal class Car : Vehicle
	{
		public Car(string plate) : base(plate) { }

		public override void Repair()
		{
			Console.WriteLine("Controllo catena, freni e motore dell'auto");
		}
	}

	internal class Bike : Vehicle
	{
		public Bike(string plate) : base(plate) { }
		public override void Repair()
		{
			Console.WriteLine("Contro catena, freni e gomme della moto");
		}
	}

	internal class Truck : Vehicle
	{
		public Truck(string plate) : base(plate) { }

		public override void Repair()
		{
			Console.WriteLine("Controllo sospensioni, freni rinforzati e carico del camion");
		}
	}
}
