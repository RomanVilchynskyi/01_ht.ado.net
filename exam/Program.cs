using dbController;
using dbController.Entities;

internal class Program
{
    public class BookService
    {
        private Controller 
            _context;
        public BookService(Controller context)
        {
            _context = context;
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
    }

    public class SaleService
    {
        private Controller _context;
        public SaleService(Controller context)
        {
            _context = context;
        }
        public void SellBook(int bookId, float salePrice)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Sales.Add(new Sale { BookId = bookId, SaleDate = DateTime.Now, SalePrice = salePrice });
                _context.SaveChanges();
            }
        }
    }
    private static void Main(string[] args)
    {
        using var context = new Controller();

        var bookService = new BookService(context);
        var saleService = new SaleService(context);

        var book = new Book
        {
            Title = "Example Book",
            Author = "Example Author",
            Publisher = "Sample Publisher",
            Genre = "Fiction",
            Year = 2020,
            Pages = 250,
            CostPrice = 10,
            SalePrice = 15,
            IsContinuation = false
        };
        bookService.AddBook(book);

        saleService.SellBook(1, 20);

        var books = bookService.GetBooks();
        foreach (var b in books)
        {
            Console.WriteLine($"Book: {b.Title}, Author: {b.Author}, Publisher: {b.Publisher}");
        }
    }
}