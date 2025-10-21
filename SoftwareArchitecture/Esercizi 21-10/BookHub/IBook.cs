using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.BookHub
{
	public interface IBook
	{
		public string Title { get; }
		public string Author { get; }
		public int ID { get; }
	}

	// BookData by itself is only a data set, it describes the item in a vacuum
	// to buy a book, you have to wrap it in a decorator which defines whether it's a digital or physical copy
	public class BookData : IBook
	{
		private static int nextAvailableID = 1;
		public string Title { get; private set; }

		public string Author { get; private set; }
		public int ID { get; private set; }

		public BookData(string title, string author)
		{
			Title = title;
			Author = author;
			ID = nextAvailableID++;
		}
	}

	// Book abstract is the book the store can actually sell, with a price and everything
	// its component is BookData because we can't sell a physical-digital copy, so we can't allow nesting of decorators
	// even here, the book should NOT have a price - price is a separate component
	// it has to be stored as a book-price pair so that changing the price of one version of a book (digital vs physical, first print vs special edition etc) does not reflect on the entirity
	public abstract class Book : IBook
	{
		protected BookData bookData;

		public string Title => bookData.Title;
		public string Author => bookData.Author;
		public int ID => bookData.ID;

		public Book(BookData bookData)
		{
			this.bookData = bookData;
		}
	}

	public class DigitalBook : Book
	{
		public DigitalBook(BookData bookData) : base(bookData) { }
	}

	public class PhysicalBook : Book
	{
		public PhysicalBook(BookData bookData) : base(bookData) { }
	}

}
