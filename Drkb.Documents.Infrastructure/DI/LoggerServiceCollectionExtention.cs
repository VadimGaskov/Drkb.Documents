using Drkb.Documents.Application.Interfaces;
using Drkb.Documents.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Drkb.Documents.Infrastructure.DI;

public static class LoggerServiceCollectionExtention
{
    public static IServiceCollection AddSerilogLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerService, SerilogLoggerService>();
        return services;
    }
}