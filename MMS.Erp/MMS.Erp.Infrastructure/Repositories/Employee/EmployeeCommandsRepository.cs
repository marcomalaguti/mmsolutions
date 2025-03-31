namespace MMS.Erp.Infrastructure.Repositories.Employee;

using Microsoft.EntityFrameworkCore;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading.Tasks;

internal class EmployeeCommandsRepository : GenericCommandRepository<Employee>, IEmployeeCommandsRepository
{
    public EmployeeCommandsRepository(ErpDbContext context) : base(context)
    {

    }

    public override async Task<Employee?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(x => x.ExpenseReports)
            .ThenInclude(x => x.ExpenseRecords)
            .FirstOrDefaultAsync(x => x.Id == id);   
    }
}