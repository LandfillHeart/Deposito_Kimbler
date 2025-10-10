using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_10_10.Es_Ente_Formativo
{
	internal class Es_EnteFormativo : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Ente Formativo";

		private List<Course> availableCourses = new();

		public void Execute()
		{

		}
	}
}
