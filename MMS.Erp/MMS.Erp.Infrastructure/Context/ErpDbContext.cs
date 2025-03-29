
using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Entities;

namespace MMS.Erp.Infrastructure;

public sealed class ErpDbContext : DbContext
{
    public ErpDbContext(DbContextOptions<ErpDbContext> options) : base(options)
    {
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ExpenseReport> ExpenseReports { get; set; }
    public DbSet<ExpenseRecord> ExpenseRecords { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ExpenseReport>()
            .HasMany(r => r.ExpenseRecords)
            .WithOne(e => e.ExpenseReport)
            .HasForeignKey(e => e.ExpenseReportId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ExpenseReport>()
            .HasOne(r => r.Employee)
            .WithMany(e => e.ExpenseReports)
            .HasForeignKey(r => r.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ExpenseRecord>()
            .HasOne(er => er.ExpenseReport)
            .WithMany(er => er.ExpenseRecords)
            .HasForeignKey(er => er.ExpenseReportId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.ExpenseReports)
            .WithOne(er => er.Employee)
            .HasForeignKey(er => er.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErpDbContext).Assembly);
    }
}