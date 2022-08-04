using InvoiceMgmt.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceMgmt.Infrastructure.Data.InMemoryDB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Invoice> Invoices { get; set; }
}

