using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public class User : ISubject, IObserver
	{
		public string Name { get; private set; }

		public readonly HashSet<IObserver> connectedDevices = new HashSet<IObserver>();

		public User(string name)
		{
			Name = name;
		}

		public void Update(string msg)
		{
			Notify(msg);
		}

		public void AddSubscriber(IObserver observer)
		{
			connectedDevices.Add(observer);
		}

		public void RemoveSubscriber(IObserver observer)
		{
			connectedDevices.Remove(observer);
		}

		public void Notify(string msg)
		{
			foreach (var device in connectedDevices)
			{
				device.Update(msg);
			}
		}
	}
}
