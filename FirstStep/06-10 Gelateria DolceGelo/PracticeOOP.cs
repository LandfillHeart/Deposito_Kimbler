using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._06_10_Gelateria_DolceGelo
{
	internal class PracticeOOP : IChoiceMenu
	{
		public string Name => "Ottobre 06";
		private ChoiceMenu choiceMenu;

		public PracticeOOP() 
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new EsempioStudente(), new PropertyAssignment() });
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}
	}
}
