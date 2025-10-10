using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Dispositivo_Elettronico
{
	internal class AddDevice : IGenericExercise
	{
		private string name;
		string IGenericExercise.Name => name;
		private Es_DispositivoElettronico owner;

		private DeviceType deviceType;

		public AddDevice(DeviceType type, Es_DispositivoElettronico owner)
		{ 
			this.owner = owner;
			this.deviceType = type;
			name = type switch
			{
				DeviceType.Computer => "Aggiungi Computer",
				DeviceType.Printer => "Aggiungi Stampante",
				_ => "Aggiungi Dispositivo"
			};
		}

		public void Execute()
		{
			Console.WriteLine("Inserisci il modello del tuo dispositivo");
			Program.SanitizeInput(out string model);
			owner.AddDevice(deviceType switch
			{
				DeviceType.Computer => new Computer(model),
				DeviceType.Printer => new Printer(model),
			});
			Console.WriteLine("Operazione completata");
		}
	}

	internal class InteractAllDevices : IGenericExercise
	{
		string IGenericExercise.Name => "Interagisci con tutti i dispositivi";

		private Es_DispositivoElettronico owner;

		public InteractAllDevices(Es_DispositivoElettronico owner)
		{
			this.owner = owner;	
		}

		public void Execute()
		{
			foreach (var device in owner.Devices)
			{
				owner.Interact(device);
			}
		}
	}

}
