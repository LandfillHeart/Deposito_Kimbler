using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._09_10.Esercizio_Operatore
{
	internal class AddOperator : IGenericExercise
	{
		private string name;
		public string Name => name;

		private OperatorType type;
		private Es_Operatore owner;

		public AddOperator(OperatorType type, Es_Operatore owner)
		{
			this.type = type;
			this.owner = owner;

			if(type == OperatorType.Default)
			{
				Console.Error.WriteLine("ERR: Tentativo di aggiungere operatore astratto");
				name = "ERR: operatore astratto";
				return;
			}

			name = $"Aggiungi operatore di {Operator.TypeToName(type)}";
		}

		public void Execute()
		{
			Console.WriteLine("Inserisci il nome dell'operatore");
			Program.SanitizeInput(out string opName);

			Console.WriteLine("Inserisci il turno dell'operatore");
			Program.SanitizeInput(out string shift);

			switch(type)
			{
				case OperatorType.Emergency:
					Console.WriteLine("Inserisci il livello di emergenza");
					Program.SanitizeInput(out int level, mustBePositive: true);
					EmergencyOperator emergencyOperator = new EmergencyOperator(opName, shift, level);
					owner.AddOperator(emergencyOperator);
					break;
				case OperatorType.Security:
					Console.WriteLine("Inserisci l'area sorvegliata");
					Program.SanitizeInput(out string area);
					SecurityOperator securityOperator = new SecurityOperator(opName, shift, area);
					owner.AddOperator(securityOperator);
					break;
				case OperatorType.Logistic:
					Console.WriteLine("Inserisci le consegne");
					Program.SanitizeInput(out int deliveries, mustBePositive: true);
					LogisticOperator logisticOperator = new LogisticOperator(opName, shift, deliveries);
					owner.AddOperator(logisticOperator);
					break;
				default:
					Console.Error.WriteLine("ERR: Tentato di aggiungere un operatore astratto");
					break;
			}
		}
	}

	internal class PrintOperators : IGenericExercise
	{
		string IGenericExercise.Name => "Stampa operatori";
		private Es_Operatore owner;

		public PrintOperators(Es_Operatore owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			List<Operator> toPrint = owner.GetOperators();

			if (toPrint.Count == 0)
			{
				Console.WriteLine("Sembra che non hai operatori");
				return;
			}

			foreach (Operator op in toPrint)
			{
				Console.WriteLine($"Operatore di {Operator.TypeToName(op.Type)} - {op.Name} - Turno: {op.Shift}");
			}
		}
	}

	internal class DoOperatorJobs : IGenericExercise
	{
		private string name;
		string IGenericExercise.Name => name;
		private OperatorType type;
		private Es_Operatore owner;

		public DoOperatorJobs(OperatorType type, Es_Operatore owner)
		{
			this.type = type;
			this.owner = owner;

			name = $"Esegui il lavoro degli operatori di tipo {Operator.TypeToName(type)}";
		}
		public void Execute()
		{
			foreach(Operator op in owner.GetOperators())
			{
				if (op.Type != type) continue;
				Console.WriteLine($"{op.Name}:");
				op.DoJob();
			}
		}
	}


}
