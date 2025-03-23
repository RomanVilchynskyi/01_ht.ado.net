using dbController.Entities;
using Microsoft.EntityFrameworkCore;

namespace dbController
{
    public class Controller:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source= DESKTOP-F5EBSVM\SQLEXPRESS;
                                Initial Catalog = LibraryApp;
                                Integrated Security=True;
                                Connect Timeout=2;
                                Encrypt=False;
                                Trust Server Certificate=False;
                                Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
        .Property(b => b.Genre)
        .HasDefaultValue("Unknown");

            modelBuilder.Entity<Book>()
        .Property(b => b.Publisher)
        .HasDefaultValue("Unknown Publisher");

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Sample Book", Author = "Sample Author", Publisher = "Sample Publisher", Pages = 300, Genre = "Fiction", Year = 2020, CostPrice = 10, SalePrice = 15, IsContinuation = false }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123" }
            );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }

}
