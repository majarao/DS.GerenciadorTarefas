
namespace DS.GerenciadorTarefas.Infra.Data;

public class UnitOfWork(GerenciadorTarefasDbContext context) : IUnitOfWork
{
    public GerenciadorTarefasDbContext Context { get; set; } = context;

    public int SaveChanges() => Context.SaveChanges();

    public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();
}
