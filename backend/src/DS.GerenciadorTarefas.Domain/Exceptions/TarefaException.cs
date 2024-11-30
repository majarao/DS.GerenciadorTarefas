namespace DS.GerenciadorTarefas.Domain.Exceptions;

public class TarefaTituloVazioException : Exception
{
    public TarefaTituloVazioException() : base("Título não pode ser vazio") { }
}

public class TarefaDataConcluidoMenorDataCriadoException : Exception
{
    public TarefaDataConcluidoMenorDataCriadoException() : base("Data de conclusão é inferior à data de criação") { }
}
