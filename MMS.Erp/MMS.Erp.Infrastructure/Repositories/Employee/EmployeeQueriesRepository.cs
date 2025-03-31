namespace MMS.Erp.Infrastructure.Repositories.Employee;

using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MMS.Erp.Domain.QueryModels.Employee;
using MMS.Erp.Domain.Repositories.Employee;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

internal class EmployeeQueriesRepository : GenericQueriesRepository, IEmployeeQueriesRepository
{
    public EmployeeQueriesRepository(IConfiguration configuration) : base(configuration) { }

    public async Task<EmployeeModel?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        using (var connection = new SqlConnection(ErpConnectionString))
        {
            await connection.OpenAsync(cancellationToken);

            var query = @"
                SELECT [Id], [FirstName], [LastName], [FiscalCode]
                FROM [ERP].[dbo].[Employees]
                WHERE [Id] = @id
            ";

            var parameters = new { id };

            return await connection.QueryFirstOrDefaultAsync<EmployeeModel>(query, parameters);
        }
    }

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
}
