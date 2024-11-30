using DS.GerenciadorTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DS.GerenciadorTarefas.Infra.Data;

public class GerenciadorTarefasDbContext : DbContext
{
    public GerenciadorTarefasDbContext(DbContextOptions<GerenciadorTarefasDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Tarefa> Tarefas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
