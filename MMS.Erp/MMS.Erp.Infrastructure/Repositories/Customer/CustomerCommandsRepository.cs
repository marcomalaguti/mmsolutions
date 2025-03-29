using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories.Customer;

namespace MMS.Erp.Infrastructure.Repositories.Customer;

public sealed class CustomerCommandsRepository : GenericRepository<MMS.Erp.Domain.AggregateRoots.Customer>, ICustomerCommandsRepository
{

    public CustomerCommandsRepository(ErpDbContext context) : base(context) { }

}
