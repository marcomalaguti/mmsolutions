using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Infrastructure.Repositories;

namespace MMS.Erp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrucure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection string not found");

        services.AddDbContext<ErpDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IInvoiceRepository, InvoiceRepository>();

        return services;
    }
}
