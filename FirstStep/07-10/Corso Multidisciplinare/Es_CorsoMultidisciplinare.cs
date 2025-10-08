using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._07_10.Corso_Multidisciplinale
{
	internal class Es_CorsoMultidisciplinare : IGenericExercise
	{
		string IGenericExercise.Name => "Esempio Corso Multidisciplinare";

		public List<Course> courses = new();
		private ChoiceMenu choiceMenu;
		public Es_CorsoMultidisciplinare() 
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] {
				new AddCourse("Aggiungi Corso Musica", CourseType.Music, this),
				new AddCourse("Aggiungi Corso Danza", CourseType.Dance, this),
				new AddCourse("Aggiungi Corso Pittura", CourseType.Paint, this),
				new AddStudentToCourse(this),
				new PrintAllCourses(this),
				new PrintCourseDescription(this),
				new SearchByTeacher(this),
			}, header: "Scegli un opzione");
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}

		public void PrintAllCourses(bool showStudents = false)
		{
			if (courses.Count == 0)
			{
				Console.WriteLine("Sembra che non ci sono ancora corsi");
				return;
			}

			for (int i = 0; i < courses.Count; i++) 
			{
				Console.WriteLine($"{i} - {courses[i].ToString()}");

				if (!showStudents) continue;
				if (courses[i].Students.Count == 0) continue;

				Console.WriteLine("Studenti: ");
				foreach (string student in courses[i].Students)
				{
					Console.WriteLine(student);
				}
			}
		}
	}

	// Courses
	internal enum CourseType
	{
		Music,
		Dance,
		Paint,
	}

}
