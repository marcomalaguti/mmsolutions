namespace MMS.Erp.Domain.Repositories;
public interface IUnitOfWork : IDisposable
{
    IInvoiceRepository Invoices { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
