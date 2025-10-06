using FirstStep.Choice_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Collections_Practice
{
	internal class CollectionsPracticeMenu : IChoiceMenu
	{
		string IChoiceMenu.Name => "Collezioni";

		private ChoiceMenu choiceMenu;

		public CollectionsPracticeMenu()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new GradesInArray(), new GroceryList(), new SumOfInts(), new SumOfRandoms(), new FindItemInArray(), new RemoveFromList(), new FindItemAndEven(), new OrderUniques()});
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}

	}
}
