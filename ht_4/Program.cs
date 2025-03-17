using ht_4.Entities;
using ht_4;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = new AviationContext();

        var airplane1 = new Airplane
        {
            Model = "Boeing 737",
            Type = "Commercial",
            MaxPassengers = 180,
            Country = "USA"
        };

        var airplane2 = new Airplane
        {
            Model = "Airbus A320",
            Type = "Commercial",
            MaxPassengers = 190,
            Country = "France"
        };

        var client1 = new Client
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Gender = "Male"
        };

        var client2 = new Client
        {
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            Gender = "Female"
        };

        var account1 = new Account
        {
            Login = "johndoe",
            Password = "password123"
        };

        var account2 = new Account
        {
            Login = "janesmith",
            Password = "password456"
        };

        client1.Account = account1;
        client2.Account = account2;

        var flight1 = new Flight
        {
            Number = "AB123",
            Airplane = airplane1,
            DepartureTime = new DateTime(2025, 5, 1, 10, 0, 0),
            ArrivalTime = new DateTime(2025, 5, 1, 12, 0, 0),
            DepartureLocation = "New York",
            ArrivalLocation = "Los Angeles"
        };

        var flight2 = new Flight
        {
            Number = "CD456",
            Airplane = airplane2,
            DepartureTime = new DateTime(2025, 5, 2, 15, 0, 0),
            ArrivalTime = new DateTime(2025, 5, 2, 17, 0, 0),
            DepartureLocation = "Paris",
            ArrivalLocation = "London"
        };

        flight1.Clients.Add(client1);
        flight2.Clients.Add(client2);

        context.Airplanes.Add(airplane1);
        context.Airplanes.Add(airplane2);
        context.Clients.Add(client1);
        context.Clients.Add(client2);
        context.Accounts.Add(account1);
        context.Accounts.Add(account2);
        context.Flights.Add(flight1);
        context.Flights.Add(flight2);

        context.SaveChanges();
    }
}