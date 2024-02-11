using MediatR;
using Todo.DAL.Repositories.Implementations;
using Todo.DAL.Repositories.Interfaces;
using Microsoft.FeatureManagement;
using Todo.BLL.MediatR.Todo.GetAll;

namespace Todo.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }

    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddRepositoryServices();
        services.AddFeatureManagement();
        services.AddMemoryCache();
        var assemblyContainingHandlers = AppDomain.CurrentDomain.Load("Todo.BLL");
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(assemblyContainingHandlers);
    }
}