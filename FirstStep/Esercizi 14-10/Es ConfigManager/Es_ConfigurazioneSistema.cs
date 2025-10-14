using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_14_10.Es_ConfigManager
{
	public class Es_ConfigurazioneSistema : IGenericExercise
	{
		public string Name => "Esercizio Configurazione Sistema";

		public void Execute()
		{
			SettingsModule audioSettings = new SettingsModule("Audio", new Dictionary<string, string>() {
				{ "Volume", "100" }, { "Output Device", "Default" }, { "Quality", "Default"}

			});

			SettingsModule videoSettings = new SettingsModule("Video", new Dictionary<string, string> {
				{ "Resolution", "Detected Resolution" }, { "Framecap", "60fps" }, { "Motion Blur", "On"}
			});

			audioSettings.SaveConfig();
			videoSettings.SaveConfig();
			ConfigManager.Instance.PrintAllConfigs();
			Console.WriteLine();

			audioSettings.SetConfig("Output Device", "Headphones");
			videoSettings.SetConfig("Resolution", "1920x1080p");
			videoSettings.SetConfig("Framecap", "Unlimited");
			videoSettings.SetConfig("Motion Blur", "Off");

			audioSettings.SaveConfig();
			videoSettings.SaveConfig();

			ConfigManager.Instance.PrintAllConfigs();
		}
	}

	public class SettingsModule
	{
		private string category;
		Dictionary<string, string> options = new Dictionary<string, string>();
		public SettingsModule(string category, Dictionary<string, string> options)
		{
			this.category = category;
			this.options = options;
		}

		public void SetConfig(string key, string value)
		{
			if (options.ContainsKey(key))
			{
				options[key] = value;
			}
		}

		public void SaveConfig()
		{
			foreach (string option in options.Keys)
			{
				ConfigManager.Instance.SetConfig(option, options[option]);
			}
		}
	}
}
