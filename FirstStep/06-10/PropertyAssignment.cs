using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._06_10
{
	internal class PropertyAssignment : IGenericExercise
	{
		string IGenericExercise.Name => "Assegnazione proprietà";
		private Student[] students = new Student[2];
		private int sanitizedInput; 
		public void Execute()
		{

			students[0] = new Student();
			students[1] = new Student();

			students[0].Name = "Giovanni";
			students[0].Surname = "Rossi";
			students[0].YearOfBirth = 2003;

			students[1].Name = "Roberto";
			students[1].Surname = "Bianchi";
			students[1].YearOfBirth = 2004;

			for(int i = 0; i < students.Length; i++)
			{
				Console.WriteLine($"{i} - {students[i].Name}");
			}

			while(true)
			{
				Console.WriteLine("Scegli quale utente vedere, premere ENTER per chiudere il programma");
				Program.SanitizeInput(out sanitizedInput, mustBePositive: true);
				if(sanitizedInput > students.Length)
				{
					Console.WriteLine("Indice fuori dal range, riprovare");
					continue;
				}

				students[sanitizedInput].PrintInfo();
				Console.WriteLine($"HashCode: {students[sanitizedInput].GetHashCode()}");
			}

		}

		public class Student
		{
			public string Name { get; set; }
			public string Surname { get; set; }
			public int YearOfBirth { get; set; }


			public void PrintInfo()
			{
				Console.WriteLine($"Studente {this.ToString()} nato nell'anno {YearOfBirth}");
			}

			public override string ToString()
			{
				return $"{Name} {Surname}";
			}

			public override int GetHashCode()
			{
				return HashCode.Combine(Name, Surname, YearOfBirth);
			}

		}

	}
}
