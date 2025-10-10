using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.VENERDI_TEST_PRATICO
{

	public class Es_Pratico
	{
		List<Animal> animals = new();
		void Main()
		{
			while(true)
			{
				Console.WriteLine("Scegli un opzione");

				Console.WriteLine("0 - Esci");
				Console.WriteLine("1 - Aggiungi Animale");
				Console.WriteLine("2 - Aggiungi Cane");
				Console.WriteLine("3 - Vedi tutti animali");
				string scelta = Console.ReadLine();
				int i = int.Parse(scelta);

				switch (i) 
				{ 
					case 0:
						Console.WriteLine("Fine esercizio");
						Environment.Exit(0);
						break;
					case 1:
						Console.WriteLine("Inserisci la specie dell'animale");
						animals.Add(new Animal(Console.ReadLine()));
						break;
					case 2:
						Console.WriteLine("Inserisci la specie del cane");
						animals.Add(new Dog(Console.ReadLine()));
						break;
					case 3:
						foreach (Animal a in animals)
						{
							a.GetSpecies();
						}
						break;
				}
			}
		}
	}


	internal class Animal
	{
		public string Species;
		private string hiddenToChild = "Il figlio e il programma non hanno accesso diretto a questa stringa";

		// con questo metodo possiamo far leggere la stringa nascosta private anche al figlio o altre parti del codice
		public string GetHiddenString()
		{
			return hiddenToChild;
		}
		
		public virtual void GetSpecies()
		{
			Console.WriteLine($"Sono un animale di specie: {Species}");
		}

		// costruttore
		public Animal(string species)
		{
			Species = species;
		}
	}


	internal class Dog : Animal
	{
		// chiamiamo il costruttore del padre per costruire la sottoclasse
		public Dog(string species) : base(species)
		{
		}


		// override: polimorfismo run-time
		public override void GetSpecies()
		{
			// usiamo un attributo ereditato dal padre
			Console.WriteLine($"sono un cane di specie: {Species}");
		}

		// overload: polimorfismo compile-time
		public void Abbaia()
		{
			Console.WriteLine("Il cane abbaia");
		}

		public void Abbaia(int volume)
		{
			Console.WriteLine($"Il cane abbaia con volume: {volume}");
		}
	}

}
