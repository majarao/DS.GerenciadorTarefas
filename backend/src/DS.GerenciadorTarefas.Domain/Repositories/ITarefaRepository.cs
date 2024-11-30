using DS.GerenciadorTarefas.Domain.Entities;
using DS.GerenciadorTarefas.Domain.Enum;

namespace DS.GerenciadorTarefas.Domain.Repositories;

public interface ITarefaRepository
{
    public Task<Tarefa?> GetByIdAsync(int id);
    public Task<List<Tarefa>?> GetAllAsync();
    public Task<List<Tarefa>?> GetAllByStatusAsync(Status status);
    public Task<Tarefa> CreateAsync(Tarefa tarefa);
    public Task<Tarefa?> UpdateAsync(int id, Tarefa tarefa);
    public Task<bool> DeleteAsync(int id);
    public Task<Tarefa?> IniciarTarefaAsync(int id);
    public Task<Tarefa?> ConcluirTarefaAsync(int id);
}
