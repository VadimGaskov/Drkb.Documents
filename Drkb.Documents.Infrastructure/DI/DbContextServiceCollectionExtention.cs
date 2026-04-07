using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drkb.Documents.Infrastructure.DI;

public static class DbContextServiceCollectionExtention
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //TODO прописать DBContext
        /*services.AddDbContext<DrkbNewsDbContext>(options =>
        {
            options.UseNpgsql(connectionString, x => x.MigrationsAssembly("drkb-news.Infrastructure"));
        });*/

        return services;
    }
}