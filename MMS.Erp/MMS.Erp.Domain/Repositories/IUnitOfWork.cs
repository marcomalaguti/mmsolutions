namespace MMS.Erp.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IInvoiceRepository Invoices { get; }
    ICustomerRepository Customers { get; }
    IEmployeeRepository Employees { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}