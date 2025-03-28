namespace MMS.Erp.Domain.Repositories;

using MMS.Erp.Domain.AggregateRoots;

public interface IInvoiceRepository : IGenericRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetForExample();
}
