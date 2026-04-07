using Drkb.Documents.Application;
using Drkb.Documents.Application.UseCase.Command;
using Microsoft.Extensions.DependencyInjection;

namespace Drkb.Documents.Infrastructure.DI;

public static class MediatrServiceCollectionExtention
{
    public static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(msc => msc.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyMarker).Assembly));
        return services;
    }
}