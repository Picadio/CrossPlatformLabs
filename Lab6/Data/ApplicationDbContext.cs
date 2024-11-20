using Lab6.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<RefContactType> RefContactTypes { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne<Author>()
            .WithOne()
            .HasForeignKey<Book>(b => b.AuthorId);
        modelBuilder.Entity<Book>()
            .HasOne<BookCategory>()
            .WithOne()
            .HasForeignKey<Book>(b => b.BookCategoryCode);
        modelBuilder.Entity<Contact>()
            .HasOne<RefContactType>()
            .WithOne()
            .HasForeignKey<Contact>(b => b.ContactTypeCode);
        modelBuilder.Entity<OrderItem>()
            .HasOne<Order>()
            .WithOne()
            .HasForeignKey<OrderItem>(b => b.OrderId);
        modelBuilder.Entity<OrderItem>()
            .HasOne<Book>()
            .WithOne()
            .HasForeignKey<OrderItem>(b => b.BookId);
        modelBuilder.Entity<Order>()
            .HasOne<Customer>()
            .WithOne()
            .HasForeignKey<Order>(b => b.CustomerId);

        modelBuilder.Entity<Book>().Property(e => e.BookId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Author>().Property(e => e.AuthorId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Customer>().Property(e => e.CustomerId).ValueGeneratedOnAdd();
        modelBuilder.Entity<Order>().Property(e => e.OrderId).ValueGeneratedOnAdd();
        modelBuilder.Entity<OrderItem>().Property(e => e.ItemNumber).ValueGeneratedOnAdd();
        modelBuilder.Entity<Contact>().Property(e => e.ContactId).ValueGeneratedOnAdd();
        modelBuilder.Entity<RefContactType>().Property(e => e.ContactTypeCode).ValueGeneratedOnAdd();
        modelBuilder.Entity<BookCategory>().Property(e => e.BookCategoryCode).ValueGeneratedOnAdd();
    }

    public void Seed()
    {
        var author = new Author()
        {
            AuthorInitials = "AB",
            AuthorFirstName = "Alex",
            AuthorLastName = "Baryl",
            AuthorContactDetails = "test",
            AuthorOtherDetails = "test",
            AuthorGenderMFU = "M",
            AuthorDateOfBirth = new DateOnly(2003, 2, 2)
        };
        this.Authors.Add(author);
        this.SaveChanges();
    }
}