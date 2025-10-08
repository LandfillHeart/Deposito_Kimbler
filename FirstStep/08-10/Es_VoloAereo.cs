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
			flight = new Flight(GetNewID);
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new ReserveSeats(this), new RemoveReservations(this)});
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
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
			Console.WriteLine("Quanti posti vuoi prenotare?");
			Program.SanitizeInput(out int sanitizedInt, mustBePositive: true);

			if(owner.flight.ReserveSeats(sanitizedInt))
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
		const int MAX_SEATS = 150;
		private int occupiedSeats;

		public int FlightID { get; private set; }

		public int OccupiedSeats => occupiedSeats;
		public int AvailableSeats => MAX_SEATS - occupiedSeats;

		public Flight(int flightID)
		{
			FlightID = flightID;
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
			Console.WriteLine($"Codice Volo: {FlightID} - Posti Occupati: {OccupiedSeats} - Posti Liberi: {AvailableSeats}");
		}
	}
}
