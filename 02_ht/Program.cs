using _02_ht;

internal class Program
{
    private static void Main(string[] args)
    {
        Librarydb library = new Librarydb();

        library.AddBook("New Book");

        int userCount = library.GetRegisteredUsersCount();
        Console.WriteLine($"Registered Users: {userCount}");

        library.GetDebtors();

        library.GetAuthorsByBook("The Lord of the Rings");

        library.GetAvailableBooks();

        library.GetBooksByUser(1);

        library.ClearAllDebts();

        library.UpdateBookTitle(1, "Updated Book Title");

        library.UpdateUserDebtorStatus(2, false);

        library.CloseConnection();
    }
}