using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Dispositivo_Elettronico
{
	public enum DeviceType
	{
		Computer,
		Printer
	}

	internal abstract class ElectricalDevice
	{
		private string model;
		public string Model
		{
			get => model;
			set => model = value;
		}

		public abstract void TurnOn();
		public abstract void TurnOff();

		public virtual void ShowInfo()
		{
			Console.WriteLine($"Modello: {model}");
		}

		public ElectricalDevice(string model)
		{
			this.model = model;
		}
	
	}

	internal class Computer : ElectricalDevice
	{
		public override void TurnOn() => Console.WriteLine("Il computer si accende...");

		public override void TurnOff() => Console.WriteLine("Il computer si spegne.");

		public Computer(string model) : base(model) { }	
	}

	internal class Printer : ElectricalDevice
	{
		public override void TurnOn() => Console.WriteLine("La stampante si accende.");

		public override void TurnOff() => Console.WriteLine("La stampante va in standby.");

		public Printer(string model) : base(model) { }
	}
}
