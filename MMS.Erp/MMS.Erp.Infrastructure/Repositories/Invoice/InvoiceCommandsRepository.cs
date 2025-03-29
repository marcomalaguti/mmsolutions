using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories.Invoice;

namespace MMS.Erp.Infrastructure.Repositories.Invoice;

public sealed class InvoiceCommandsRepository : GenericCommandRepository<MMS.Erp.Domain.AggregateRoots.Invoice>, IInvoiceCommandsRepository
{

    public InvoiceCommandsRepository(ErpDbContext context) : base(context) { }

    public async Task<IEnumerable<MMS.Erp.Domain.AggregateRoots.Invoice>> GetForExample()
    {
        return await _dbSet.Where(p => true).ToListAsync();
    }
}
