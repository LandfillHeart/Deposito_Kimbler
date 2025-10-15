using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_User_Manager
{
	// LogManager è un singleton essendo che nel contesto dell'app serve agli admin di ricevere messaggi
	public class LogManager : IUserCreationObserver
	{
		#region Singleton
		private static LogManager instance;
		public static LogManager Instance
		{
			get 
			{
				if(instance == null)
				{
					instance = new LogManager();
				}
				return instance;
			} 
		}
		#endregion

		#region Observer
		public void NotifyCreation(User newUser)
		{
			Console.WriteLine($"Caro Admin, è stato aggiunto un nuovo utente: {newUser.Name}");
		}
		#endregion
	}
}
