using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class PrintCustomGreeting : IGenericExercise
	{
		public string Name => "Saluto Customizzato";

		public void Execute()
		{
			Console.WriteLine("Inserisci il tuo nome");
			CustomGreeting(Console.ReadLine());
		}

		private void CustomGreeting(string? username)
		{
			Console.WriteLine($"Ciao, {username}");
		}

	}
}
