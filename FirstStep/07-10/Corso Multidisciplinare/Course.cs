using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._07_10.Corso_Multidisciplinale
{
	// Classe astratta: non possiamo avere corsi generici dove non si studia nulla
	internal abstract class Course
	{
		public string Name;
		public int Hours;
		public string Teacher;
		public List<string> Students = new();

		public Course(string name, int hours, string teacher)
		{
			Name = name;
			Hours = hours;
			Teacher = teacher;
		}

		public void AddStudent(string newStudent)
		{
			Students.Add(newStudent);
		}

		public override string ToString()
		{
			return $"Corso: {Name} - Docente: {Teacher} - Durata: {Hours} - Numero Student: {Students.Count}";
		}

		// Il Metodo Speciale
		public abstract void Description();
	}

	internal class MusicCourse : Course
	{
		public string Instrument;

		public MusicCourse(string name, int hours, string teacher, string instrument) : base(name, hours, teacher)
		{
			Instrument = instrument;
		}

		public override string ToString()
		{
			return $"{base.ToString()} - Strumento: {Instrument}";
		}

		public override void Description()
		{
			Console.WriteLine($"Si tiene una prova pratica dello strumento: {Instrument}");
		}
	}

	internal class PaintCourse : Course
	{
		public string Technique;

		public PaintCourse(string name, int hours, string teacher, string technique) : base(name, hours, teacher)
		{
			Technique = technique;
		}

		public override string ToString()
		{
			return $"{base.ToString()} - Tecnica: {Technique}";
		}
		public override void Description()
		{
			Console.WriteLine($"Si lavora su una tela con tecnica: {Technique}");
		}
	}

	internal class DanceCourse : Course
	{
		public string Style;

		public DanceCourse(string name, int hours, string teacher, string style) : base(name, hours, teacher)
		{
			Style = style;
		}

		public override string ToString()
		{
			return $"{base.ToString()} - Stile: {Style}";
		}

		public override void Description()
		{
			Console.WriteLine($"Esecuzione coreografica nello stile: {Style}");
		}
	}
}
