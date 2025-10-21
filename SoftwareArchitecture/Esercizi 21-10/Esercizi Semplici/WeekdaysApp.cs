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
			Weekdays testDays = Weekdays.Thursday | Weekdays.Friday; // 01000 + 10000 = 11000

			Console.WriteLine($"Nel corso C# facciamo i test i giorni: {testDays.ToString()}");
		}
	}

	[Flags]
	public enum Weekdays
	{
		Monday = 1,		// 00001
		Tuesday = 2,	// 00010
		Wednesday = 4,	// 00100
		Thursday = 8,	// 01000
		Friday = 16,	// 10000
	}
}
