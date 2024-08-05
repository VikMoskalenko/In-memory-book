using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_memory_book
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    public delegate void BookDelegate(Book book);
    public class BookService : IBook
    {
        private readonly List<Book> _books = new List<Book>();
        public event BookDelegate OnBookAdded;
        public void AddBook(Book book)
        {
            _books.Add(book);
            OnBookAdded?.Invoke(book);
        }

        public void DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        public Book GetBook(int id)
        {
            return _books.Find(x => x.Id == id);
        }


        public void UpdateBook(Book book)
        {
            var exisitingB = GetBook(book.Id);
            if (exisitingB != null)
            {
                exisitingB.Author = book.Author;
                exisitingB.Year = book.Year;
                exisitingB.Title = book.Title;
            }
        }

        public List<Book> GetAllBooks()
        {
            return new List<Book>(_books);
        }
    }
}
