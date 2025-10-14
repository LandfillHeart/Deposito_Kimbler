using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_14_10.Es_VehicleFactory
{
	public interface IVehicle
	{
		public string Type { get; }
		public void Start();
		public void ShowType();
	}

	public abstract class Vehicle : IVehicle
	{
		public abstract string Type { get; }

		public void ShowType()
		{
			Console.WriteLine($"Tipo del veicolo: {Type}");
		}

		public abstract void Start();
	}

	public class Car : Vehicle
	{
		public override string Type => "auto";

		public override void Start()
		{
			Console.WriteLine("La macchina si avvia...");
		}
	}

	public class Bike : Vehicle
	{
		public override string Type => "moto";
		public override void Start() 
		{
			Console.WriteLine("La moto si avvia...");
		}
	}

	public class Truck : Vehicle
	{ 
		public override string Type => "camion";

		public override void Start()
		{
			Console.WriteLine("Il camion si avvia... piano piano...");
		}
	}

	public class Boat : Vehicle
	{
		public override string Type => "barca";

		public override void Start()
		{
			Console.WriteLine("Inizia a pagaiare...");
		}
	}

	public class Ship : Vehicle
	{
		public override string Type => "nave";

		public override void Start()
		{
			Console.WriteLine("La nave si avvia...");
		}
	}

	public interface IVehicleFactory
	{
		public IVehicle CreateVehicle(string type);
		public bool TypeValid(string type);
		public void ShowOptions();
	}

	public abstract class VehicleFactory : IVehicleFactory
	{
		public abstract IVehicle CreateVehicle(string type);
		public abstract bool TypeValid(string type);
		public abstract void ShowOptions();
		public static VehicleFactory NewFactory(string category)
		{
			return category switch
			{
				"terra" => new LandVehicleFactory(),
				"mare" => new WaterVehicleFactory(),
				_ => new LandVehicleFactory()
			};
		}

	}

	public class LandVehicleFactory : VehicleFactory
	{
		public override IVehicle CreateVehicle(string type)
		{
			IVehicle toReturn = null;
			switch (type)
			{
				case "auto":
					toReturn = new Car();
					break;
				case "moto":
					toReturn = new Bike();
					break;
				case "camion":
					toReturn = new Truck();
					break;
				default:
					Console.Error.WriteLine("Tipo di veicolo non riconosciuto");
					break;
			}

			return toReturn;
		}

		public override bool TypeValid(string type)
		{
			return ("auto".Contains(type) || "moto".Contains(type) || "camion".Contains(type));
		}

		public override void ShowOptions()
		{
			Console.WriteLine("Veicoli di terra: auto/moto/camion");
		}
	}

	public class WaterVehicleFactory : VehicleFactory
	{
		public override IVehicle CreateVehicle(string type)
		{
			IVehicle toReturn = null;
			switch (type)
			{
				case "nave":
					toReturn = new Ship();
					break;
				case "barca":
					toReturn = new Boat();
					break;
				default:
					Console.Error.WriteLine("Tipo di veicolo non riconosciuto");
					break;
			}

			return toReturn;
		}

		public override bool TypeValid(string type)
		{
			return ("auto".Contains(type) || "moto".Contains(type) || "camion".Contains(type));
		}
		public override void ShowOptions()
		{
			Console.WriteLine("Veicoli di mare: barca/nave");
		}
	}
}
