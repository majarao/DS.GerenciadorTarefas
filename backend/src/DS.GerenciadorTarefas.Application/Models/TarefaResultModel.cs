namespace DS.GerenciadorTarefas.Application.Models;

public record TarefaResultModel(
    int Id,
    string Titulo,
    string? Descricao,
    DateTime DataCriacao,
    DateTime? DataConclusao,
    int Status);
