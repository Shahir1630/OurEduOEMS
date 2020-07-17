using Microsoft.EntityFrameworkCore;
using OurEduOEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base (options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<Actors> ()
                .HasMany<Users> (u => u.Users)
                .WithOne (a => a.Actor);
        }

    }
}
