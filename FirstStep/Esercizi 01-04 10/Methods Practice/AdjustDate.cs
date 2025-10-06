using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class AdjustDate : IGenericExercise
	{
		string IGenericExercise.Name => "Aggiusta Data";

		private SimpleDate date = new();

		public void Execute()
		{
			Console.WriteLine("Ultimo valore di data");
			date.PrintDate();

			Console.WriteLine("Inserisci giorno");
			Program.SanitizeInput(out date.Day, mustBePositive: true);

			Console.WriteLine("Inserisci mese");
			Program.SanitizeInput(out date.Month, mustBePositive: true);

			Console.WriteLine("Inserisci anno");
			Program.SanitizeInput(out date.Year, mustBePositive: true);

			Console.WriteLine("Prima del controllo");
			date.PrintDate();

			Adjust(ref date.Day, ref date.Month, ref date.Year);

			Console.WriteLine("Dopo il controllo");
			date.PrintDate();
		}

		private void Adjust(ref int day, ref int month, ref int year)
		{
			if(day > 30)
			{
				day = 1;
				month++;
			}

			if (month > 12) 
			{
				month = 1;
				year++;
			}

		}

		private class SimpleDate
		{
			private int day = 1;
			private int month = 1;
			private int year = 2000;

			public ref int Day
			{
				get => ref day;
			}

			public ref int Month
			{
				get => ref month;
			}

			public ref int Year
			{
				get => ref year; 
			}

			public void PrintDate()
			{
				Console.WriteLine($"Data: {day}/{month}/{year}");
			}

		}

	}
}
