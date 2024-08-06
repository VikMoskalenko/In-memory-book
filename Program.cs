using System.Security.Cryptography.X509Certificates;

namespace In_memory_book
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookService service = new BookService();
            service.OnBookAdded += BookAdded;

            while (true)
            {
                Console.WriteLine("Welcome to Book Managment Service");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. View book");
                Console.WriteLine("3. Update book");
                Console.WriteLine("4. Delete book");
                Console.WriteLine("5. List all books");
                Console.WriteLine("6. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBook(service);
                        break;
                    case "2":
                        ViewBook(service);
                        break;
                    case "3":
                        UpdateBook(service);
                        break;
                    case "4":
                        DeleteBook(service);
                        break;
                    case "5":
                        ListAll(service);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("invalid option");
                        break;
                }

            }
        }
            private static void AddBook(BookService service)
            {
                var book = new Book();
            while (true)
            {
                Console.WriteLine("Enter a book ID: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int id) && id > 0)
                {
                    book.Id = id;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. The book ID should be a positive number.");
                }
            }

            // Validate and get book title
            while (true)
            {
                Console.WriteLine("Enter book title: ");
                book.Title = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(book.Title))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. The book title cannot be empty.");
                }
            }

            // Validate and get book year
            while (true)
            {
                Console.WriteLine("Enter a year: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int year) && year > 0)
                {
                    book.Year = year;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid year.");
                }
            }

            // Validate and get book author
            while (true)
            {
                Console.WriteLine("Enter the author: ");
                book.Author = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(book.Author))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. The author cannot be empty.");
                }
            }

            Console.WriteLine("Book added successfully!");
            service.AddBook(book);

            }

            private static void ViewBook(BookService service)
            {
                Console.WriteLine("Enter an ID to see book:");
                int id = int.Parse(Console.ReadLine());
                var book = service.GetBook(id);
                if (book != null)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                }
                else
                {
                    Console.WriteLine("The book is not found");
                }

            }

            private static void UpdateBook(BookService service)
            {
                var book = new Book();
                Console.WriteLine("Enter ID to update");
                book.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new title:");
                book.Title = Console.ReadLine();
                Console.WriteLine("Enter author: ");
                book.Author = Console.ReadLine();
                Console.WriteLine("Enter a year: ");
                book.Year = int.Parse(Console.ReadLine());
                service.UpdateBook(book);
            }
            private static void DeleteBook(BookService service)
            {
                Console.WriteLine("Enter ID book to delete: ");
                int id = int.Parse(Console.ReadLine());
                service.DeleteBook(id);
            }
             private static void ListAll(BookService service)
            {
                var books = service.GetAllBooks();
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                }
            }
            private static void BookAdded(Book book) => Console.WriteLine($"The book was added {book.Title}");
        }
    }

