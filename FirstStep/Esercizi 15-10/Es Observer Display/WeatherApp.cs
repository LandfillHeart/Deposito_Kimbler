using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public class WeatherApp : ISubject
	{
		private readonly HashSet<IObserver> observers = new HashSet<IObserver>();

		private string weatherState;
		public string WeatherState
		{
			get => weatherState;
			set
			{
				weatherState = value;
				Notify(weatherState);
			}
		}

		public void Notify(string msg)
		{
			foreach(IObserver observer in observers)
			{
				observer.Update(msg);
			}
		}

		public void Subscribe(IObserver observer)
		{
			observers.Add(observer);
		}

		public void Unsubscribe(IObserver observer)
		{
			observers.Add(observer);
		}
	}
}
