
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._07_10.Corso_Multidisciplinale
{
	// Actions
	internal class AddCourse : IGenericExercise
	{
		private string name;
		public string Name => name;

		private Es_CorsoMultidisciplinare owner;

		private CourseType type;

		private string sanitizedString;
		private int sanitizedInt;

		public AddCourse(string name, CourseType type, Es_CorsoMultidisciplinare owner)
		{
			this.name = name;
			this.type = type;
			this.owner = owner;
		}

		public void Execute()
		{
			Console.WriteLine("Inserisci il nome del corso");
			Program.SanitizeInput(out sanitizedString);
			string courseName = sanitizedString;

			Console.WriteLine("Inserisci il docente del corso");
			Program.SanitizeInput(out sanitizedString);
			string teacher = sanitizedString;

			Console.WriteLine("Inserisci la durata del corso in ore intere");
			Program.SanitizeInput(out sanitizedInt);

			switch (type)
			{
				case CourseType.Music:
					Console.WriteLine("Inserisci lo strumento del corso");
					Program.SanitizeInput(out sanitizedString);
					MusicCourse musicCourse = new MusicCourse(courseName, sanitizedInt, teacher, sanitizedString);
					owner.courses.Add(musicCourse);
					break;
				case CourseType.Dance:
					Console.WriteLine("Inserisci lo stile del corso");
					Program.SanitizeInput(out sanitizedString);
					DanceCourse danceCourse = new DanceCourse(courseName, sanitizedInt, teacher, sanitizedString);
					owner.courses.Add(danceCourse);
					break;
				case CourseType.Paint:
					Console.WriteLine();
					Program.SanitizeInput(out sanitizedString);
					PaintCourse paintCourse = new PaintCourse(courseName, sanitizedInt, teacher, sanitizedString);
					owner.courses.Add(paintCourse);
					break;
			}
		}
	}
	internal class AddStudentToCourse : IGenericExercise
	{
		public string Name => "Aggiungi Studente a Corso";
		private Es_CorsoMultidisciplinare owner;

		public AddStudentToCourse(Es_CorsoMultidisciplinare owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			owner.PrintAllCourses();
			Console.WriteLine("Seleziona un corso");
			Program.SanitizeInput(out int sanitizedInt, mustBePositive: true);

			while(sanitizedInt > owner.courses.Count)
			{
				Console.WriteLine("Corso non riconosciuto, riprova");
				Program.SanitizeInput(out sanitizedInt);
			}

		}
	}

}
