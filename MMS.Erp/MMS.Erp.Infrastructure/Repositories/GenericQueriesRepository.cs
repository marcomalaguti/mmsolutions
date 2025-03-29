namespace MMS.Erp.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

public class GenericQueriesRepository
{
    public string ErpConnectionString { get; set; } = string.Empty;

    public GenericQueriesRepository(IConfiguration configuration)
    {
        ErpConnectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException("Connection string not found");
    }
}
