namespace MMS.Erp.Infrastructure.Repositories.ExpenseReport;

using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MMS.Erp.Domain.QueryModels.Employee;
using MMS.Erp.Domain.Repositories.ExpenseReport;
using System.Collections.Generic;
using System.Threading.Tasks;


internal class ExpenseReportQueriesRepository : GenericQueriesRepository, IExpenseReportQueriesRepository
{
    public ExpenseReportQueriesRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<IEnumerable<ExpenseReportModel>> GetAllAsync(CancellationToken cancellationToken)
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
            ";

            return await connection.QueryAsync<ExpenseReportModel>(query, cancellationToken);
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

    public async Task<ExpenseReportModel?> GetByIdAsync(int expenseReportId, CancellationToken cancellationToken)
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
              WHERE rp.[Id] = @expenseReportId
            ";

            var parameters = new { expenseReportId };

            return await connection.QueryFirstOrDefaultAsync<ExpenseReportModel>(query, parameters);
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