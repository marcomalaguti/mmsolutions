namespace MMS.Erp.Domain.Repositories;
public interface IUnitOfWork : IDisposable
{
    IInvoiceRepository Invoices { get; }
    ICustomerRepository Customers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}