
using Drkb.Documents.Application.Interfaces.QueryObjects;
using Microsoft.Extensions.DependencyInjection;

namespace Drkb.Documents.Infrastructure.DI;

public static class QueryObjectsCollectionExtention
{
    public static IServiceCollection AddQueryObjects(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<InfrastructureAssemblyMarker>()
            .AddClasses(classes => classes.AssignableTo<IQueryMarker>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        
        return services;
    }
}