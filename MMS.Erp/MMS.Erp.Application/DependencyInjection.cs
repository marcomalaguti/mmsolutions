
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MMS.Erp.Application.Behaviors;
using System.Reflection;

namespace MMS.Erp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
