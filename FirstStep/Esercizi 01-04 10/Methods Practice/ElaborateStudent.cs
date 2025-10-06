using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class ElaborateStudent : IGenericExercise
	{
		string IGenericExercise.Name => "Elabora Studente";

		private int sanitizedInput;


		public void Execute()
		{
			Console.WriteLine("Inserisci primo voto");
			Program.SanitizeInput(out sanitizedInput);
			int gradeOne = sanitizedInput;

			Console.WriteLine("Inserisci secondo voto");
			Program.SanitizeInput(out sanitizedInput);
			int gradeTwo = sanitizedInput;

			if(Elaborate(ref gradeOne, ref gradeTwo, out float average))
			{
				Console.WriteLine($"La media del {average} significa che sei promosso");
			} else
			{
				Console.WriteLine($"Mi dispiace, ma la media del {average} non è sufficiente");
			}

		}

		private bool Elaborate(ref int gradeOne, ref int gradeTwo, out float average)
		{
			average = (gradeOne + gradeTwo) / 2;
			return average >= 6;
		}

	}
}
