using DS.GerenciadorTarefas.Domain.Enum;
using DS.GerenciadorTarefas.Domain.Exceptions;

namespace DS.GerenciadorTarefas.Domain.Entities;

public class Tarefa
{
    protected Tarefa() { }

    public Tarefa(string titulo)
    {
        Titulo = titulo;
        Status = Status.Pendente;
        DataCriacao = DateTime.UtcNow;

        ValidaTarefa();
    }

    private void ValidaTarefa()
    {
        if (string.IsNullOrWhiteSpace(Titulo))
            throw new TarefaTituloVazioException();

        if (DataConclusao is not null)
        {
            if (DataConclusao < DataCriacao)
                throw new TarefaDataConcluidoMenorDataCriadoException();
        }
    }

    public void IniciarTarefa()
    {
        Status = Status.EmProgresso;

        ValidaTarefa();
    }

    public void ConcluirTarefa()
    {
        Status = Status.Concluida;
        DataConclusao = DateTime.UtcNow;

        ValidaTarefa();
    }

    public void AtualizarTarefa(string titulo, string? descricao)
    {
        Titulo = titulo;
        Descricao = descricao;

        ValidaTarefa();
    }

    public int Id { get; private set; }
    public string Titulo { get; private set; } = null!;
    public string? Descricao { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataConclusao { get; private set; }
    public Status Status { get; private set; }
}
