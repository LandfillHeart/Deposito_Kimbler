using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_17_10.Esercizi_Semplici
{
	public class ProductManagementApp : IGenericExercise
	{
		string IGenericExercise.Name => "Gestione prodotti";

		private Dictionary<string, int> stock = new Dictionary<string, int>();

		public void Execute()
		{
			

			while (true)
			{
				Console.WriteLine("Scegli un opzione");
				Console.WriteLine("0 - Esci");
				Console.WriteLine("1 - Aggiungi quantità di prodotto");
				Console.WriteLine("2 - Rimuovi quantità di prodotto");
				Console.WriteLine("3 - Stampa un prodotto");
				Console.WriteLine("4 - Stampa tutti i prodotti");

				Program.SanitizeInput(out int choice, mustBePositive: true);
				if(choice > 4)
				{
					Console.WriteLine("Opzione non riconosciuta");
					continue;
				}

				switch(choice)
				{
					case 0:
						Console.WriteLine("Alla prossima");
						return;
					case 1:
						AddProductStock();
						break;
					case 2:
						RemoveProductStock();
						break;
					case 3:
						PrintProduct();
						break;
					case 4:
						PrintAllProducts();
						break;
				}
			}

		}

		private string SanitizeKey(string key)
		{
			return key.Trim().ToLower();
		}

		private void AddProductStock()
		{
			Console.WriteLine("Quale prodotto vuoi aggiungere?");
			Program.SanitizeInput(out string item);
			item = SanitizeKey(item);
			if(!stock.ContainsKey(item))
			{
				stock.Add(item, 0);
			}

			Console.WriteLine("Quantità di prodotto da aggiungere");
			Program.SanitizeInput(out int amount, mustBePositive: true);
			stock[item] += amount;

		}

		private void RemoveProductStock()
		{
			Console.WriteLine("Quale prodotto vuoi rimuovere?");
			Program.SanitizeInput(out string item);
			item = SanitizeKey(item);
			if (!stock.ContainsKey(item))
			{
				Console.WriteLine("Questo oggetto non è nell'inventario");
				return;
			}

			Console.WriteLine("Quantità di prodotto da rimuovere");
			Program.SanitizeInput(out int amount, mustBePositive: true);
			stock[item] = Math.Max(stock[item] - amount, 0);
		}

		private void PrintProduct()
		{
			Console.WriteLine("Inserisci il nome del prodotto che vuoi visualizzare");
			Program.SanitizeInput(out string item);
			item = SanitizeKey(item);
			
			ProductDetail(item);
		}

		private void PrintAllProducts()
		{
			foreach (string key in stock.Keys)
			{
				ProductDetail(key);
			}
		}

		private void ProductDetail(string product)
		{
			if (!stock.ContainsKey(product))
			{
				Console.WriteLine("Prodotto non riconosciuto");
				return;
			}
			Console.WriteLine($"{product} - {stock[product]}");
		}
	}

}
