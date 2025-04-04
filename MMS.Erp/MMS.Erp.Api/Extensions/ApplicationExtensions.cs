﻿using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using MMS.Erp.Api.Endpoints;
using MMS.Erp.Api.Mappings;
using MMS.Erp.Application;
using MMS.Erp.Application.Configurations;
using MMS.Erp.Infrastructure;
using Serilog;

namespace MMS.Erp.Api.Extensions;

internal static class ApplicationExtensions
{
    internal static WebApplicationBuilder AddWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddAzureAppConfiguration(options =>
        {
            options.Connect(builder.Configuration["ConnectionStrings:ErpAppConfiguration"])
                   .Select(KeyFilter.Any);
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMapster();

        builder.Services.AddConfigurations(builder.Configuration);

        builder.Services.AddApplication(builder.Configuration);
        builder.Services.AddInfrastrucure(builder.Configuration);

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        builder.Services.AddCors(options =>
        {
            var origins = builder.Configuration.GetSection("ErpApiCors").Get<string[]>();

            options.AddPolicy("AllowFrontEnd",
                policy => policy.WithOrigins(origins ?? [])
                                .AllowAnyMethod()
                                .AllowAnyHeader());
        });

        return builder;
    }

    private static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ExpenseReportsConfig>(configuration.GetSection("ExpenseReports"));
        services.Configure<PayChecksConfig>(configuration.GetSection("PayChecks"));
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

        app.UseCors("AllowFrontEnd");

        return app;
    }

    private static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        CustomerMapper.RegisterMappings();
        EmployeeMapper.RegisterMappings();
        ExpenseReportMapper.RegisterMappings();
        InvoiceMapper.RegisterMappings();
        PaycheckMapper.RegisterMappings();

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
