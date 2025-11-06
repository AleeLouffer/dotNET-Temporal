using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace dotNET_Temporal.Config;

public static class EndpointsConfig
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        services.TryAddEnumerable([.. assembly.DefinedTypes.Where(x => x is { IsAbstract: false, IsInterface: false } && x.IsAssignableTo(typeof(IEndpoint))).Select(x => ServiceDescriptor.Transient(typeof(IEndpoint), x))]);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>().ToList();
        var builder = (IEndpointRouteBuilder)(routeGroupBuilder is null ? app : routeGroupBuilder);

        endpoints.ForEach(x => x.MapEndpoint(builder, app.Logger));

        return app;
    }
}

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app, ILogger logger);
}