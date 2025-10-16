using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_16_10.Es_Calcolatrice
{
	public interface IOperationStrategy
	{
		public float Operate(float a, float b);
	}

	public class SumStrategy : IOperationStrategy
	{
		public float Operate(float a, float b)
		{
			return a + b;
		}
	}

	public class SubtractionStrategy : IOperationStrategy
	{
		public float Operate(float a, float b)
		{
			return a - b;
		}
	}

	public class MultiplicationStrategy : IOperationStrategy
	{
		public float Operate(float a, float b)
		{
			return a * b;
		}
	}

	public class DivisionStrategy : IOperationStrategy
	{
		public float Operate(float a, float b)
		{
			return a / b;
		}
	}
}
