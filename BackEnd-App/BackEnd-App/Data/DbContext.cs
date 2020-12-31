using BackEnd_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_App.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> UserInformation { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<FlightLevel> FlightLevel { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FlightLevel>().HasData(
                new FlightLevel() { Id = "1", Name = "Business" },
                new FlightLevel() { Id = "2", Name = "Economy" },
                new FlightLevel() { Id = "3", Name = "VIP" }
                );

            modelBuilder.Entity<PaymentMethod>().HasData
                (
                    new PaymentMethod() { Id = "1", Name = "Credit Card" },
                    new PaymentMethod() { Id = "2", Name = "Pay Cash" }
                );
        }

    }
}
