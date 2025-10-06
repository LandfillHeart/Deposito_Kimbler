using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._06_10
{
	internal class GelateriaDolceGelo : IChoiceMenu
	{
		string IChoiceMenu.Name => "Gelateria Dolce Gelo";

		private ChoiceMenu choiceMenu;
		public IGenericExercise PrintMenu;

		public List<IcecreamData> icecreams = new();
		
		public GelateriaDolceGelo()
		{
			PrintMenu = new PrintIcecreamMenu(this);
			choiceMenu = new ChoiceMenu( new IGenericExercise[] { PrintMenu, new AddIcecream(this), new BuyIcecream(this)});
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();
		}
	}

	internal class PrintIcecreamMenu : IGenericExercise
	{
		public string Name => "Stampa Menù";
		private GelateriaDolceGelo owner;

		public PrintIcecreamMenu(GelateriaDolceGelo gelateriaDolceGelo)
		{
			this.owner = gelateriaDolceGelo;
		}

		public void Execute()
		{
			if(owner.icecreams.Count == 0)
			{
				Console.WriteLine("Sembra il menù sia vuoto, aggiungi dei gusti");
				return;
			}

			for(int i = 0; i < owner.icecreams.Count; i++)
			{
				Console.WriteLine($"{i+1} - {owner.icecreams[i].Name}");
			}
		}
	}

	internal class AddIcecream : IGenericExercise
	{
		string IGenericExercise.Name => "Aggiungi Gelato";
		private GelateriaDolceGelo owner;

		private double sanitizedInput;

		public AddIcecream(GelateriaDolceGelo gelateriaDolceGelo)
		{
			this.owner = gelateriaDolceGelo;
		}

		public void Execute()
		{
			Console.WriteLine("Gelati già nel menù:");
			owner.PrintMenu.Execute();

			while(true)
			{
				Console.WriteLine("Inserisci un nuovo gustso di gelato, o premi ENTER per concludere la creazione di gelati");
				string? input = Console.ReadLine();
				if(string.IsNullOrEmpty(input))
				{
					return;
				}

				bool itemExists = false;
				foreach(IcecreamData data in owner.icecreams)
				{
					if(data.Name.ToLower() == input.ToLower())
					{
						itemExists = true;
						Console.WriteLine("Sembra sia presente un gelato con un nome simile, riprova");
						break;
					}
				}

				if (itemExists) continue;

				Console.WriteLine("Inserisci il prezzo del gelato");
				Program.SanitizeInput(out sanitizedInput, mustBePositive: true);
				owner.icecreams.Add(new IcecreamData(input, sanitizedInput));
			}
		}


	}

	internal class BuyIcecream : IGenericExercise
	{
		const double MIN_DISCOUT_PRICE = 10;
		const int DISCOUNT = 10;

		string IGenericExercise.Name => "Compra Gelato";
		private GelateriaDolceGelo owner;

		private int sanitizedInput;

		private List<IcecreamOrder> order = new();

		public BuyIcecream(GelateriaDolceGelo gelateriaDolceGelo)
		{
			this.owner = gelateriaDolceGelo;
		}

		public void Execute()
		{
			order.Clear();
			owner.PrintMenu.Execute();
			if(owner.icecreams.Count == 0)
			{
				return;
			}
			OrderIcecream();
			PrintTotal();
		}

		private void OrderIcecream()
		{
			while (true)
			{
				Console.WriteLine("Scegli un gelato, oppure inserisci 0 per finire l'ordine");
				Program.SanitizeInput(out sanitizedInput, mustBePositive: true);
				int index = sanitizedInput;

				if(sanitizedInput == 0)
				{
					break;
				}

				if(sanitizedInput > owner.icecreams.Count)
				{
					Console.WriteLine("Indice non riconosciuto");
					continue;
				}


				index--;

				Console.WriteLine("Inserisci una quantità da comprare");
				Program.SanitizeInput(out sanitizedInput);

				IcecreamOrder newItem = new IcecreamOrder(owner.icecreams[index], sanitizedInput);
				order.Add(newItem);
				PrintOrder(newItem);
			}
		}

		private void PrintOrder(IcecreamOrder orderItem)
		{
			Console.WriteLine($"Il costo del gelato è €{orderItem.Data.Price * orderItem.Quantity}");
		}

		private void PrintTotal()
		{
			double tot = 0;
			foreach(IcecreamOrder item in order)
			{
				tot += item.Data.Price * item.Quantity;
			}

			string msg = "0";
			if (tot >= MIN_DISCOUT_PRICE)
			{
				msg = DISCOUNT.ToString();
				tot -= (DISCOUNT * tot) / 100;
			}

			Console.WriteLine($"L'ordine ha un costo di €{tot.ToString("0.##")} con lo sconto del {msg}%");
		}


		private struct IcecreamOrder
		{
			public IcecreamData Data;
			public int Quantity;
			public IcecreamOrder(IcecreamData data, int quantity)
			{
				this.Data = data;
				this.Quantity = quantity;
			}
		}
	}


	public struct IcecreamData
	{
		public string Name;
		public double Price;
		public IcecreamData(string name, double price)
		{
			Name = name;
			Price = price;
		}
	}

}
