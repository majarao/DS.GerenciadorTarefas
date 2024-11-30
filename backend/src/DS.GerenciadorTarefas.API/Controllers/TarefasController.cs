using DS.GerenciadorTarefas.Application.Models;
using DS.GerenciadorTarefas.Application.Services;
using DS.GerenciadorTarefas.Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace DS.GerenciadorTarefas.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefasController(ITarefaService tarefaService) : ControllerBase
{
    private ITarefaService TarefaService { get; } = tarefaService;

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        TarefaResultModel? tarefa = await TarefaService.GetByIdAsync(id);

        if (tarefa == null)
            return NotFound();

        return Ok(tarefa);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        List<TarefaResultModel>? tarefas = await TarefaService.GetAllAsync();

        return Ok(tarefas);
    }

    [HttpGet("status/{status:int}")]
    public async Task<IActionResult> GetAllByStatusAsync(int status)
    {
        List<TarefaResultModel>? tarefas = await TarefaService.GetAllByStatusAsync((Status)status);

        return Ok(tarefas);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(TarefaInputModel tarefaModel)
    {
        TarefaResultModel? tarefa = await TarefaService.CreateAsync(tarefaModel);
        return Ok(tarefa);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, TarefaInputModel tarefaModel)
    {
        TarefaResultModel? tarefa = await TarefaService.UpdateAsync(id, tarefaModel);
        return Ok(tarefa);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        bool removidoSucesso = await TarefaService.DeleteAsync(id);

        if (removidoSucesso)
            return Ok();

        return NotFound();
    }

    [HttpPut("{id:int}/iniciar")]
    public async Task<IActionResult> IniciarTarefaAsync(int id)
    {
        TarefaResultModel? tarefa = await TarefaService.IniciarTarefaAsync(id);
        return Ok(tarefa);
    }

    [HttpPut("{id:int}/concluir")]
    public async Task<IActionResult> ConcluirTarefaAsync(int id)
    {
        TarefaResultModel? tarefa = await TarefaService.ConcluirTarefaAsync(id);
        return Ok(tarefa);
    }
}
