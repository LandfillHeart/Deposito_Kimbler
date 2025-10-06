using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class DoubleIntegerRef : IGenericExercise
	{
		string IGenericExercise.Name => "Raddoppia Intero";
		private int n = 2;
		public void Execute()
		{
			Console.WriteLine($"Prima di raddoppiader {n}");
			Double(ref n);
			Console.WriteLine($"Dopo aver raddoppiato {n}");
		}

		private void Double(ref int n)
		{
			n *= 2;
		}

	}
}
