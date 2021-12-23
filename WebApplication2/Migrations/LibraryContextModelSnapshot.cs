﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Models;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("authorsId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "authorsId");

                    b.HasIndex("authorsId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("WebApplication2.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WebApplication2.Models.AuthorDetails", b =>
                {
                    b.Property<int>("fileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.HasKey("fileId");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("AuthorContact");
                });

            modelBuilder.Entity("WebApplication2.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("WebApplication2.Models.BookDetails", b =>
                {
                    b.Property<int>("fileId")
                        .HasColumnType("int");

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.Property<string>("price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("publisherID")
                        .HasColumnType("int");

                    b.HasKey("fileId");

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("WebApplication2.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WebApplication2.Models.Publisher", b =>
                {
                    b.Property<int>("publisherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("bookId")
                        .HasColumnType("int");

                    b.HasKey("publisherID");

                    b.HasIndex("bookId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("WebApplication2.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("authorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication2.Models.AuthorDetails", b =>
                {
                    b.HasOne("WebApplication2.Models.Author", null)
                        .WithOne("AuthorContact")
                        .HasForeignKey("WebApplication2.Models.AuthorDetails", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication2.Models.Publisher", b =>
                {
                    b.HasOne("WebApplication2.Models.Book", "book")
                        .WithMany("publisher")
                        .HasForeignKey("bookId");

                    b.Navigation("book");
                });

            modelBuilder.Entity("WebApplication2.Models.Author", b =>
                {
                    b.Navigation("AuthorContact");
                });

            modelBuilder.Entity("WebApplication2.Models.Book", b =>
                {
                    b.Navigation("publisher");
                });
#pragma warning restore 612, 618
        }
    }
}
