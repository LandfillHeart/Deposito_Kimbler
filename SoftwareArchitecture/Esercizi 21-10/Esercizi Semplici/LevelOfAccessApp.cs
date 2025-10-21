using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.Esercizi_Semplici
{
	public class LevelOfAccessApp : IExecutable
	{
		public void Run()
		{
			while (true)
			{
				Random rng = new Random();
				IEnumerable<AccessLevel> allLevels = Enum.GetValues<AccessLevel>();
				AccessLevel level = (AccessLevel)rng.Next(0, allLevels.Count());

				Console.Write(LevelOfAccess(level));
				Console.WriteLine("Premi un tasto per vedere un altro random \n");
				Console.ReadKey(true);
			}
			
		}

		private string LevelOfAccess(AccessLevel level)
		{
			string definedAcces = PermissionsByAccessLevel(AccessLevel.None);

			switch (level)
			{
				case AccessLevel.Admin:
					definedAcces = $"Hai i seguenti permessi: \n" +
						$"{PermissionsByAccessLevel(AccessLevel.Admin)} \n" +
						$"{PermissionsByAccessLevel(AccessLevel.User)} \n" +
						$"{PermissionsByAccessLevel(AccessLevel.Guest)} \n";
					break;
				case AccessLevel.User:
					definedAcces = $"Hai i seguenti permessi: \n" +
						$"{PermissionsByAccessLevel(AccessLevel.User)}  \n" +
						$"{PermissionsByAccessLevel(AccessLevel.Guest)}  \n";
					break;
				case AccessLevel.Guest:
					definedAcces = $"Hai i seguenti permessi: \n" +
						$"{PermissionsByAccessLevel(AccessLevel.Guest)}  \n";
					break;
				default:
					definedAcces = PermissionsByAccessLevel(AccessLevel.None) + "\n";
					break;
			}

			return definedAcces;
		}

		private string PermissionsByAccessLevel(AccessLevel level) 
		{
			switch (level)
			{
				case AccessLevel.Admin:
					return "Rimuovere post, bannare utenti";
				case AccessLevel.User:
					return "Creare post, bloccare utenti";
				case AccessLevel.Guest:
					return "Visualizzare post";
				default:
					return "Nessun permesso";
			}
		}
	}

	public enum AccessLevel
	{
		None = 0,
		Guest = 1,
		User = 2,
		Admin = 3,
	}
}
