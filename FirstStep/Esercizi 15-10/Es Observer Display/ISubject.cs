using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Observer_Display
{
	public interface ISubject
	{
		public void Subscribe(IObserver observer);
		public void Unsubscribe(IObserver observer);
		public void Notify(string msg);
	}
}
