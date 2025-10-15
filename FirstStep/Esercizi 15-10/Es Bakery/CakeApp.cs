using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bakery
{
	public class CakeApp : IGenericExercise
	{
		string IGenericExercise.Name => "Torte - Decorator e Factory";

		public void Execute()
		{
			ICake myCake = CakeFactory.CreateCake(CakeType.Chocolate);
			Console.WriteLine(myCake.Description());

			myCake = CakeFactory.DecorateCake(myCake, Decorators.DecoratorType.WithStrawberries);
			Console.WriteLine(myCake.Description());

			myCake = CakeFactory.DecorateCake(myCake, Decorators.DecoratorType.WithStrawberries);
			Console.WriteLine(myCake.Description());
		}
	}
}
