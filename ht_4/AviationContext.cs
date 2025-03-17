using ht_4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_4
{
    public class AviationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source= DESKTOP-F5EBSVM\SQLEXPRESS;
                                Initial Catalog = Aviation;
                                Integrated Security=True;
                                Connect Timeout=2;
                                Encrypt=False;
                                Trust Server Certificate=False;
                                Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Client)
                .WithOne(c => c.Account)
                .HasForeignKey<Client>(c => c.AccountId);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirplaneId);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(c => c.Flights)
                .UsingEntity(j => j.ToTable("FlightClients"));
        }
    }
}
