namespace MMS.Erp.Domain.Repositories.Employee;

using MMS.Erp.Domain.QueryModels.Employee;

public interface IEmployeeQueriesRepository
{
    Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(CancellationToken cancellationToken);

    Task<IEnumerable<ExpenseReportModel>> GetExpenseReportsByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken);
    Task<IEnumerable<ExpenseRecordModel>> GetExpenseRecordsByReportIdAsync(int expenseReportId, CancellationToken cancellationToken);
}
