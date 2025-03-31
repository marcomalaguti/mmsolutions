using Mapster;
using MapsterMapper;
using MMS.Erp.Api.Endpoints;
using MMS.Erp.Api.Mappings;
using MMS.Erp.Application;
using MMS.Erp.Infrastructure;
using Serilog;

namespace MMS.Erp.Api.Extensions;

internal static class ApplicationExtensions
{
    internal static WebApplicationBuilder AddWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMapster();

        builder.Services.AddApplication();
        builder.Services.AddInfrastrucure(builder.Configuration);

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        return builder;
    }

    internal static WebApplication AddWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();

        app.MapEndpoints();

        return app;
    }

    private static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        CustomerMapper.RegisterMappings();
        EmployeeMapper.RegisterMappings();
        ExpenseReportMapper.RegisterMappings();
        InvoiceMapper.RegisterMappings();

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
