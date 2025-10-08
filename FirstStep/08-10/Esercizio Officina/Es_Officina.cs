using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._08_10.Esercizio_Officina
{
	internal class Es_Officina : IGenericExercise
	{
		string IGenericExercise.Name => "Officina Meccanica";

		public void Execute()
		{
			List<Vehicle> vehicles = new List<Vehicle>() {
				new Car("AB123CD"),
				new Truck("FN499GG"),
				new Bike("RS654PO"),
			};

			foreach (Vehicle vehicle in vehicles) 
			{
				Console.WriteLine($"Targa: {vehicle.Plate}");
				vehicle.Repair();
			}
		
		}
	}
}
