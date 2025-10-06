using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class OverloadedAddition : IGenericExercise
	{
		string IGenericExercise.Name => "Somma con Overload";

		private int sanitizedInt;
		private double sanitizedDouble;

		public void Execute()
		{
			Console.WriteLine("Inserisci due numeri interi");
			
			Console.WriteLine("A:");
			Program.SanitizeInput(out sanitizedInt);
			int a = sanitizedInt;

			Console.WriteLine("B:");
			Program.SanitizeInput(out sanitizedInt);
			int b = sanitizedInt;

			Console.WriteLine($"{a} + {b} = {Add(a, b)}");

			Console.WriteLine("Inserisci due numeri double");
			
			Console.WriteLine("A:");
			Program.SanitizeInput(out sanitizedDouble);
			double aDouble = sanitizedDouble;

			Console.WriteLine("B:");
			Program.SanitizeInput(out sanitizedDouble);
			double bDouble = sanitizedDouble;

			Console.WriteLine($"{aDouble} + {bDouble} = {Add(aDouble, bDouble)}");


			Console.WriteLine("Inserisci tre numeri interi");

			Console.WriteLine("A:");
			Program.SanitizeInput(out sanitizedInt);
			a = sanitizedInt;

			Console.WriteLine("B:");
			Program.SanitizeInput(out sanitizedInt);
			b = sanitizedInt;

			Console.WriteLine("C:");
			Program.SanitizeInput(out sanitizedInt);
			int c = sanitizedInt;

			Console.WriteLine($"{a} + {b} = {Add(a, b, c)}");

		}

		private int Add(int a, int b)
		{
			return a + b;
		}

		private double Add(double a, double b)
		{
			return a + b;
		}

		private int Add(int a, int b, int c)
		{
			return a + b + c;
		}

	}

}
