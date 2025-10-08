
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

			// Quando costruiamo un oggetto di tipo AddCourse, dobbiamo accoppiare la funzionalità di questo oggetto ad una sottoclasse di tipo Corso
			// Questo perché, nonostante grazie al polimorfismo siamo in grado di trattare ogni oggetto di sottoclasse di Corso come se fosse un istanza del padre, il programma deve essere consapevole del tipo concreto almeno alla sua creazione
			
			// In un certo senso si applica il "Factory Pattern" dove abbiamo un punto di accesso per creare nuovi oggetti
			// Ogni "Creatore" di Corsi poteva anch'esso essere una sottoclasse a sua volta, che poteva creare solo un oggetto di un tipo, ma preferisco usare gli enum.
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
			if (owner.courses.Count == 0)
			{
				return;
			}
			
			Console.WriteLine("Seleziona un corso");
			Program.SanitizeInput(out int sanitizedInt, mustBePositive: true);

			while(sanitizedInt >= owner.courses.Count)
			{
				Console.WriteLine("Corso non riconosciuto, riprova");
				Program.SanitizeInput(out sanitizedInt);
			}

			Console.WriteLine("Inserisci il nome dello studente");
			Program.SanitizeInput(out string sanitizedString);

			owner.courses[sanitizedInt].AddStudent(sanitizedString);

		}
	}

	internal class PrintAllCourses : IGenericExercise 
	{
		string IGenericExercise.Name => "Vedi tutti i corsi";
		private Es_CorsoMultidisciplinare owner;

		public PrintAllCourses(Es_CorsoMultidisciplinare owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			owner.PrintAllCourses(showStudents: true);
		}
	}

	internal class PrintCourseDescription : IGenericExercise
	{
		string IGenericExercise.Name => "Vedi descrizione corso";
		private Es_CorsoMultidisciplinare owner;
		public PrintCourseDescription(Es_CorsoMultidisciplinare owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			owner.PrintAllCourses();
			if (owner.courses.Count == 0)
			{
				return;
			}

			Console.WriteLine("Seleziona un corso");
			Program.SanitizeInput(out int sanitizedInt, mustBePositive: true);

			while (sanitizedInt >= owner.courses.Count)
			{
				Console.WriteLine("Corso non riconosciuto, riprova");
				Program.SanitizeInput(out sanitizedInt);
			}

			// Polimorfismo, trattiamo ogni istanza di sottoclassi Corso concrete come se fosse del tipo del padre
			owner.courses[sanitizedInt].Description();

		}

	}

	internal class SearchByTeacher : IGenericExercise
	{
		string IGenericExercise.Name => "Filtra corsi per docenti";
		private Es_CorsoMultidisciplinare owner;
		public SearchByTeacher(Es_CorsoMultidisciplinare owner)
		{
			this.owner = owner;
		}
		
		public void Execute()
		{
			owner.PrintAllCourses();
			if(owner.courses.Count == 0)
			{
				return;
			}

			Console.WriteLine("Inserisci il docente per il quale filtrare");
			Program.SanitizeInput(out string sanitizedString);

			List<Course> filtered = new List<Course>();
			foreach(Course course in owner.courses)
			{
				if (!course.Teacher.ToLower().Contains(sanitizedString.ToLower())) continue;
				// if (course.Teacher.ToLower() != sanitizedString.ToLower()) continue;
				filtered.Add(course);
			}

			if (filtered.Count == 0) 
			{
				Console.WriteLine("Sembra che questo docente non ha corsi");
				return;
			}

			Console.WriteLine($"Il docente {sanitizedString} ha i seguenti corsi");
			foreach (Course course in filtered)
			{
				Console.WriteLine(course.ToString());
			}

		}
	}

}
