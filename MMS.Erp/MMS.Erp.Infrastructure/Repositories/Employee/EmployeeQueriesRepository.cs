namespace MMS.Erp.Infrastructure.Repositories.Employee;

using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MMS.Erp.Domain.QueryModels.Employee;
using MMS.Erp.Domain.Repositories.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class EmployeeQueriesRepository : GenericQueriesRepository, IEmployeeQueriesRepository
{
    public EmployeeQueriesRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(CancellationToken cancellationToken)
    {
        using (var connection = new SqlConnection(ErpConnectionString))
        {
            await connection.OpenAsync(cancellationToken);

            var query = @"
                SELECT [Id], [FirstName], [LastName], [FiscalCode]
                FROM [ERP].[dbo].[Employees]
            ";

            return await connection.QueryAsync<EmployeeModel>(query, cancellationToken);
        }
    }

    public async Task<IEnumerable<ExpenseRecordModel>> GetExpenseRecordsByReportIdAsync(int expenseReportId,
                                                                                        CancellationToken cancellationToken)
    {
        using (var connection = new SqlConnection(ErpConnectionString))
        {
            await connection.OpenAsync(cancellationToken);

            var query = @"
              SELECT [Id]
                  ,[TypeId]
                  ,[Description]
                  ,[TraveledKm]
                  ,[KmReimbursement]
                  ,[Tolls]
                  ,[Meals]
                  ,[Accommodation]
                  ,[LumpSum]
                  ,[PathToAttachment]
                  ,[Date]
                  ,[ExpenseReportId]
              FROM [ERP].[dbo].[ExpenseRecords]
              WHERE [ExpenseReportId] = @expenseReportId
            ";

            var parameters = new { expenseReportId };

            return await connection.QueryAsync<ExpenseRecordModel>(query, parameters);
        }
    }

    public async Task<IEnumerable<ExpenseReportModel>> GetExpenseReportsByEmployeeIdAsync(int employeeId,
                                                                                          CancellationToken cancellationToken)
    {
        using (var connection = new SqlConnection(ErpConnectionString))
        {
            await connection.OpenAsync(cancellationToken);

            var query = @"
              SELECT rp.[Id] as Id
                    ,rp.[StateId] as StateId
                    ,rp.[Date] as Date
                    ,rp.[EmployeeId] as EmployeeId
              FROM [ERP].[dbo].[ExpenseReports] rp
              WHERE rp.[EmployeeId] = @employeeId
            ";

            var parameters = new { employeeId };

            return await connection.QueryAsync<ExpenseReportModel>(query, parameters);
        }
    }
}
