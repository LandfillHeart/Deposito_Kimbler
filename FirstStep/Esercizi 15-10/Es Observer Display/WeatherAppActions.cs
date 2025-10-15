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
		private WeatherApp weatherApp;
		public ChangeWeather(WeatherApp weatherApp)
		{
			this.weatherApp = weatherApp;
		}

		public void Execute()
		{
			Console.WriteLine("Che tempo fa ora?");
			Program.SanitizeInput(out string sanitizedInput);
			weatherApp.WeatherState = sanitizedInput;
		}
	}
}
