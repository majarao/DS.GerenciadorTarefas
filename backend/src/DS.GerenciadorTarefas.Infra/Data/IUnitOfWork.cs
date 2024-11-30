namespace DS.GerenciadorTarefas.Infra.Data;

public interface IUnitOfWork
{
    public GerenciadorTarefasDbContext Context { get; set; }
    public int SaveChanges();
    public Task<int> SaveChangesAsync();
}
