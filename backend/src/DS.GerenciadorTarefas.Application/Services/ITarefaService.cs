using DS.GerenciadorTarefas.Application.Models;
using DS.GerenciadorTarefas.Domain.Entities;
using DS.GerenciadorTarefas.Domain.Enum;

namespace DS.GerenciadorTarefas.Application.Services;

public interface ITarefaService
{
    public Task<TarefaResultModel?> GetByIdAsync(int id);
    public Task<List<TarefaResultModel>?> GetAllAsync();
    public Task<List<TarefaResultModel>?> GetAllByStatusAsync(Status status);
    public Task<TarefaResultModel> CreateAsync(TarefaInputModel tarefaModel);
    public Task<TarefaResultModel?> UpdateAsync(int id, TarefaInputModel tarefaModel);
    public Task<bool> DeleteAsync(int id);
    public Task<TarefaResultModel?> IniciarTarefaAsync(int id);
    public Task<TarefaResultModel?> ConcluirTarefaAsync(int id);
    public TarefaResultModel ToResultModel(Tarefa tarefa);
}
