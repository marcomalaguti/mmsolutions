
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
    public DbSet<PayCheck> PayChecks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Invoice

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        //Expense Report

        modelBuilder.Entity<ExpenseReport>()
           .HasMany(er => er.ExpenseRecords)
           .WithOne(er => er.ExpenseReport)
           .HasForeignKey(er => er.ExpenseReportId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ExpenseReport>()
            .HasOne<Employee>()
            .WithMany(e => e.ExpenseReports)
            .HasForeignKey(er => er.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        //Employee

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.ExpenseReports)
            .WithOne()
            .HasForeignKey(er => er.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .Property(e => e.FirstName)
            .HasMaxLength(100);

        modelBuilder.Entity<Employee>()
            .Property(e => e.LastName)
            .HasMaxLength(100);

        modelBuilder.Entity<Employee>()
            .Property(e => e.FiscalCode)
            .HasMaxLength(16);
        
        modelBuilder.Entity<ExpenseRecord>()
            .HasOne(er => er.ExpenseReport)
            .WithMany(er => er.ExpenseRecords)
            .HasForeignKey(er => er.ExpenseReportId)
            .OnDelete(DeleteBehavior.Cascade);

        //PayChecks

        modelBuilder.Entity<PayCheck>()
           .HasOne<Employee>()
           .WithMany(e => e.PayChecks)
           .HasForeignKey(p => p.EmployeeId)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErpDbContext).Assembly);
    }
}