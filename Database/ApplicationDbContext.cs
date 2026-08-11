using System.Dynamic;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using ProductService.Database;
using ProductService.Models;

namespace ProductService.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users {get; set;} = null!;
}