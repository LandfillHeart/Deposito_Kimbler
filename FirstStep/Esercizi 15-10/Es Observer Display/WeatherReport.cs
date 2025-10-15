using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public class WeatherReport : ISubject
	{
		private readonly HashSet<IObserver> observers = new HashSet<IObserver>();

		public string City { get; private set; }

		private string weatherState;
		public string WeatherState
		{
			get => weatherState;
			set
			{
				weatherState = value;
				Notify($"Oggi a {City} è {weatherState}");
			}
		}

		public WeatherReport(string city)
		{
			this.City = city;
			weatherState = "Soleggiato"; // default
		}

		public void Notify(string msg)
		{
			foreach(IObserver observer in observers)
			{
				observer.Update(msg);
			}
		}

		public void AddSubscriber(IObserver observer)
		{
			observers.Add(observer);
		}

		public void RemoveSubscriber(IObserver observer)
		{
			observers.Add(observer);
		}
	}
}
