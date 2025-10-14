using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_14_10.Es_ConfigManager
{
	public class ConfigManager
	{
		private static ConfigManager instance;
		public static ConfigManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ConfigManager();
				}
				return instance;
			}
		}
		private ConfigManager() { }

		private Dictionary<string, string> savedConfigs = new();

		public void SetConfig(string key, string value) 
		{
			if (savedConfigs.ContainsKey(key))
			{
				savedConfigs[key] = value;
				return;
			}

			savedConfigs.Add(key, value);
		}

		public void PrintConfig(string key)
		{
			if (savedConfigs.ContainsKey(key))
			{
				Console.WriteLine($"{key}: {savedConfigs[key]}");
				return;
			}

			Console.WriteLine("Config not set");
		}

		public void PrintAllConfigs()
		{
			foreach (string key in savedConfigs.Keys)
			{
				Console.WriteLine($"{key}: {savedConfigs[key]}");
			}
		}
	}
}
