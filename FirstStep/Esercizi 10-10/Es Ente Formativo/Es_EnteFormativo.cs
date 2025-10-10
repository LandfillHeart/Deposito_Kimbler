using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Ente_Formativo
{
	public class Es_EnteFormativo : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Ente Formativo";
		private ChoiceMenu choiceMenu;

		private List<Course> availableCourses = new(){
			new InPersonCourse("Ceramica Bella", 10, "Aula Magna", 15),
			new OnlineCourse("Business Medievale", 360, "Microsoft Teams", "teams.meeting/1134.com")
		};

		public Es_EnteFormativo()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] {
				new AddCourse(CourseType.InPerson, this),
				new AddCourse(CourseType.Online, this),
			});
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}

		public void DeliverCourse(Course course)
		{
			course.DeliverCourse();
		}

		public void PrintDetails(Course course)
		{
			course.PrintDetails();
		}

		public void AddCourse(Course course)
		{
			availableCourses.Add(course);
		}
	}
}
