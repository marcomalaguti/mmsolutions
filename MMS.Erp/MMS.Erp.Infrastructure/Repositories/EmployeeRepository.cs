namespace MMS.Erp.Infrastructure.Repositories;

using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;

internal class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{

    public EmployeeRepository(ErpDbContext context) : base(context) { }

}