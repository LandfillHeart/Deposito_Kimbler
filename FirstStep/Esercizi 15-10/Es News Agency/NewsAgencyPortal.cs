using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_News_Agency
{
	public class NewsAgencyPortal : IGenericExercise
	{
		string IGenericExercise.Name => "News Agency - Multi Pattern";

		public NewsAgencyPortal() 
		{
			NewsAgency.Instance.CreateSubscriber(ClientType.Mobile);
			NewsAgency.Instance.CreateSubscriber(ClientType.Email);
		}

		public void Execute()
		{
			NewsAgency.Instance.PublishDailyNews();
		}
	}
}
