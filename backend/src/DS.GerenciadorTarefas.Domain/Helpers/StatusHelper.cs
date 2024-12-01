using DS.GerenciadorTarefas.Domain.Enum;

namespace DS.GerenciadorTarefas.Domain.Helpers;

public static class StatusHelper
{
    public static string GetString(this Status status)
    {
        return status switch
        {
            Status.Pendente => "Pendente",
            Status.EmProgresso => "Em progresso",
            Status.Concluida => "Concluída",
            _ => ""
        };
    }
}
