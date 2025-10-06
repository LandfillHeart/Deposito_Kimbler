using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._06_10_Gelateria_DolceGelo
{
	internal class PropertyAssignment : IGenericExercise
	{
		string IGenericExercise.Name => "Assegnazione proprietà";

		public void Execute()
		{
			Student studentOne = new Student();
			Student studentTwo = new Student();

			studentOne.Name = "Giovanni";
			studentOne.Surname = "Rossi";
			studentOne.YearOfBirth = 2003;

			studentTwo.Name = "Roberto";
			studentTwo.Surname = "Bianchi";
			studentTwo.YearOfBirth = 2004;

			studentOne.PrintInfo();
			studentTwo.PrintInfo();

		}

		public class Student
		{
			public string Name { get; set; }
			public string Surname { get; set; }
			public int YearOfBirth { get; set; }


			public void PrintInfo()
			{
				Console.WriteLine($"Studente {Name} {Surname} nato nell'anno {YearOfBirth}");
			}

		}

	}
}
