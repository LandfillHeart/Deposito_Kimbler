using FirstStep._07_10;
using FirstStep._07_10.Corso_Multidisciplinale;
using FirstStep._07_10.Es_Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Choice_Menu
{
	internal class ExerciseCollection : IChoiceMenu
	{
		private string header;
		string IChoiceMenu.Name => header;
		private ChoiceMenu choiceMenu;

		public ExerciseCollection(string header, IGenericExercise[] exercises)
		{
			this.header = header;
			choiceMenu = new ChoiceMenu(exercises);
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}
	}
}
