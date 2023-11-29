﻿// <auto-generated />
using System;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(BookBorrowDbContext))]
    [Migration("20231123153026_AddedICollectionToUSER")]
    partial class AddedICollectionToUSER
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SharedLayer.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BorrowedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsBookAvailable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LentByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("BorrowedByUserId");

                    b.HasIndex("LentByUserId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("SharedLayer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BooksBorrowed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BooksLent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TokensAvailable")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Rohan",
                            Password = "user123",
                            TokensAvailable = 10,
                            Username = "user1"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Shubham",
                            Password = "user123",
                            TokensAvailable = 10,
                            Username = "user2"
                        },
                        new
                        {
                            UserId = 3,
                            Name = "Rahul",
                            Password = "user123",
                            TokensAvailable = 10,
                            Username = "user3"
                        },
                        new
                        {
                            UserId = 4,
                            Name = "Rishabh",
                            Password = "user123",
                            TokensAvailable = 10,
                            Username = "user4"
                        });
                });

            modelBuilder.Entity("SharedLayer.Models.Book", b =>
                {
                    b.HasOne("SharedLayer.Models.User", "BorrowedByUser")
                        .WithMany("BorrowedBooksList")
                        .HasForeignKey("BorrowedByUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SharedLayer.Models.User", "LentByUser")
                        .WithMany("LentBooksList")
                        .HasForeignKey("LentByUserId");

                    b.Navigation("BorrowedByUser");

                    b.Navigation("LentByUser");
                });

            modelBuilder.Entity("SharedLayer.Models.User", b =>
                {
                    b.Navigation("BorrowedBooksList");

                    b.Navigation("LentBooksList");
                });
#pragma warning restore 612, 618
        }
    }
}
