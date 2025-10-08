using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._08_10
{
	internal class Es_VoloAereo : IGenericExercise
	{
		string IGenericExercise.Name => "Esercizio Volo Aereo";
		private ChoiceMenu choiceMenu;

		private static int availableID = 1;
		public static int GetNewID => availableID++;

		public Flight flight;

		public Es_VoloAereo()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new CreateFlight(this), new ReserveSeats(this), new RemoveReservations(this)});
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}
	}

	internal class CreateFlight : IGenericExercise
	{
		string IGenericExercise.Name => "Crea nuova prenotazione";
		private Es_VoloAereo owner;
		public CreateFlight(Es_VoloAereo owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			Console.WriteLine("Inserisci la destinazione del volo");
			Program.SanitizeInput(out string sanitizedString);
			owner.flight = new Flight(sanitizedString);
		}
	}

	internal class ReserveSeats : IGenericExercise
	{
		string IGenericExercise.Name => "Prenota Posti";
		private Es_VoloAereo owner;
		public ReserveSeats(Es_VoloAereo owner)
		{
			this.owner = owner;
		}

		public void Execute() 
		{
			if (owner.flight == null)
			{
				Console.WriteLine("Sembra che non ci sia un volo attivo");
				return;
			}

			Console.WriteLine("Quanti posti vuoi prenotare?");
			Program.SanitizeInput(out int sanitizedInt, mustBePositive: true);

			if (owner.flight.ReserveSeats(sanitizedInt))
			{
				Console.WriteLine("Operazione completata");
				owner.flight.FlightState();
				return;
			}

			Console.WriteLine("Operazione non possibile");
			owner.flight.FlightState();

		}	
	}

	internal class RemoveReservations : IGenericExercise
	{
		string IGenericExercise.Name => "Rimuovi Prenotazioni";
		private Es_VoloAereo owner;
		public RemoveReservations(Es_VoloAereo owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			if (owner.flight == null)
			{
				Console.WriteLine("Sembra che non ci sia un volo attivo");
				return;
			}

			Console.WriteLine("Quante prenotazioni vuoi rimuovere?");
			Program.SanitizeInput(out int sanitizedInt);

			if(owner.flight.UndoReservations(sanitizedInt))
			{
				Console.WriteLine("Operazione Completata");
				owner.flight.FlightState();
				return;
			}

			Console.WriteLine("Operazione non possibile");
			owner.flight.FlightState();
		}

	}

	internal class Flight
	{
		public int MAX_SEATS => 20;
		private int occupiedSeats;

		public int FlightID { get; private set; }
		public string Destination { get; set; }
		public int OccupiedSeats => occupiedSeats;
		public int AvailableSeats => MAX_SEATS - occupiedSeats;

		public Flight(string destination)
		{
			FlightID = Es_VoloAereo.GetNewID;
			Destination = destination;
		}

 		public bool ReserveSeats(int seats)
		{
			if (AvailableSeats - seats >= 0)
			{
				occupiedSeats += seats;
				return true;
			}

			return false;
		}

		public bool UndoReservations(int seats)
		{
			if (OccupiedSeats - seats >= 0)
			{
				occupiedSeats -= seats;
				return true;
			}

			return false;
		}

		public void FlightState()
		{
			Console.WriteLine($"Codice Volo: {FlightID} - Destinazione: {Destination} - Posti Occupati: {OccupiedSeats} - Posti Liberi: {AvailableSeats}");
		}
	}
}
