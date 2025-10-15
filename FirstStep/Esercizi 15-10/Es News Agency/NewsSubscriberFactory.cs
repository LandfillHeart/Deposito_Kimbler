using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_News_Agency
{

	public class NewsSubscriberFactory
	{
		public void CreateSubscriber(ClientType type)
		{
			INewsSubscriber newsSubscriber = type switch
			{
				ClientType.Email => new EmailClient(),
				ClientType.Mobile => new MobileApp(),
				_ => new EmailClient() // def
			};

			NewsAgency.Instance.AddSubscriber(newsSubscriber);
		}
	}
}
