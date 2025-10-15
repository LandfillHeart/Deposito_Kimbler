using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_User_Manager
{
	public interface IUserCreationNotifier
	{
		public void AddSubscriber(IUserCreationObserver observer);
		public void RemoveSubscriber(IUserCreationObserver observer);
		public void Notify(User newUser);
	}
}
