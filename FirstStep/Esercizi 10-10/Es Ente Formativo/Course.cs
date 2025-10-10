using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Ente_Formativo
{
	public enum CourseType
	{
		Undefined = 0,
		InPerson,
		Online
	}

	public abstract class Course
	{
		private string title;
		private int lengthHours;

		public string Title => title;
		public int LengthHours
		{
			get => lengthHours;
			private set
			{
				lengthHours = Math.Max(value, 1);
			}
		}

		public virtual CourseType Type => CourseType.Undefined;

		public abstract void DeliverCourse();
		public abstract void PrintDetails();

		public Course(string title, int legthHours)
		{
			this.title = title;
			this.lengthHours = legthHours;
		}

		public override string ToString()
		{
			return $"Titolo Corso: {title} - Durata (Ore): {lengthHours}";
		}
	}

	public class InPersonCourse : Course
	{
		private string classroom;
		private int maxSeats;

		public int MaxSeats
		{
			get => maxSeats;
			private set
			{
				maxSeats = Math.Max(value, 1);
			}
		}

		public override CourseType Type => CourseType.InPerson;

		public InPersonCourse(string title, int legthHours, string classroom, int maxSeats) : base(title, legthHours)
		{
			this.classroom = classroom;
			MaxSeats = maxSeats;
		}

		public override void DeliverCourse()
		{
			Console.WriteLine($"Diamo inizio al corso in presenza: {Title}");
			Console.WriteLine($"Il corso oggi si svolge in aula {classroom}");
		}

		public override void PrintDetails()
		{
			Console.WriteLine(ToString());
		}

		public override string ToString()
		{
			return $"{base.ToString()} - Aula: {classroom} - Posti Disponibili: {maxSeats}";
		}
	}

	public class OnlineCourse : Course
	{
		private string platform;
		private string link;

		public override CourseType Type => CourseType.Online;

		public OnlineCourse(string title, int legthHours, string platform, string link) : base(title, legthHours)
		{
			this.platform = platform;
			this.link = link;
		}

		public override void DeliverCourse()
		{
			Console.WriteLine($"Diamo inizio al corso online: {Title}");
			Console.WriteLine($"Per accedere entrare a questo link {platform}: {link}");
		}

		public override void PrintDetails()
		{
			Console.WriteLine(ToString());
		}

		public override string ToString()
		{
			return $"{base.ToString()} - Piattaforma: {platform} - Link: {link}";
		}
	}

}
