namespace MMS.Erp.Domain.Repositories.ExpenseReport;

using MMS.Erp.Domain.QueryModels.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;


public interface IExpenseReportQueriesRepository
{
    Task<IEnumerable<ExpenseReportModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<IEnumerable<ExpenseReportModel>> GetExpenseReportsByEmployeeIdAsync(int employeeId, CancellationToken cancellationToken);
    Task<IEnumerable<ExpenseRecordModel>> GetExpenseRecordsByReportIdAsync(int expenseReportId, CancellationToken cancellationToken);
    Task<ExpenseReportModel?> GetByIdAsync(int expenseReportId, CancellationToken cancellationToken);
}