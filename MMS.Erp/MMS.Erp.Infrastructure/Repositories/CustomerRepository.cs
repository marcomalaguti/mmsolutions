using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;

namespace MMS.Erp.Infrastructure.Repositories;

public sealed class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{

    public CustomerRepository(ErpDbContext context) : base(context) { }

}
