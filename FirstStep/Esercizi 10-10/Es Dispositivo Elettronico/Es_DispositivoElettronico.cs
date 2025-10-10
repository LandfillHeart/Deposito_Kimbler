using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Dispositivo_Elettronico
{
	internal class Es_DispositivoElettronico : IGenericExercise
	{
		public string Name => "Esercizio Dispositivo Elettronico";
		private ChoiceMenu choiceMenu;

		private List<ElectricalDevice> devices = new();
		public ReadOnlyCollection<ElectricalDevice> Devices => devices.AsReadOnly();

		public Es_DispositivoElettronico()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[]{
				new AddDevice(DeviceType.Computer, this),
				new AddDevice(DeviceType.Printer, this),
			});
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}

		public void AddDevice(ElectricalDevice device)
		{
			devices.Add(device);
		}

		public void Interact(ElectricalDevice device) 
		{ 
			
		}
	}
}
