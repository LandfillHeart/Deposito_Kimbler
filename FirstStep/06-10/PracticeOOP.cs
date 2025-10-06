using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._06_10
{
	internal class PracticeOOP : IChoiceMenu
	{
		public string Name => "Ottobre 06";
		private ChoiceMenu choiceMenu;

		public PracticeOOP() 
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new EsempioStudente(), new PropertyAssignment(), new SumAndMultiply() });
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}
	}
}
