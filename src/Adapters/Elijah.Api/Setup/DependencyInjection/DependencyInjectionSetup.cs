using Elijah.Application.Interfaces.User;
using Elijah.Application.Services.User;
using Elijah.Domain.Interfaces.User;
using Elijah.Infrastructure.Database.Repository.User;

namespace Elijah.Api.Setup.DependencyInjection;

public static class DependencyInjectionSetup
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        RegisterRepositories(services);
        RegisterServices(services);
    }
    
    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
    
    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}