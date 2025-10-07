using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep._07_10
{
	internal class Es_Videoteca : IGenericExercise
	{
		string IGenericExercise.Name => "Videoteca";
		private ChoiceMenu choiceMenu;

		public List<Movie> movies = new();

		public Es_Videoteca()
		{
			choiceMenu = new ChoiceMenu(new IGenericExercise[] { new AddMovie(this), new PrintAllMovies(this), new FilterByGenre(this)}, header: "Scegli un opzione");
		}

		public void Execute()
		{
			choiceMenu.DisplayMenu();
		}

		public static void PrintMovies(List<Movie> toPrint)
		{
			if(toPrint.Count == 0)
			{
				Console.WriteLine("Sembra che non ci sono film da mostrarti");
			}

			foreach (Movie movie in toPrint)
			{
				Console.WriteLine(movie.ToString());
			}
		}

		public static HashSet<string> GetGenres(List<Movie> toQuery)
		{
			HashSet<string> uniques = new HashSet<string>();
			foreach (Movie movie in toQuery) 
			{
				uniques.Add(movie.Genre);
			}

			return uniques;

		}


	}

	internal class Movie
	{
		public string Title;
		public string Director;
		public int ReleaseYear;
		public string Genre;

		public Movie(string title, string director, int releaseYear, string genre)
		{
			Title = title;
			Director = director;
			ReleaseYear = releaseYear;
			Genre = genre;
		}

		public override string ToString()
		{
			return $"\"{Title}\" di {Director} ({ReleaseYear} - {Genre})";
		}

		public bool CompareGenre(string genre)
		{
			return Genre.ToLower() == genre.ToLower();
		}

	}

	internal class AddMovie : IGenericExercise
	{
		string IGenericExercise.Name => "Aggiungi Film";
		private Es_Videoteca owner;

		private string sanitizedString;
		private int sanitizedInt;

		public AddMovie(Es_Videoteca owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			Console.WriteLine("Inserisci titolo del film");
			Program.SanitizeInput(out sanitizedString);

			string title = sanitizedString;

			Console.WriteLine("Inserisci il regista");
			Program.SanitizeInput(out sanitizedString);

			string director = sanitizedString;

			Console.WriteLine("Inserisci l'anno");
			Program.SanitizeInput(out sanitizedInt);

			Console.WriteLine("Inserisci il genere");
			Program.SanitizeInput(out sanitizedString);

			owner.movies.Add(new Movie(title, director, sanitizedInt, sanitizedString));
			Console.WriteLine("Operazione completata");
		}
	}

	internal class PrintAllMovies : IGenericExercise
	{
		string IGenericExercise.Name => "Stampa tutti i film";
		private Es_Videoteca owner;
		public PrintAllMovies(Es_Videoteca owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			Es_Videoteca.PrintMovies(owner.movies);
		}
	}

	internal class FilterByGenre : IGenericExercise
	{
		string IGenericExercise.Name => "Ricerca per genere";
		private Es_Videoteca owner;
		private string sanitizedString;

		public FilterByGenre(Es_Videoteca owner)
		{
			this.owner = owner;
		}

		public void Execute()
		{
			foreach (string genre in Es_Videoteca.GetGenres(owner.movies))
			{
				Console.WriteLine(genre);
			}

			Console.WriteLine();
			Console.WriteLine("Seleziona una categoria");
			Program.SanitizeInput(out sanitizedString);
			Console.WriteLine();
			
			List<Movie> movies = new List<Movie>();
			foreach (Movie movie in owner.movies)
			{
				if (!movie.CompareGenre(sanitizedString)) continue;
				movies.Add(movie);
			}

			Es_Videoteca.PrintMovies(movies);
			
		}
	}
	
}
