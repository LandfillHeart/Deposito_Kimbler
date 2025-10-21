using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.Esercizi_Semplici
{
	public class WeekdaysApp : IExecutable
	{
		public void Run()
		{
			Weekdays testDays = Weekdays.Thursday | Weekdays.Friday;

			Console.WriteLine($"Nel corso C# facciamo i test i giorni: {testDays.ToString()}");
		}
	}

	[Flags]
	public enum Weekdays
	{
		Monday = 1, 
		Tuesday = 2, 
		Wednesday = 4,
		Thursday = 8,
		Friday = 16,
	}
}
