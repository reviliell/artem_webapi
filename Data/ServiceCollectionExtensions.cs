using Data._Internal;
using Data._Internal.Repositories;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class ServiceCollectionExtensions
{
    public static void ConfigureDataLayer(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(Constants.InMemoryDbName));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
    }
}