using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_13_10_Design_Pattern.Es_Singleton.Log_History
{
	public sealed class LocationManager
	{
		private static LocationManager instance;
		public static LocationManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new LocationManager();
				}
				return instance;
			}
		}

		private LocationManager() { }

		private List<string> locations = new();
		private Random rng = new Random();

		public void AddLocation(string location)
		{
			if(string.IsNullOrWhiteSpace(location))
			{
				Console.WriteLine("Impossibile aggiungere, la stringa è vuota");
				return;
			}
			locations.Add(location);
		}

		public string GetRandomLocation()
		{
			if (locations.Count == 0)
			{
				return "null";
			}
			return locations[rng.Next(0, locations.Count)];
		}
	}
}
