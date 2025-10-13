using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_13_10_Design_Pattern.Es_Singleton.Log_History
{
	public class BookStoreManager
	{
		private static BookStoreManager instance;
		public static BookStoreManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new BookStoreManager();
				}
				return instance;
			}
		}

		private BookStoreManager() { }

		private List<Book> books = new List<Book>()
		{
			new Book("Misery", "Stephen King"),
			new Book("IT", "Stephen King"),
			new Book("Cacciatori di Nuvole", "Alex Shearer")
		};

		public void PrintBooksByAuthor(string author)
		{
			author = author.ToLower();
			author = author.Trim();

			foreach (Book book in books)
			{
				if(book.Author.ToLower() == author)
				{
					Console.WriteLine(book.ToString());
				}
			}
		}
	}


	public class Book
	{
		private string name;
		private string author;

		public string Author => author;
		public string Name => name;

		public Book(string name, string author)
		{
			this.name = name.Trim();
			this.author = author.Trim();
		}

		public override string ToString()
		{
			return $"Titolo: {name} - Author: {author}";
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(name, author);
		}
	}
}
