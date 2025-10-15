using FirstStep.Esercizi_15_10.Es_Bakery.Decorators;
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
			ICake myCake;

			Console.WriteLine("Scegli una torta! \n0 - Al Cioccolato \n1 - Alla frutta \n2 - Alla Vaniglia");
			Program.SanitizeInput(out int input, mustBePositive: true);
			// int -> enum casting
			myCake = CakeFactory.CreateCake((CakeType)input);

			while (true)
			{
				Console.WriteLine("Scegli un aggiunta: \n0 - Finito Aggiunte \n1 - Con Fragole \n2 - Con Panna\n3 - Con Glassa");
				Program.SanitizeInput(out int decorator, mustBePositive: true);

				if(decorator == 0)
				{
					break;
				}

				myCake = CakeFactory.DecorateCake(myCake, (DecoratorType)decorator);
			}

			Console.WriteLine(myCake.Description());
		}
	}
}
