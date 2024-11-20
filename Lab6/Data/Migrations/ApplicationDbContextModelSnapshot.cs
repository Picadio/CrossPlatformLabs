﻿// <auto-generated />
using System;
using Lab6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab6.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Lab6.Data.Entities.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorContactDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("AuthorDateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorGenderMFU")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorInitials")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorOtherDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Lab6.Data.Entities.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId1")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookCategoryCode")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookCategoryCode1")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookComments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("BookRecommendedPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateAcquired")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfPublication")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.HasIndex("AuthorId1");

                    b.HasIndex("BookCategoryCode")
                        .IsUnique();

                    b.HasIndex("BookCategoryCode1");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Lab6.Data.Entities.BookCategory", b =>
                {
                    b.Property<Guid>("BookCategoryCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookCategoryDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookCategoryCode");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("Lab6.Data.Entities.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactCellPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactOtherDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ContactTypeCode")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ContactTypeCode1")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactWorkPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.HasIndex("ContactTypeCode")
                        .IsUnique();

                    b.HasIndex("ContactTypeCode1");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Lab6.Data.Entities.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab6.Data.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId1")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("CustomerId1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Lab6.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("ItemNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookId1")
                        .HasColumnType("TEXT");

                    b.Property<double>("ItemAgreedPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("ItemComment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId1")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemNumber");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("BookId1");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("OrderId1");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Lab6.Data.Entities.RefContactType", b =>
                {
                    b.Property<Guid>("ContactTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactTypeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ContactTypeCode");

                    b.ToTable("RefContactTypes");
                });

            modelBuilder.Entity("Lab6.Data.Entities.Book", b =>
                {
                    b.HasOne("Lab6.Data.Entities.Author", null)
                        .WithOne()
                        .HasForeignKey("Lab6.Data.Entities.Book", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Entities.BookCategory", null)
                        .WithOne()
                        .HasForeignKey("Lab6.Data.Entities.Book", "BookCategoryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Entities.BookCategory", "BookCategory")
                        .WithMany()
                        .HasForeignKey("BookCategoryCode1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("Lab6.Data.Entities.Contact", b =>
                {
                    b.HasOne("Lab6.Data.Entities.RefContactType", null)
                        .WithOne()
                        .HasForeignKey("Lab6.Data.Entities.Contact", "ContactTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Entities.RefContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeCode1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactType");
                });

            modelBuilder.Entity("Lab6.Data.Entities.Order", b =>
                {
                    b.HasOne("Lab6.Data.Entities.Customer", null)
                        .WithOne()
                        .HasForeignKey("Lab6.Data.Entities.Order", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Lab6.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("Lab6.Data.Entities.Book", null)
                        .WithOne()
                        .HasForeignKey("Lab6.Data.Entities.OrderItem", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Entities.Order", null)
                        .WithOne()
                        .HasForeignKey("Lab6.Data.Entities.OrderItem", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Data.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
