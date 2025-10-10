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

		}

	}
}
