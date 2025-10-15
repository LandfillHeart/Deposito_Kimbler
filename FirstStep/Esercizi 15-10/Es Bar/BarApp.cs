using FirstStep.Esercizi_15_10.Es_Bar.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_Bar
{
	public class BarApp : IGenericExercise
	{
		public string Name => "Bar - Decorator";

		public void Execute()
		{
			IBeverage myCoffe = new Coffee();
			Console.WriteLine(myCoffe.Description());

			IBeverage myCoffeeWithMilk = new WithMilkDecorator(myCoffe);
			Console.WriteLine(myCoffeeWithMilk.Description());

			IBeverage myCoffeWithChocolate = new WithChoccolateDecorator(myCoffeeWithMilk);
			Console.WriteLine(myCoffeWithChocolate.Description());
		}
	}
}
