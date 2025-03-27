
using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.Entities;

namespace MMS.Erp.Infrastructure;

public sealed class ErpDbContext : DbContext
{
    public ErpDbContext(DbContextOptions<ErpDbContext> options) : base(options)
    {
    }

    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErpDbContext).Assembly);
    }
}