using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10
{
	public interface IDatabaseService
	{
		public void Connect();
	}

	public class SqlDatabaseService : IDatabaseService
	{
		public void Connect()
		{
			Console.WriteLine("Connessione al database SQL");
		}
	}

	public class ReportGenerator
	{
		public IDatabaseService DatabaseService { get; set; }
		public void GenerateReport()
		{
			if(DatabaseService == null)
			{
				Console.WriteLine("Database non impostato");
				return;
			}

			DatabaseService.Connect();
			Console.WriteLine("Generazione report in corso...");
		}
	}
}
