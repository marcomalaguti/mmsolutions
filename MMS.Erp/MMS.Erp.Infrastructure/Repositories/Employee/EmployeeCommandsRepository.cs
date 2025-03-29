namespace MMS.Erp.Infrastructure.Repositories.Employee;

using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.QueryModels.Employee;
using MMS.Erp.Domain.Repositories.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class EmployeeCommandsRepository : GenericRepository<Employee>, IEmployeeCommandsRepository
{
    public EmployeeCommandsRepository(ErpDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(CancellationToken cancellationToken)
    {
        var ret = await _context.Employees.FromSqlRaw(@"
                    SELECT [Id]
                        ,[FirstName]
                        ,[LastName]
                        ,[FiscalCode]
                    FROM [ERP].[dbo].[Employees]
                    ").Select(x => new EmployeeModel(x.FirstName, x.LastName, x.FiscalCode))
                    .ToListAsync(cancellationToken);

        return ret;
    }
}