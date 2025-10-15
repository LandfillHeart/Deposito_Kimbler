using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public class Es_ObserverDisplay : IGenericExercise
	{
		string IGenericExercise.Name => "Observer Display";

		private ChoiceMenu choiceMenu;
		private User user;
		public readonly List<WeatherReport> ReportedCities = new List<WeatherReport>();

		public Es_ObserverDisplay()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[]
			{
				new AddWeatherReport(this),
				new ChangeWeather(this),
				new AddDisplay(this),
				new SubscribeToWeatherReport(this),
			});
		}

		public void Execute()
		{
			if (user == null)
			{
				Console.WriteLine("Registrati inserendo il tuo nome");
				Program.SanitizeInput(out string name);
				user = new User(name);
			}

			Console.WriteLine($"Benvenuto {user.Name}");

			choiceMenu.DisplayMenu();
		}

		public void AddWeatherReport(string city)
		{
			ReportedCities.Add(new WeatherReport(city));
		}

		public void SubscribeToWeatherReport(int index)
		{
			ReportedCities[index].AddSubscriber(user);
		}

		public void AddDevice(IObserver observer)
		{
			user.AddSubscriber(observer);
		}
	}
}
