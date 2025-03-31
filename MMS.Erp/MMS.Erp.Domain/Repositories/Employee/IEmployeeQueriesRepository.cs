namespace MMS.Erp.Domain.Repositories.Employee;

using MMS.Erp.Domain.QueryModels.Employee;

public interface IEmployeeQueriesRepository
{
    Task<EmployeeModel?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(CancellationToken cancellationToken);
}
