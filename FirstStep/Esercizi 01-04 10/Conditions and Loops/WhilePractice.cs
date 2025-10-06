using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.While_Practice
{
	internal class WhilePractice : IChoiceMenu
	{
		string IChoiceMenu.Name => "Esercizi WHILE";
		private ChoiceMenu choiceMenu;

		private float sanitizedInput;
		private int sanitizedIntInput;

		public WhilePractice()
		{
			choiceMenu = new(new IGenericExercise[] { new GuessConstNumber(), new SumPositiveIntegers(), new Bancomat(), new GuessPassword(), new SumOfIntegers(), new Calculator() });
		}

		public void OptionsMenu()
		{
			choiceMenu.DisplayMenu();

			return;
		}

	}

	internal class Calculator : IGenericExercise
	{

		string IGenericExercise.Name => "Calcolatrice";

		private string? repeat;

		private float operatorOne;
		private float operatorTwo;

		private string? inputOperator;

		private Operation selectedOperation;

		private enum Operation
		{
			Addition,
			Subtraction,
			Multiplication,
			Division
		}

		public void Execute()
		{
			do
			{
				Console.WriteLine("Inserisci il primo numero");
				Program.SanitizeInput(out operatorOne);

				Console.WriteLine("Inserisci l'operatore");
				inputOperator = Console.ReadLine();
				while (true)
				{
					if (string.IsNullOrEmpty(inputOperator))
					{
						Console.WriteLine("Inserire un operatore");
						inputOperator = Console.ReadLine();
						continue;
					}

					if (inputOperator.Contains("+"))
					{
						selectedOperation = Operation.Addition;
						break;
					}

					if (inputOperator.Contains("-"))
					{
						selectedOperation = Operation.Subtraction;
						break;
					}

					if(inputOperator.Contains("*"))
					{
						selectedOperation = Operation.Multiplication;
						break;
					}

					if(inputOperator.Contains("/"))
					{
						selectedOperation = Operation.Division;
						break;
					}

					Console.WriteLine("Operatore non riconosciutom inserirne uno nuovo");
					inputOperator = Console.ReadLine();
					
				}

				Console.WriteLine("Inserisci il secondo numero");
				Program.SanitizeInput(out operatorTwo);

				switch(selectedOperation)
				{
					case Operation.Addition:
						Console.WriteLine($"{operatorOne} + {operatorTwo} = {operatorOne + operatorTwo}");
						break;
					case Operation.Subtraction:
						Console.WriteLine($"{operatorOne} - {operatorTwo} = {operatorOne - operatorTwo}");
						break;
					case Operation.Multiplication:
						Console.WriteLine($"{operatorOne} * {operatorTwo} = {operatorOne * operatorTwo}");
						break;
					case Operation.Division:
						Console.WriteLine($"{operatorOne} / {operatorTwo} = {operatorOne / operatorTwo}");
						break;
				}
				
				Console.WriteLine("Nuova Operazione Y / N");
				repeat = Console.ReadLine();

			} while (!string.IsNullOrEmpty(repeat) && (repeat.Contains("Y") || repeat.Contains("y")));
		}

	}

	internal class SumOfIntegers() : IGenericExercise
	{
		string IGenericExercise.Name => "Somma Interi";

		private int sanitizedInput;

		public void Execute()
		{
			Console.WriteLine("Inserisci numeri interi per fare la somma");
			Console.WriteLine("Inserisci ZERO per completare");
			Console.WriteLine("Inserisci ENTER per uscire dal programma");

			int i = 0;
			int sum = 0;
			do
			{
				Console.WriteLine("Inserisci il prossimo numero");
				Program.SanitizeInput(out sanitizedInput);
				sum += sanitizedInput;
				i++;
			} while (sanitizedInput != 0);
			Console.WriteLine($"Ha inserito {i-1} numeri per la somma di {sum}");
		}
	}

	internal class GuessPassword() : IGenericExercise
	{
		string IGenericExercise.Name => "Indovina Password";
		private int attemptsRemaining;
		const string PASSWORD = "CSharpAcademy";
		
		
		public void Execute()
		{
			attemptsRemaining = 3;
			Console.WriteLine("Inserisci la password");
			do
			{
				Console.WriteLine($"Tentativi rimasti: {attemptsRemaining}");
				string? input = Console.ReadLine();
				if(string.IsNullOrEmpty(input) || !input.Equals(PASSWORD))
				{
					Console.WriteLine("Password Errata");
					attemptsRemaining--;
					continue;
				}

				Console.WriteLine("Password Corretta");
				break;

			} while( attemptsRemaining > 0 );

			Console.WriteLine("Hai terminato i tentativi, account ELIMINATO");

		}

	}

	internal class Bancomat : IGenericExercise
	{
		private ChoiceMenu choiceMenu;
		private float balance;

		public float Balance
		{
			get => balance;
			set => balance = value;
		}
		string IGenericExercise.Name => "Bancomat";

		public Bancomat()
		{
			balance = 0f;
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new ViewBalance(this), new Deposit(this), new Withdraw(this) });
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}

		private class ViewBalance : IGenericExercise
		{
			private Bancomat bancomat;

			string IGenericExercise.Name => "Visualizza Saldo";

			public ViewBalance(Bancomat bancomat)
			{
				this.bancomat = bancomat;
			}

			public void Execute()
			{
				Console.WriteLine($"Hai attualmente un saldo di €{bancomat.Balance}");
			}
		}

		private class Deposit : IGenericExercise
		{
			private Bancomat bancomat;

			private float sanitizedInput;
			string IGenericExercise.Name => "Deposita Denaro";

			public Deposit(Bancomat bancomat)
			{
				this.bancomat = bancomat;
			}

			public void Execute()
			{
				Console.WriteLine("Inserire la quantità da depositare");
				Program.SanitizeInput(out sanitizedInput, mustBePositive: true);

				bancomat.Balance += sanitizedInput;
				Console.WriteLine("Operazione Completata");
			}
		}

		private class Withdraw : IGenericExercise
		{
			private Bancomat bancomat;
			private float sanitizedInput;
			string IGenericExercise.Name => "Preleva Denaro";

			public Withdraw(Bancomat bancomat)
			{
				this .bancomat = bancomat;	
			}

			public void Execute()
			{
				Console.WriteLine("Inserire la quantità da prelevare");
				Program.SanitizeInput(out sanitizedInput, mustBePositive: true);

				if(bancomat.Balance - sanitizedInput < 0)
				{
					Console.WriteLine("Non è possibile prelevare oltre il saldo disponibile");
					return;
				}
				
				bancomat.Balance -= sanitizedInput;
				Console.WriteLine("Operazione Completata");
			}

		}

	}

	internal class GuessConstNumber : IGenericExercise
	{
		const int GUESSABLE_NUMBER = 64;

		private int sanitizedInput;

		string IGenericExercise.Name => "Indovina il numero";

		public void Execute()
		{
			Console.WriteLine("Inserisci ENTER per chiudere il programma");

			while (true)
			{
				Console.WriteLine("Indovina il numero!");
				Program.SanitizeInput(out sanitizedInput);

				if (sanitizedInput == GUESSABLE_NUMBER)
				{
					Console.WriteLine("Hai indovinato!!");
					return;
				}

				if (sanitizedInput > GUESSABLE_NUMBER)
				{
					Console.WriteLine("Hai inserito un numero troppo alto, riprova!");
					continue;
				}

				if (sanitizedInput < GUESSABLE_NUMBER)
				{
					Console.WriteLine("Hai inserito un numero troppo basso, riprova!");
					continue;
				}
			}
		}

	}

	internal class SumPositiveIntegers : IGenericExercise
	{
		private int sanitizedInput;
		string IGenericExercise.Name => "Somma di numeri positivi";
		public void Execute()
		{
			Console.WriteLine("Inserisci ENTER per chiudere il programma, oppure un numero negativo per interrompere il ciclo");
			int sum = 0;
			int i = 0;

			while (true)
			{
				Console.WriteLine("Inserisci un numero positivo");
				Program.SanitizeInput(out sanitizedInput, mustBePositive: false);

				if (sanitizedInput < 0)
				{
					break;
				}

				sum += sanitizedInput;
				i++;
			}

			Console.WriteLine("Hai inserito un numero negativo, fine calcolo");
			Console.WriteLine($"Hai inserito {i} numeri positivi per una somma totale di {sum}");
		}
	}


}
