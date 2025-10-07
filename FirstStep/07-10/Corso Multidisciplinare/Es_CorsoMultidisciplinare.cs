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
				new AddCourse("Aggiungi Corso Pittura", CourseType.Paint, this)

			}, header: "Scegli un opzione");
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}

		public void PrintAllCourses()
		{
			for (int i = 0; i < courses.Count; i++) 
			{
				Console.WriteLine($"{i} - {courses[i].Name}");
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
