namespace MMS.Erp.Domain.Repositories;

using MMS.Erp.Domain.Entities;

public interface IInvoiceRepository : IGenericRepository<Invoice>
{
    Task<IEnumerable<Invoice>> GetForExample();
}
