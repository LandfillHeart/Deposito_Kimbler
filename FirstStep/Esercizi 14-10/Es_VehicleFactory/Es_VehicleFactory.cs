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

			Console.WriteLine("Che veicolo vuoi creare? auto/moto/camion");
			Program.SanitizeInput(out string sanitizedString);
			if(!factory.TypeValid(sanitizedString))
			{
				Console.WriteLine("Tipo di veicolo non riconosciuto");
				return;
			}
			IVehicle newVehicle = factory.CreateVehicle(sanitizedString.Trim());
			newVehicle.Start();
			newVehicle.ShowType();
		}
	}
}
