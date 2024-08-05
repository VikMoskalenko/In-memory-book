namespace In_memory_book
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookService service = new BookService();
            service.OnBookAdded += BookAdded;
        }
        private static void AddBook(BookService service)
        {
            var book = new Book();
            Console.WriteLine("Enter a book ID: ");
            book.Id = int.Parse(Console.ReadLine());
            if (book.Id == 0)
            {
                Console.WriteLine("It should be numbers");
            }
            Console.WriteLine("Enter book title: ");
            book.Title = Console.ReadLine();
            if (book.Title == null)
            {
                throw new Exception("The title should have name");

            }
            Console.WriteLine("Enter a year : ");
            book.Year = int.Parse(Console.ReadLine());
            if (book.Year == 0)
            {
                throw new Exception("Please enter a year");
            }
            service.AddBook(book);

        }

        private static void ViewBook(BookService service)
        {
            Console.WriteLine("Enter an ID to see book:");

        }

        private static void UpdateBook(BookService service)
        {

        }
        private static void DeleteBook(BookService service)
        {

        }
        public static void ListAll(BookService service)
        {

        }
        private static void BookAdded(Book book) => Console.WriteLine($"The book was added {book.Title}");
    }
}
