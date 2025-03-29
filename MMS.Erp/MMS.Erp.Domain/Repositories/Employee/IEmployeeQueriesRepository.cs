namespace MMS.Erp.Domain.Repositories.Employee;

using MMS.Erp.Domain.QueryModels.Employee;

public interface IEmployeeQueriesRepository
{
    Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(CancellationToken cancellationToken);
}
