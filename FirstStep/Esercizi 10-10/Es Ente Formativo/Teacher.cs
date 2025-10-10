using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Ente_Formativo
{
	public class Teacher
	{
		private string name;
		public string Name => name;

		private string subject;
		public string Subject => subject;

		private List<Course> taughtCourses = new();
		public ReadOnlyCollection<Course> TaughtCourses => taughtCourses.AsReadOnly();

		public Teacher(string name, string subject)
		{
			this.name = name;
			this.subject = subject;
		}

		public void AddCourse(Course course)
		{
			taughtCourses.Add(course);
		}

		public void RemoveCourse(Course course)
		{
			taughtCourses.Remove(course);
		}

	}
}
