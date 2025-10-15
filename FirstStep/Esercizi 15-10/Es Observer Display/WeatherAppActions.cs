using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public class ChangeWeather : IGenericExercise
	{
		string IGenericExercise.Name => "Cambia Meteo";
		private Es_ObserverDisplay owner;
		public ChangeWeather(Es_ObserverDisplay owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			if(owner.ReportedCities.Count == 0)
			{
				Console.WriteLine("Scusa, ma non ci sono città!");
				return;
			}

			for (int i = 0; i < owner.ReportedCities.Count; i++)
			{
				Console.WriteLine($"{i} - {owner.ReportedCities[i].City}");
			}

			Console.WriteLine("Scegli una città");
			Program.SanitizeInput(out int index, mustBePositive: true);

			if (index >= owner.ReportedCities.Count)
			{
				Console.WriteLine("Città non riconosciuta");
				return;
			}

			Console.WriteLine("Che tempo fa oggi?");
			Program.SanitizeInput(out string weather);
			owner.ReportedCities[index].WeatherState = weather;			
		}
	}

	public class AddDisplay : IGenericExercise
	{
		string IGenericExercise.Name => "Aggiungi un dispositivo";
		private Es_ObserverDisplay owner;

		public AddDisplay(Es_ObserverDisplay owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			Console.WriteLine("Che tipo di display vuoi aggiungere? console/mobile");
			Program.SanitizeInput(out string sanitizedString);
			switch(sanitizedString)
			{
				case "console":
					owner.AddDevice(new DisplayConsole());
					break;
				case "mobile":
					owner.AddDevice(new DisplayMobile());
					break;
				default:
					Console.WriteLine("Non supportiamo ancora quel tipo di display");
					break;
			}
		}
	}

	public class AddWeatherReport : IGenericExercise
	{
		string IGenericExercise.Name => "Aggiungi meteo per una città";
		private Es_ObserverDisplay owner;

		public AddWeatherReport(Es_ObserverDisplay owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			Console.WriteLine("Inserisci il nome della città");
			Program.SanitizeInput(out string city);
			owner.AddWeatherReport(city);
		}
	}

	public class SubscribeToWeatherReport : IGenericExercise
	{
		string IGenericExercise.Name => "Iscriviti al meteo";
		private Es_ObserverDisplay owner;
		public SubscribeToWeatherReport(Es_ObserverDisplay owner)
		{
			this.owner = owner;
		}
		public void Execute()
		{
			if (owner.ReportedCities.Count == 0)
			{
				Console.WriteLine("Scusa, ma non ci sono città!");
				return;
			}

			for (int i = 0; i < owner.ReportedCities.Count; i++)
			{
				Console.WriteLine($"{i} - {owner.ReportedCities[i].City}");
			}

			Console.WriteLine("Scegli una città");
			Program.SanitizeInput(out int index, mustBePositive: true);

			if(index >= owner.ReportedCities.Count)
			{
				Console.WriteLine("Città non riconosciuta");
				return;
			}

			owner.SubscribeToWeatherReport(index);
		}
	}
}
