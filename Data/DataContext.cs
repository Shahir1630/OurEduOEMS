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
        public DbSet<AssignedClasses> AssignedClasses { get; set; }
        public DbSet<AssignedSubjects> AssignedSubjects { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<Actors> ()
                .HasMany<Users> (u => u.Users)
                .WithOne (a => a.Actor);
            
            modelBuilder.Entity<Classes> ()
                .HasMany<AssignedClasses> (u => u.AssignedClasses)
                .WithOne (a => a.Classes);
            
            modelBuilder.Entity<Classes> ()
                .HasMany<Subjects> (u => u.Subjects)
                .WithOne (a => a.Classes);


            modelBuilder.Entity<Subjects> ()
                .HasMany<AssignedSubjects> (u => u.AssignedSubjects)
                .WithOne (a => a.Subjects).IsRequired ().OnDelete (DeleteBehavior.Restrict); ;

            modelBuilder.Entity<AssignedClasses> ()
                .HasMany<AssignedSubjects> (u => u.AssignedSubjects)
                .WithOne (a => a.AssignedClasses);
        }

    }
}
