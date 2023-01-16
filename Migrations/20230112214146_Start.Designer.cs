﻿// <auto-generated />
using System;
using BibliotekaMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotekaMvc.Migrations
{
    [DbContext(typeof(BibliotekaContext))]
    [Migration("20230112214146_Start")]
    partial class Start
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("BibliotekaMvc.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Imie")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Miasto")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NrDomu")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NrTelefonu")
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<string>("Ulica")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.UserAddress", b =>
                {
                    b.HasOne("BibliotekaMvc.Models.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("BibliotekaMvc.Models.UserAddress", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.User", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
