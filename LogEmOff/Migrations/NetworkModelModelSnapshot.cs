﻿// <auto-generated />
using System;
using LogEmOff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogEmOff.Migrations
{
    [DbContext(typeof(NetworkModel))]
    partial class NetworkModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogEmOff.Computer", b =>
                {
                    b.Property<int>("ComputerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminLogin");

                    b.Property<string>("AdminPassword");

                    b.Property<string>("ComputerIP")
                        .IsRequired();

                    b.Property<string>("ComputerMAC")
                        .HasMaxLength(16);

                    b.Property<string>("ComputerName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("GreenImage");

                    b.Property<bool>("Online");

                    b.Property<byte[]>("RedImage");

                    b.HasKey("ComputerID")
                        .HasName("PK_Computer");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("LogEmOff.Login", b =>
                {
                    b.Property<int>("LoginID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputerID");

                    b.Property<bool>("Enabled");

                    b.Property<byte[]>("GreenImage");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(24);

                    b.Property<byte[]>("RedImage");

                    b.Property<int>("UserID");

                    b.HasKey("LoginID")
                        .HasName("PK_Login");

                    b.HasIndex("ComputerID");

                    b.HasIndex("UserID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("LogEmOff.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("UserID")
                        .HasName("PK_Account");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LogEmOff.Login", b =>
                {
                    b.HasOne("LogEmOff.Computer", "Computer")
                        .WithMany("Logins")
                        .HasForeignKey("ComputerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LogEmOff.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
