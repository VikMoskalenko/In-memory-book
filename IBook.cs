using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_memory_book
{
    public interface IBook
    {
        void AddBook(Book book);
        Book GetBook(int id);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        List<Book> GetAllBooks();  
    }
}
