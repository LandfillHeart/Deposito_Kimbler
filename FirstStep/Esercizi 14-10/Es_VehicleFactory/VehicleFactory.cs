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
		public string Type { get; }

		public void ShowType()
		{
			throw new NotImplementedException();
		}

		public void Start()
		{
			throw new NotImplementedException();
		}
	}

	public class Car : IVehicle
	{
		public string Type => "auto";

		public void Start()
		{
			Console.WriteLine("La macchina si avvia...");
		}

		public void ShowType()
		{
			Console.WriteLine($"Tipo del veicolo: {Type}");
		}

	}

	public class Bike : IVehicle
	{
		public string Type => "moto";
		public void Start() 
		{
			Console.WriteLine("La moto si avvia...");
		}

		public void ShowType()
		{
			Console.WriteLine($"Tipo del veicolo: {Type}");
		}
	}

	public class Truck : IVehicle
	{
		public string Type => "camion";

		public void Start()
		{
			Console.WriteLine("Il camion si avvia... piano piano...");
		}

		public void ShowType()
		{
			Console.WriteLine($"Tipo del veicolo: {Type}");
		}
	}

	public class VehicleFactory
	{
		public IVehicle CreateVehicle(string type)
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

		public bool TypeValid(string type)
		{
			return ("auto".Contains(type) || "moto".Contains(type) || "camion".Contains(type));
		}
	}
}
