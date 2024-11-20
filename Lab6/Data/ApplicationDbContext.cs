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
        if(Authors.Any()) return;
        var authors = new[]
        {
            new Author
            {
                AuthorId = Guid.NewGuid(),
                AuthorFirstName = "John",
                AuthorInitials = "J.D.",
                AuthorLastName = "Doe",
                AuthorDateOfBirth = new DateOnly(1980, 5, 15),
                AuthorGenderMFU = "M",
                AuthorContactDetails = "johndoe@example.com",
                AuthorOtherDetails = "Famous for modern thrillers"
            },
            new Author
            {
                AuthorId = Guid.NewGuid(),
                AuthorFirstName = "Jane",
                AuthorInitials = "J.S.",
                AuthorLastName = "Smith",
                AuthorDateOfBirth = new DateOnly(1975, 11, 20),
                AuthorGenderMFU = "F",
                AuthorContactDetails = "janesmith@example.com",
                AuthorOtherDetails = "Award-winning science fiction writer"
            },
            new Author
            {
                AuthorId = Guid.NewGuid(),
                AuthorFirstName = "Robert",
                AuthorInitials = "R.J.",
                AuthorLastName = "Johnson",
                AuthorDateOfBirth = new DateOnly(1990, 3, 10),
                AuthorGenderMFU = "M",
                AuthorContactDetails = "robertjohnson@example.com",
                AuthorOtherDetails = "Known for historical novels"
            },
            new Author
            {
                AuthorId = Guid.NewGuid(),
                AuthorFirstName = "Emily",
                AuthorInitials = "E.D.",
                AuthorLastName = "Davis",
                AuthorDateOfBirth = new DateOnly(1985, 7, 25),
                AuthorGenderMFU = "F",
                AuthorContactDetails = "emilydavis@example.com",
                AuthorOtherDetails = "Focuses on poetry and essays"
            },
            new Author
            {
                AuthorId = Guid.NewGuid(),
                AuthorFirstName = "Alex",
                AuthorInitials = "A.T.",
                AuthorLastName = "Taylor",
                AuthorDateOfBirth = new DateOnly(2000, 9, 30),
                AuthorGenderMFU = "U",
                AuthorContactDetails = "alextaylor@example.com",
                AuthorOtherDetails = "Emerging writer in the fantasy genre"
            }
        };
        Authors.AddRange(authors);
        
        var categories = new[]
        {
            new BookCategory
            {
                BookCategoryCode = Guid.NewGuid(),
                BookCategoryDescription = "Science Fiction: Books exploring futuristic or imaginative themes"
            },
            new BookCategory
            {
                BookCategoryCode = Guid.NewGuid(),   
                BookCategoryDescription = "Mystery: Stories revolving around solving a crime or unraveling secrets"
            },
            new BookCategory
            {
                BookCategoryCode = Guid.NewGuid(),
                BookCategoryDescription = "Fantasy: Tales of magic, mythical creatures, and otherworldly adventures"
            },
            new BookCategory
            {
                BookCategoryCode = Guid.NewGuid(),
                BookCategoryDescription = "Non-Fiction: Informative works based on real-world subjects and facts"
            },
            new BookCategory
            {
                BookCategoryCode = Guid.NewGuid(),
                BookCategoryDescription = "Romance: Narratives focused on love, relationships, and emotional connections"
            }
        };
        this.BookCategories.AddRange(categories);
        var books = new[]
        {
            new Book
            {
                AuthorId = authors[0].AuthorId,
                BookCategoryCode = categories[0].BookCategoryCode,
                ISBN = "978-1-56619-909-4",
                DateOfPublication = new DateTime(1813, 1, 28),
                DateAcquired = new DateOnly(2023, 11, 20),
                BookTitle = "Pride and Prejudice",
                BookRecommendedPrice = 15.99,
                BookComments = "A timeless romance novel.",
                Author = authors[0],
                BookCategory = categories[0]
            },
            new Book
            {
                AuthorId = authors[1].AuthorId,
                BookCategoryCode = categories[1].BookCategoryCode,
                ISBN = "978-0-452-28423-4",
                DateOfPublication = new DateTime(1949, 6, 8),
                DateAcquired = new DateOnly(2023, 12, 1),
                BookTitle = "1984",
                BookRecommendedPrice = 12.99,
                BookComments = "A chilling dystopian tale.",
                Author = authors[1],
                BookCategory = categories[1]
            },
            new Book
            {
                AuthorId = authors[2].AuthorId,
                BookCategoryCode = categories[2].BookCategoryCode,
                ISBN = "978-0-7475-3269-9",
                DateOfPublication = new DateTime(1997, 6, 26),
                DateAcquired = new DateOnly(2023, 12, 15),
                BookTitle = "Harry Potter and the Philosopher's Stone",
                BookRecommendedPrice = 20.99,
                BookComments = "The start of a magical adventure.",
                Author = authors[2],
                BookCategory = categories[2]
            },
            new Book
            {
                AuthorId = authors[3].AuthorId,
                BookCategoryCode = categories[3].BookCategoryCode,
                ISBN = "978-0-553-21311-7",
                DateOfPublication = new DateTime(1884, 12, 10),
                DateAcquired = new DateOnly(2023, 12, 20),
                BookTitle = "Adventures of Huckleberry Finn",
                BookRecommendedPrice = 10.99,
                BookComments = "A satirical journey down the Mississippi River.",
                Author = authors[3],
                BookCategory = categories[3]
            },
            new Book
            {
                AuthorId = authors[4].AuthorId,
                BookCategoryCode = categories[4].BookCategoryCode,
                ISBN = "978-0-679-60004-8",
                DateOfPublication = new DateTime(1869, 1, 1),
                DateAcquired = new DateOnly(2023, 11, 30),
                BookTitle = "War and Peace",
                BookRecommendedPrice = 25.99,
                BookComments = "An epic tale of Russian society.",
                Author = authors[4],
                BookCategory = categories[4]
            }
        };
        Books.AddRange(books);
        
        var customers = new[]
        {
            new Customer
            {
                CustomerCode = "CUST001",
                CustomerName = "John Doe",
                CustomerAddress = "123 Main St, Springfield",
                CustomerPhone = "+1-555-1234",
                CustomerEmail = "john.doe@example.com"
            },
            new Customer
            {
                CustomerCode = "CUST002",
                CustomerName = "Jane Smith",
                CustomerAddress = "456 Elm St, Shelbyville",
                CustomerPhone = "+1-555-5678",
                CustomerEmail = "jane.smith@example.com"
            },
            new Customer
            {
                CustomerCode = "CUST003",
                CustomerName = "Robert Johnson",
                CustomerAddress = "789 Oak St, Capital City",
                CustomerPhone = "+1-555-9012",
                CustomerEmail = "robert.johnson@example.com"
            },
            new Customer
            {
                CustomerCode = "CUST004",
                CustomerName = "Emily Davis",
                CustomerAddress = "321 Maple St, Ogdenville",
                CustomerPhone = "+1-555-3456",
                CustomerEmail = "emily.davis@example.com"
            },
            new Customer
            {
                CustomerCode = "CUST005",
                CustomerName = "Michael Brown",
                CustomerAddress = "654 Pine St, North Haverbrook",
                CustomerPhone = "+1-555-7890",
                CustomerEmail = "michael.brown@example.com"
            }
        };
        Customers.AddRange(customers);
        
        
        this.SaveChanges();
    }
}