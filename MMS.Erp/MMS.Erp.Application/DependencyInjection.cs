
using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMS.AzureBlobStorage;
using MMS.Erp.Application.Mappings;
using MMS.Erp.Application.Mediator.Behaviors;
using MMS.Erp.Application.Services.ExpenseReport;
using MMS.Erp.Application.Services.PayCheck;
using System.Reflection;

namespace MMS.Erp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediator();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMapster();

        services.AddMMSAzureBlobStorage(configuration);

        services.AddApplicationServices();

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

        return services;
    }

    private static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        EmployeeMapper.RegisterMappings();
        InvoiceMapper.RegisterMappings();
        ExpenseReportMapper.RegisterMappings();

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IExpenseReportService, ExpenseReportService>();
        services.AddScoped<IPayCheckService, PayCheckService>();

        return services;
    }
}
