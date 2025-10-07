using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._07_10
{
	internal class OverrideMetodiObj : IGenericExercise
	{
		string IGenericExercise.Name => "Override Metodi Obj";

		private List<Book> books = new List<Book>();

		private string? sanitizedInput;
		private int sanitizedInt;

		public void Execute()
		{
			while (true)
			{
				
				Console.WriteLine("Scegli un opzione");
				Console.WriteLine("ENTER - Termina il programma");
				Console.WriteLine("0 - Crea un libro");
				Console.WriteLine("1 - Paragona due libri");

				Program.SanitizeInput(out sanitizedInt, mustBePositive: true);
				if (sanitizedInt > 1)
				{
					Console.WriteLine("Istruzione non riconosciuta");
					continue;
				}

				if (sanitizedInt == 0)
				{
					CreateBook();
					continue;
				}

				Console.WriteLine("Scegli due libri da paragonare");

				PrintBookList();

				Console.WriteLine("Libro uno");
				Program.SanitizeInput(out sanitizedInt);

				if (sanitizedInt >= books.Count)
				{
					Console.WriteLine("Selezione non riconosciuta");
					continue;
				}
				int bookOne = sanitizedInt;

				Console.WriteLine("Libro due");
				Program.SanitizeInput(out sanitizedInt);

				if (sanitizedInt >= books.Count)
				{
					Console.WriteLine("Selezione non riconosciuta");
					continue;
				}

				Console.WriteLine($"Libro Uno: {books[bookOne].ToString()}");
				Console.WriteLine($"Libro Due: {books[sanitizedInt].ToString()}");

				Console.WriteLine($"I libri sono uguali? {books[bookOne].Equals(books[sanitizedInt])}");

			}
		}

		private void CreateBook()
		{
			Console.Clear();
			Console.WriteLine("Inserisci il titolo del libro");
			Program.SanitizeInput(out sanitizedInput);
			string title = sanitizedInput;

			Console.WriteLine("Inserisci l'autore del libro");
			Program.SanitizeInput(out sanitizedInput);

			Console.WriteLine("Inserisci l'anno di publicazione del libro");
			Program.SanitizeInput(out sanitizedInt);

			books.Add(new Book(title, sanitizedInput, sanitizedInt));
		}

		private void PrintBookList()
		{
			Console.Clear();
			for (int i = 0; i < books.Count; i++)
			{
				Console.WriteLine($"{i} - {books[i].ToString()}");
			}
		}

		public class Book
		{
			public string Title;
			public string Author;
			public int YearOfPublishing;

			public Book(string title, string author, int yearOfPublishing)
			{
				Title = title;
				Author = author;
				YearOfPublishing = yearOfPublishing;
			}

			public override string ToString()
			{
				return $"\"{Title}\" di {Author} ({YearOfPublishing})";
			}

			public override int GetHashCode()
			{
				return HashCode.Combine(Title, Author);
			}

			public override bool Equals(object? obj)
			{
				if (obj == null) return false;

				if (obj is Book other)
				{
					return other.GetHashCode() == GetHashCode();
				}

				return false;
			}

		}

	}
}
