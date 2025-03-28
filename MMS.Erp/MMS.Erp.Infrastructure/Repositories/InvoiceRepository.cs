using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;

namespace MMS.Erp.Infrastructure.Repositories;

public sealed class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{

    public InvoiceRepository(ErpDbContext context) : base(context) { }

    public async Task<IEnumerable<Invoice>> GetForExample()
    {
        return await _dbSet.Where(p => true).ToListAsync();
    }
}
