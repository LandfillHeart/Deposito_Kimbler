using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Collections_Practice
{
	internal class GradesInArray : IGenericExercise
	{
		string IGenericExercise.Name => "5 Studenti";

		private int[] grades = new int[5];

		public void Execute()
		{

			for (int i = 0; i < grades.Length; i++)
			{
				Console.WriteLine($"Inserisci il voto dello studente {i+1}");
				Program.SanitizeInput(out grades[i]);
			}

			Console.WriteLine($"La media dei voti è: {GetAverage()}");
			Console.WriteLine($"Il voto più basso è: {GetLowestGrade(out int c)} ripetuto {c} volte");
			Console.WriteLine($"Il voto più alto è: {GetHighestGrade(out c)} ripetuto {c} volte");
		}

		private float GetAverage()
		{
			float sum = 0;
			for(int i = 0;i < grades.Length;i++) 
			{ 
				sum += grades[i]; 
			}

			return sum / grades.Length;

		}

		private int GetHighestGrade(out int j)
		{
			int highest = grades[0];
			j = 1;

			for (int i = 1; i < grades.Length; i++)
			{
				if (highest == grades[i]) { j++; continue; }

				if (highest < grades[i])
				{
					highest = grades[i];
					j = 1;
				}
			}

			return highest;

		}

		private int GetLowestGrade(out int j) 
		{
			int lowest = grades[0];
			j = 1;

			for (int i = 1; i < grades.Length; i++)
			{
				if (lowest == grades[i]) { j++; continue; }

				if (lowest > grades[i])
				{
					lowest = grades[i];
					j = 1;
				}
			}

			return lowest;
		}
	}
}
