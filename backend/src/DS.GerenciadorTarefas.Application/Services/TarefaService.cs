using DS.GerenciadorTarefas.Application.Models;
using DS.GerenciadorTarefas.Domain.Entities;
using DS.GerenciadorTarefas.Domain.Enum;
using DS.GerenciadorTarefas.Domain.Helpers;
using DS.GerenciadorTarefas.Domain.Repositories;

namespace DS.GerenciadorTarefas.Application.Services;

public class TarefaService(ITarefaRepository repository) : ITarefaService
{
    private ITarefaRepository Repository { get; } = repository;

    public async Task<TarefaResultModel?> GetByIdAsync(int id)
    {
        Tarefa? tarefa = await Repository.GetByIdAsync(id);

        if (tarefa == null)
            return null;

        return ToResultModel(tarefa);
    }

    public async Task<List<TarefaResultModel>?> GetAllAsync()
    {
        List<Tarefa>? tarefas = await Repository.GetAllAsync();

        return tarefas?.Select(t => ToResultModel(t)).ToList();
    }

    public async Task<List<TarefaResultModel>?> GetAllByStatusAsync(Status status)
    {
        List<Tarefa>? tarefas = await Repository.GetAllByStatusAsync(status);

        return tarefas?.Select(t => ToResultModel(t)).ToList();
    }

    public async Task<TarefaResultModel> CreateAsync(TarefaInputModel tarefaModel)
    {
        Tarefa tarefa = new(tarefaModel.Titulo, tarefaModel.Descricao);
        await Repository.CreateAsync(tarefa);
        return ToResultModel(tarefa);
    }

    public async Task<TarefaResultModel?> UpdateAsync(int id, TarefaInputModel tarefaModel)
    {
        Tarefa? tarefa = await Repository.GetByIdAsync(id);

        if (tarefa == null)
            return null;

        if (tarefa.Id != id)
            return null;

        tarefa.AtualizarTarefa(tarefaModel.Titulo, tarefaModel.Descricao);
        await Repository.UpdateAsync(id, tarefa);
        return ToResultModel(tarefa);
    }

    public async Task<bool> DeleteAsync(int id) => await Repository.DeleteAsync(id);

    public async Task<TarefaResultModel?> IniciarTarefaAsync(int id)
    {
        Tarefa? tarefa = await Repository.GetByIdAsync(id);

        if (tarefa == null)
            return null;

        if (tarefa.Id != id)
            return null;

        tarefa.IniciarTarefa();
        await Repository.UpdateAsync(id, tarefa);
        return ToResultModel(tarefa);
    }

    public async Task<TarefaResultModel?> ConcluirTarefaAsync(int id)
    {
        Tarefa? tarefa = await Repository.GetByIdAsync(id);

        if (tarefa == null)
            return null;

        if (tarefa.Id != id)
            return null;

        tarefa.ConcluirTarefa(null);
        await Repository.UpdateAsync(id, tarefa);
        return ToResultModel(tarefa);
    }

    public TarefaResultModel ToResultModel(Tarefa tarefa)
    {
        return new(
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Descricao,
            tarefa.DataCriacao.ToString("dd/MM/yyyy hh:mm"),
            tarefa.DataConclusao?.ToString("dd/MM/yyyy hh:mm"),
            tarefa.Status.GetString());
    }
}
