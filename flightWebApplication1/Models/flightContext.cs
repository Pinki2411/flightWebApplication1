using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace flightWebApplication1.Models
{
    public class flightContext : DbContext
    {
        public DbSet<Flight> dbsetflight { get; set; }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<CheckIn> checkIns { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Booking>().HasOptional(e => e.CheckIn)
                .WithRequired(a => a.Booking).Map(m => m.MapKey("Book_id"));
        
         
            
        }
    }
}
