namespace MMS.Erp.Domain.Repositories.Invoice;

using MMS.Erp.Domain.AggregateRoots;

public interface IInvoiceCommandsRepository : IGenericRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetForExample();
}
