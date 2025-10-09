using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._09_10.Esercizio_Operatore
{
	public enum OperatorType
	{
		Default = 0,
		Emergency,
		Security,
		Logistic
	}

	internal abstract class Operator 
	{
		public virtual OperatorType Type => OperatorType.Default;
		
		private string name;
		private string shift;

		public string Name { get => name; set => name = value; }

		public Operator(string name, string shift)
		{
			Name = name;
			Shift = shift;
		}

		public string Shift
		{
			get => shift;
			set
			{
				if ("giorno".Contains(value.ToLower())) { shift = "Giorno"; return; }
				if ("notte".Contains(value.ToLower())) { shift = "Notte"; return; }

				if(string.IsNullOrEmpty(shift))
				{
					shift = "Giorno";
				}
			}
		}

		public virtual void DoJob()
		{
			Console.WriteLine("Operatore generico in servizio");
		}

		public static string TypeToName(OperatorType type)
		{
			string output = "Generico";
			switch (type)
			{
				case OperatorType.Emergency:
					output = "Emergenza";
					break;
				case OperatorType.Security:
					output = "Sicurezza";
					break;
				case OperatorType.Logistic:
					output = "Logistica";
					break;
			}
			return output;
		}

	}

	internal class EmergencyOperator : Operator
	{
		public override OperatorType Type => OperatorType.Emergency;
		private int emergencyLevel;

		public int EmergencyLevel 
		{ 
			get => emergencyLevel; 
			set
			{
				emergencyLevel = Math.Clamp(value, 1, 5);
			}
		}

		public EmergencyOperator(string name, string shift, int emergencyLevel) : base(name, shift)
		{
			EmergencyLevel = emergencyLevel;
		}

		public override void DoJob()
		{
			Console.WriteLine($"Gestione di emergenza di livello {EmergencyLevel}");
		}
	}

	internal class SecurityOperator : Operator
	{
		public override OperatorType Type => OperatorType.Security;
		private string overwatchArea;

		public string OverwatchArea { get => overwatchArea; set => overwatchArea = value; }

		public SecurityOperator(string name, string shift, string area) : base(name, shift)
		{
			OverwatchArea = area;
		}

		public override void DoJob()
		{
			Console.WriteLine($"Sorveglianza dell'area {OverwatchArea}");
		}
	}

	internal class LogisticOperator : Operator
	{
		public override OperatorType Type => OperatorType.Logistic;
		private int deliveries;
		public int Deliveries
		{
			get => deliveries;
			set
			{
				deliveries = Math.Max(value, 0);
			}
		}

		public LogisticOperator(string name, string shift, int deliveries) : base(name, shift)
		{
			Deliveries = deliveries;
		}

		public override void DoJob()
		{
			Console.WriteLine($"Coordinamento di {Deliveries} consegne");
		}
	}

}
