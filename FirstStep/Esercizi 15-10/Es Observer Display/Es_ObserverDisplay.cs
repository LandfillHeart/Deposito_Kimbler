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
		WeatherApp weatherApp = new WeatherApp();

		public Es_ObserverDisplay()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[]
			{
				new ChangeWeather(weatherApp)
			});
		}

		public void Execute()
		{
			DisplayConsole displayConsole = new DisplayConsole();
			DisplayMobile displayMobile = new DisplayMobile();

			weatherApp.Subscribe(displayConsole);
			weatherApp.Subscribe(displayMobile);

			choiceMenu.DisplayMenu();
		}
	}
}
