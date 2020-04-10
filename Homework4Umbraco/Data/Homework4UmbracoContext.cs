using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassLibrary;

namespace Homework4Umbraco.Data
{
    public class Homework4UmbracoContext : DbContext
    {
        public Homework4UmbracoContext (DbContextOptions<Homework4UmbracoContext> options)
            : base(options)
        {
        }

        public DbSet<ClassLibrary.SerialNumber> SerialNumber { get; set; }

        public DbSet<ClassLibrary.Participant> Participant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SerialNumber>().ToTable("SerialNumber");
            modelBuilder.Entity<Participant>().ToTable("Participant");
           
        }
    }
}
