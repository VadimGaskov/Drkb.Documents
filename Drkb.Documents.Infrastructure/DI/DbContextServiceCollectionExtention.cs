using Drkb.Documents.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drkb.Documents.Infrastructure.DI;

public static class DbContextServiceCollectionExtention
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DocumentsDbContext>(options =>
        {
            options.UseNpgsql(connectionString, 
                x => x.MigrationsAssembly(typeof(DocumentsDbContext).Assembly.GetName().Name));
        });

        return services;
    }
}