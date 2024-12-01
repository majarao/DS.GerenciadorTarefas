namespace DS.GerenciadorTarefas.Application.Models;

public record TarefaResultModel(
    int Id,
    string Titulo,
    string? Descricao,
    string DataCriacao,
    string? DataConclusao,
    string Status);
