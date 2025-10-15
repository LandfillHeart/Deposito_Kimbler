using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public interface ISubject
	{
		public void AddSubscriber(IObserver observer);
		public void RemoveSubscriber(IObserver observer);
		public void Notify(string msg);
	}
}
