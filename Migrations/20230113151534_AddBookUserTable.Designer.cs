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
    [Migration("20230113151534_AddBookUserTable")]
    partial class AddBookUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("BibliotekaMvc.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AutorImie")
                        .HasColumnType("TEXT");

                    b.Property<string>("AutorNazwisko")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookInfoId");

                    b.HasIndex("BookUserId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.BookInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gatunek")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BookInfo");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.BookUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookUser");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Imie")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

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

            modelBuilder.Entity("BibliotekaMvc.Models.Book", b =>
                {
                    b.HasOne("BibliotekaMvc.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.HasOne("BibliotekaMvc.Models.BookInfo", "BookInfo")
                        .WithMany("Books")
                        .HasForeignKey("BookInfoId");

                    b.HasOne("BibliotekaMvc.Models.BookUser", null)
                        .WithMany("Books")
                        .HasForeignKey("BookUserId");

                    b.Navigation("Author");

                    b.Navigation("BookInfo");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.BookUser", b =>
                {
                    b.HasOne("BibliotekaMvc.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotekaMvc.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.User", b =>
                {
                    b.HasOne("BibliotekaMvc.Models.Book", null)
                        .WithMany("User")
                        .HasForeignKey("BookId");
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

            modelBuilder.Entity("BibliotekaMvc.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.Book", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.BookInfo", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.BookUser", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BibliotekaMvc.Models.User", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
