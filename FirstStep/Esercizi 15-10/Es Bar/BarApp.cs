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

		private IBeverage myCoffe;
		private IBeverage myTea;

		public void Execute()
		{
			myCoffe = new Coffee();
			Console.WriteLine(myCoffe.Description());

			myCoffe = new WithMilkDecorator(myCoffe);
			Console.WriteLine(myCoffe.Description());

			myCoffe = new WithChoccolateDecorator(myCoffe);
			Console.WriteLine(myCoffe.Description());
		}
	}
}
