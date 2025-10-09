using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._09_10.Esercizio_Operatore
{
	internal class Es_Operatore : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Operatore";
		private ChoiceMenu choiceMenu;

		private List<Operator> operators = new();

		public Es_Operatore()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] {
				new AddOperator(OperatorType.Emergency, this),
				new AddOperator(OperatorType.Security, this),
				new AddOperator(OperatorType.Logistic, this),
				new PrintOperators(this),
				new DoOperatorJobs(OperatorType.Emergency, this),
				new DoOperatorJobs(OperatorType.Security, this),
				new DoOperatorJobs(OperatorType.Logistic, this)
			});
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}

		public void AddOperator(Operator op)
		{ 
			operators.Add(op);
		}

		public List<Operator> GetOperators()
		{
			return operators;
		}

		public static void DoOperatorJob(Operator op)
		{
			op.DoJob();
		}
	}
}
