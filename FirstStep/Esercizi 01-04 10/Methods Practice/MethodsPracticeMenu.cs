using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class MethodsPracticeMenu : IChoiceMenu
	{
		public string Name => "Esercizi METODI";
		private ChoiceMenu choiceMenu;

		public MethodsPracticeMenu()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new PrintCustomGreeting(), new CheckEven(), new CalculatePower(), new DoubleIntegerRef(), new AdjustDate(), new Divide(), new AnalyzeString(), new ElaborateStudent(), new UpdateScore(), new OverloadedAddition(), new AnalyzeStringOverloaded()});
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}
	}
}
