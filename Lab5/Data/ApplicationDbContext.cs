using Lab5.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }

public DbSet<Lab5.Models.Customer> Customer { get; set; } = default!;
}