using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_20_10
{
	public class BankApp : IGenericExercise
	{
		public string Name => "Database Bancario - Dizionari";

		public void Execute()
		{
			while(true)
			{
				Console.WriteLine("0 - Esci");
				Console.WriteLine("1 - Registra Conto");
				Console.WriteLine("2 - Effettua un operazione");
				Program.SanitizeInput(out int choice, mustBePositive: true);
				if (choice >= 3)
				{
					Console.WriteLine("Operazione non riconosciuta");
					continue;
				}

				switch (choice) 
				{
					case 0:
						Console.WriteLine("Grazie per aver usato la Banca C#, alla prossima!");
						return;
					case 1:
						CreateAccount();
						break;
					case 2:
						Console.WriteLine("Inserisci l'ID del conto al quale accedere");
						Program.SanitizeInput(out int id, mustBePositive: true);
						if(!BankManager.Instance.AllAccounts.ContainsKey(id))
						{
							Console.WriteLine("Non esiste un account con quel id nel database");
							continue;
						}
						PickOperation(id);
						break;
				}
			}
		}

		private void CreateAccount()
		{
			Console.WriteLine("Che tipo di conto vuoi creare?");
			Console.WriteLine("0 - Conto Standard");
			Console.WriteLine("1 - Conto Premium");
			Console.WriteLine("2 - Conto Studente");
			Program.SanitizeInput(out int choice);
			AccountType type = choice switch
			{
				0 => AccountType.Base,
				1 => AccountType.Premium,
				2 => AccountType.Student,
				_ => default
			};

			Console.WriteLine("Aggiungi fondi per coprire il costo della creazione del conto");
			Program.SanitizeInput(out float amount);
			if(BankManager.Instance.AddAccount(type, amount, out int accountID))
			{
				Console.WriteLine($"Account creato con successo! ID del tuo nuovo account: {accountID}");
				return;
			}
		}

		private void PickOperation(int accountID)
		{
			while(true)
			{
				Console.WriteLine("Quale operazione vuoi effettuare?");
				Console.WriteLine("0 - Torna indietro");
				Console.WriteLine("1 - Elimina Conto");
				Console.WriteLine("2 - Effettua Deposito");
				Console.WriteLine("3 - Effettua Prelievo");

				Program.SanitizeInput(out int choice);

				switch (choice)
				{
					case 0:
						Console.WriteLine("A dopo");
						return;
					case 1:
						// remove from db
						Console.WriteLine("Grazie per averci scelti");
						return;
					case 2:
						Console.WriteLine("Quanto vuoi depositare?");
						Program.SanitizeInput(out float amount, mustBePositive: true);
						BankManager.Instance.MakeDeposit(BankManager.Instance.AllAccounts[accountID], amount);
						break;
					case 3:
						Console.WriteLine("Quanto vuoi prelevare?");
						Program.SanitizeInput(out amount, mustBePositive: true);
						BankManager.Instance.MakeWithdrawal(BankManager.Instance.AllAccounts[accountID], amount);
						break;
				}
			}
		}

		private void Deposit(int userID)
		{

		}

		private void Withdraw(int userID)
		{

		}

		private void DeleteUser(int userID)
		{

		}

	}
}
