using Hotel_Management.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management
{
    public class Databasecontext:DbContext
    {
        public Databasecontext(DbContextOptions<Databasecontext>options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<ImageModel> Images { get; set; }





    }
}
