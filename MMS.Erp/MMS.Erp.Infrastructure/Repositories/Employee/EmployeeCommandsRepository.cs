namespace MMS.Erp.Infrastructure.Repositories.Employee;

using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.QueryModels.Employee;
using MMS.Erp.Domain.Repositories.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class EmployeeCommandsRepository : GenericCommandRepository<Employee>, IEmployeeCommandsRepository
{
    public EmployeeCommandsRepository(ErpDbContext context) : base(context)
    {

    }
}