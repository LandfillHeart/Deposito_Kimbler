using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_User_Manager
{
	// MarketingManager è un singleton visto che nel contesto dell'app, dal lato server un admin può avere la necessità di cambiare o aggiungere promozioni
	// Per questo un singolo punto di accesso a tutti questi dati, assicurandosi che siano coerenti per tutti gli utenti
	public class MarketingManager : IUserCreationObserver
	{
		#region Singleton
		private static MarketingManager instance;
		public static MarketingManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new MarketingManager();
				}
				return instance;
			}
		}
		#endregion

		private string newUserPromotion = "Sei elegibile alla promozione 'nuovo utente' che fornisce lo sconto del 20%";

		#region Observer
		public void NotifyCreation(User newUser)
		{
			// qui andiamo a chiamare il nostro utente nello specifico, in modo che non pensiamo ad una notifica globale, ma ad una per il singolo cliente interpellato
			newUser.ReceiveMessage(newUserPromotion);
		}
		#endregion
	}
}
