using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._06_10_Gelateria_DolceGelo
{
	internal class EsempioStudente : IGenericExercise
	{
		private static int availableId = 1;
		public static int GetNewID
		{
			get { return availableId++; }
		}

		string IGenericExercise.Name => "Esempio Studente";

		public void Execute()
		{
			Student studentOne = new Student("Sasy", 9.8);
			Student studentTwo = new Student("Ciro", 5.7);

			studentOne.PrintInfo();
			studentTwo.PrintInfo();
		}

		public class Student
		{
			private string name;
			private int id;
			private double average;

			public string Name => name;
			public int ID => id;
			public double Average => average;

			public Student(string name, double average)
			{
				this.name = name;
				this.average = average;
				this.id = EsempioStudente.GetNewID;
			}

			public void PrintInfo()
			{
				Console.WriteLine($"Matricola {this.ID}: {this.Name}. Media: {this.Average}");
			}

		}
	}
}
