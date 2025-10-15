using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_News_Agency
{
	public class NewsAgency
	{
		#region Singleton
		private static NewsAgency instance;
		public static NewsAgency Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new NewsAgency();
				}

				return instance;
			}
		}

		private NewsAgency() { }
		#endregion

		private HashSet<INewsSubscriber> subscribers = new HashSet<INewsSubscriber>();
		
		private NewsSubscriberFactory factory = new NewsSubscriberFactory();

		private List<string> news = new List<string>()
		{
			"Oggi si impara l'Observer Pattern", "Oggi si programma in C#", "Oggi si farà live-coding", "Oggi ci sarà la pausa pranzo alle 13:00"
		};

		private Random newsGenerator = new Random();

		public void PublishDailyNews()
		{
			Notify(news[newsGenerator.Next(0, news.Count)]);
		}

		#region Observer Subject Methods
		public void CreateSubscriber(ClientType type)
		{
			factory.CreateSubscriber(type);
		}

		public void AddSubscriber(INewsSubscriber newsSubscriber)
		{
			subscribers.Add(newsSubscriber);
		} 

		public void RemoveSubscriber(INewsSubscriber newsSubscriber)
		{
			subscribers.Remove(newsSubscriber);
		}

		public void Notify(string msg)
		{
			foreach (INewsSubscriber subscriber in subscribers)
			{
				subscriber.Update(msg);
			}
		} 
		#endregion

	}
}
