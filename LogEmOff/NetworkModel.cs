using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogEmOff
{
    class NetworkModel : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Computer> Computers { get; set; }

        public virtual DbSet<Login> Logins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyLogEmOffDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID)
                .HasName("PK_Account");

                entity.Property(e => e.UserID)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);

                entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

                entity.HasMany(e => e.Logins);

                entity.ToTable("Users");

            });

            modelBuilder.Entity<Computer>(entity =>
            {
                entity.HasKey(e => e.ComputerID)
                .HasName("PK_Computer");

                entity.Property(e => e.ComputerID)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.ComputerName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.ComputerIP)
                .IsRequired();

                entity.HasMany(e => e.Logins);

                entity.ToTable("Computers");

            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LoginID)
                .HasName("PK_Login");

                entity.Property(e => e.LoginID)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.LoginName)
                .IsRequired()
                .HasMaxLength(24);             

                entity.HasOne(e => e.User);

                entity.HasOne(e => e.Computer);

                entity.ToTable("Logins");
            });

        }




    }
}
