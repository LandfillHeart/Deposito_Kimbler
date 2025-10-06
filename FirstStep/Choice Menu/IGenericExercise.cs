using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep
{
	internal interface IGenericExercise
	{
		public string Name { get; }
		public void Execute();
	}
}
