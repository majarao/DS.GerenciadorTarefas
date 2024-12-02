using DS.GerenciadorTarefas.Domain.Entities;
using DS.GerenciadorTarefas.Domain.Enum;
using DS.GerenciadorTarefas.Domain.Repositories;
using DS.GerenciadorTarefas.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DS.GerenciadorTarefas.Infra.Repositories;

internal class TarefaRepository(IUnitOfWork unitOfWork) : ITarefaRepository
{
    private IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<Tarefa?> GetByIdAsync(int id) => await UnitOfWork.Context.Tarefas.SingleOrDefaultAsync(t => t.Id == id);

    public async Task<List<Tarefa>?> GetAllAsync() => await UnitOfWork.Context.Tarefas.ToListAsync();

    public async Task<List<Tarefa>?> GetAllByStatusAsync(Status status) => await UnitOfWork.Context.Tarefas.Where(t => t.Status == status).ToListAsync();

    public async Task<Tarefa> CreateAsync(Tarefa tarefa)
    {
        await UnitOfWork.Context.AddAsync(tarefa);
        await UnitOfWork.SaveChangesAsync();

        return tarefa;
    }

    public async Task<Tarefa?> UpdateAsync(int id, Tarefa tarefa)
    {
        Tarefa? tarefaById = await GetByIdAsync(id);

        if (tarefaById is not null)
        {
            if (tarefaById.Id == id)
            {
                UnitOfWork.Context.Update(tarefa);
                await UnitOfWork.SaveChangesAsync();
            }
        }

        return tarefa;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Tarefa? tarefa = await GetByIdAsync(id);

        if (tarefa is not null)
        {
            UnitOfWork.Context.Remove(tarefa);
            return await UnitOfWork.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async Task<Tarefa?> IniciarTarefaAsync(int id)
    {
        Tarefa? tarefa = await GetByIdAsync(id);

        if (tarefa is not null)
        {
            tarefa.IniciarTarefa();
            UnitOfWork.Context.Update(tarefa);
            await UnitOfWork.Context.SaveChangesAsync();

            return tarefa;
        }

        return null;
    }

    public async Task<Tarefa?> ConcluirTarefaAsync(int id)
    {
        Tarefa? tarefa = await GetByIdAsync(id);

        if (tarefa is not null)
        {
            tarefa.ConcluirTarefa(null);
            UnitOfWork.Context.Update(tarefa);
            await UnitOfWork.Context.SaveChangesAsync();

            return tarefa;
        }

        return null;
    }
}
