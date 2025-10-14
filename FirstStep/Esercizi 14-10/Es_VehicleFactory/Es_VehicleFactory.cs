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
			Console.WriteLine("Che tipo di factory vuoi creare? terra/mare");
			Program.SanitizeInput(out string sanitizedInput);

			VehicleFactory newFactory = VehicleFactory.NewFactory(sanitizedInput);

			Console.WriteLine("Quale veicolo vuoi creare?");
			newFactory.ShowOptions();

			Program.SanitizeInput(out sanitizedInput);
			IVehicle newVehicle = newFactory.CreateVehicle(sanitizedInput);

			newVehicle.Start();
			newVehicle.ShowType();
		}
	}
}
