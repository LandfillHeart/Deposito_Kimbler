using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Ente_Formativo
{
	public class AddCourse : IGenericExercise
	{
		private string name;
		string IGenericExercise.Name => name;

		private Es_EnteFormativo owner;
		private CourseType type;

		public AddCourse(CourseType type, Es_EnteFormativo owner)
		{
			this.owner = owner;
			this.type = type;

			name = type switch
			{
				CourseType.InPerson => "Aggiungi un corso in presenza",
				CourseType.Online => "Aggiungi un corso online",
				_ => "Aggiungi un corso"
			};
		}

		public void Execute()
		{
			Console.WriteLine("Inserisci il nome del corso");
			Program.SanitizeInput(out string title);

			Console.WriteLine("Inserisci la durata in ore intere");
			Program.SanitizeInput(out int hours, mustBePositive: true);

			switch (type)
			{
				case CourseType.InPerson:
					Console.WriteLine("Inserisci il nome dell'aula dove si svolge il corso");
					Program.SanitizeInput(out string classroom);
					Console.WriteLine("Inserisci il numero di posti disponibili");
					Program.SanitizeInput(out int seats);
					InPersonCourse inPerson = new InPersonCourse(title, hours, classroom, seats);
					owner.AddCourse(inPerson);
					break;
				case CourseType.Online:
					Console.WriteLine("Inserisci la piattaforma dove si svolge il corso");
					Program.SanitizeInput(out string platform);
					Console.WriteLine("Inserisci il link per seguire il corso");
					Program.SanitizeInput(out string link);
					OnlineCourse remote = new OnlineCourse(title, hours, platform, link);
					owner.AddCourse(remote);
					break;
			}
		}
	}
}
