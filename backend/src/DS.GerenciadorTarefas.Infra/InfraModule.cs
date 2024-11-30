using DS.GerenciadorTarefas.Domain.Repositories;
using DS.GerenciadorTarefas.Infra.Data;
using DS.GerenciadorTarefas.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DS.GerenciadorTarefas.Infra;

public static class InfraModule
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddContext(configuration)
            .AddRepository();

        return services;
    }

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GerenciadorTarefasDbContext>(option => option
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ITarefaRepository, TarefaRepository>();

        return services;
    }
}
