using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep
{
	internal class ConditionalsPractice : IChoiceMenu
	{
		string IChoiceMenu.Name => "Esercizi IF";
		const int ADULT_AGE = 18;

		const int DISCOUNT_PERCENTAGE = 10;
		const int MIN_PRICE_FOR_DISCOUNT = 100;

		const int MIN_PASSING_GRADE = 60;
		const int GRADES_TO_CHECK = 3;

		const int PIN = 1103;

		private float sanitizedInput;
		private float preciseSanitizedInput;

		public void IsUserAdult()
		{
			Console.WriteLine("Inserisci la tua età: ");
			Program.SanitizeInput(out sanitizedInput);
			if (sanitizedInput >= ADULT_AGE) 
			{
				Console.WriteLine("Sei maggiorenne");
				return;
			}

			Console.WriteLine("Sei minorenne");
		}

		public void ConditionalDiscount()
		{
			Console.WriteLine("Inserisci il prezzo del prodotto (solo il numero, non inserire simboli come €)");
			Program.SanitizeInput(out sanitizedInput);
			if(!(sanitizedInput >= MIN_PRICE_FOR_DISCOUNT))
			{
				Console.WriteLine($"Non sei elegibile per uno sconto, mi dispiace. Compra qualcosa che costi almeno {MIN_PRICE_FOR_DISCOUNT}!");
				return;
			}

			float discountedPrice = sanitizedInput - DISCOUNT_PERCENTAGE * sanitizedInput / 100;
			Console.WriteLine($"Prodotto sopra i {MIN_PRICE_FOR_DISCOUNT} euro, prezzo finale con sconto del {DISCOUNT_PERCENTAGE} = {discountedPrice.ToString("0.##")}");

		}

		public void AverageGrade()
		{
			double gradesSum = 0;

			for (int i = 0; i < GRADES_TO_CHECK; i++)
			{
				Console.WriteLine($"Inserisci voto {i+1}/{GRADES_TO_CHECK}");
				Program.SanitizeInput(out sanitizedInput);
				while(sanitizedInput < 0 || sanitizedInput > 100)
				{
					Console.WriteLine("Inserisci un valore valido da 0 a 100");
					Program.SanitizeInput(out sanitizedInput);
				} 
				gradesSum += (int)sanitizedInput;
			}

			gradesSum /= GRADES_TO_CHECK;

			if( gradesSum < MIN_PASSING_GRADE )
			{
				Console.WriteLine($"Il tuo punteggio di {gradesSum} non supera la media minima del {MIN_PASSING_GRADE}");
				Console.WriteLine("Prova fallita.");
				return;
			}

			Console.WriteLine($"Il tuo punteggio di {gradesSum} supera la media minima del {MIN_PASSING_GRADE}");
			Console.WriteLine("Hai superato la prova!");

		}

		public void IsNumberEven()
		{
			Console.WriteLine("Inserisci un numero");
			Program.SanitizeInput(out sanitizedInput);
			if ((int)sanitizedInput % 2 == 0)
			{
				Console.WriteLine("Il numero è pari");
				return;
			}

			Console.WriteLine("Il numero è dispari");

		}

		public void CheckPIN()
		{
			Console.WriteLine("Inserisci il tuo PIN");
			Program.SanitizeInput(out sanitizedInput);
			if((int)sanitizedInput == PIN)
			{
				Console.WriteLine("Accesso Consentito");
				return;
			}

			Console.WriteLine("Accesso Negato");
		}

		public void PreciseAddition()
		{
			bool isAddition = true;

			Console.WriteLine("Inserisci il primo numero:");
			Program.SanitizeInput(out preciseSanitizedInput);
			double firstNumber = preciseSanitizedInput;

			Console.WriteLine("Inserisci l'operatore + o -");
			string? input = Console.ReadLine();
			while (true)
			{
				if(string.IsNullOrEmpty(input))
				{
					Console.WriteLine("Inserisci l'operatore + o -");
					input = Console.ReadLine();
					continue;
				}

				if (input.Contains("+"))
				{
					input = "+";
					isAddition = true;
					break;
				}
				else if(input.Contains("-"))
				{
					input = "-";
					isAddition = false;
					break;
				}

				Console.WriteLine("Inserisci l'operatore + o -");
				input = Console.ReadLine();

			}
			

			

			Console.WriteLine("Inserisci il secondo numero:");
			Program.SanitizeInput(out preciseSanitizedInput);
			double secondNumber = preciseSanitizedInput;

			double result;
			if (isAddition)
			{
				result = firstNumber + secondNumber;
			} else
			{
				result = firstNumber - secondNumber;
			}

			Console.WriteLine($"Il risultato di {firstNumber} {input} {secondNumber} = {result}");

		}

		/// <summary>
		/// Forces user to input a real number, or exit the application by inputting an empty string
		/// </summary>
		/// <param name="sanitizedInput">If input is a real number, its value is parsed in sanitizedInput</param>
		

		private void SanitizeInput(out double sanitizedInput)
		{
			while (true)
			{
				string? input = Console.ReadLine();
				if (string.IsNullOrEmpty(input))
				{
					Console.WriteLine("Grazie per aver usato la mia applicazione. A dopo!");
					Environment.Exit(0);
				}

				if (!double.TryParse(input, out sanitizedInput))
				{
					PrintError();
					continue;
				}
				break;
			}
		}

		private void PrintError()
		{
			Console.WriteLine("Perfavore, inserire un numero");
		}

		public void OptionsMenu()
		{
			while (true)
			{
				Console.WriteLine("Selezione un esercizio");
				Console.WriteLine("ENTER - Chiudi Programma");
				Console.WriteLine("0 - Ritorna a selezione di categorie");
				Console.WriteLine("1 - Controllo Magiorenne");
				Console.WriteLine("2 - Sconto Condizionale");
				Console.WriteLine("3 - Punteggio Medio");
				Console.WriteLine("4 - Numero Pari");
				Console.WriteLine("5 - Inserisci PIN");
				Console.WriteLine("6 - Addizione Double");

				Program.SanitizeInput(out sanitizedInput);
				int pickedOption = (int)sanitizedInput;
				switch(pickedOption)
				{
					case 0:
						Console.Clear();
						return;
					case 1:
						Console.Clear();
						IsUserAdult();
						break;
					case 2:
						Console.Clear();
						ConditionalDiscount();
						break;
					case 3:
						Console.Clear();
						AverageGrade();
						break;
					case 4:
						Console.Clear();
						IsNumberEven();
						break;
					case 5:
						Console.Clear();
						CheckPIN();
						break;
					case 6:
						Console.Clear();
						PreciseAddition();
						break;
					default:
						Console.WriteLine("Esercizio non riconosciuto");
						break;
				}

				Console.WriteLine("Premi qualsiasi tasto per tornare al menu");
				Console.ReadKey(true);
				Console.Clear();

			}
		}

		
	}
}
