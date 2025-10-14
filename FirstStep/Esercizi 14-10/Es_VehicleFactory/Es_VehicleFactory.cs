using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_14_10.Es_VehicleFactory
{
	public class Es_VehicleFactory : IGenericExercise
	{
		string IGenericExercise.Name => "Factory Method - Veicoli";

		public void Execute()
		{
			VehicleFactory factory = new VehicleFactory();
			IVehicle newVehicle = factory.CreateVehicle("auto");
			newVehicle.Start();
			newVehicle.ShowType();
		}
	}
}
