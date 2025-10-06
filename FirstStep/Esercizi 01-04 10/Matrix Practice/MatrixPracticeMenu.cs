using FirstStep.Matrix_Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep
{
	internal class MatrixPracticeMenu : IChoiceMenu
	{
		string IChoiceMenu.Name => "Matrici";
		private ChoiceMenu choiceMenu;

		public MatrixPracticeMenu()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new SumOfMatrixContent(), new MatrixComparison(), new DiagonalSum()});
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}

	}
}
