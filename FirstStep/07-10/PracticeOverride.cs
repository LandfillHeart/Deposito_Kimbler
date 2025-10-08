using FirstStep._07_10.Corso_Multidisciplinale;
using FirstStep._07_10.Es_Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._07_10
{
	internal class PracticeOverride : IChoiceMenu
	{
		string IChoiceMenu.Name => "Ottobre 07";
		private ChoiceMenu choiceMenu;

		public PracticeOverride()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new OverrideMetodiObj(), new Es_Macchina(), new Es_Videoteca(), new Es_VehicleInheritance(), new Es_CorsoMultidisciplinare()});
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}
	}
}
