using DS.GerenciadorTarefas.Domain.Entities;
using DS.GerenciadorTarefas.Domain.Enum;
using DS.GerenciadorTarefas.Domain.Exceptions;

namespace DS.GerenciadorTarefas.Domain.Test;

public class TarefaTests
{
    [Fact(DisplayName = "Sucesso Criar Tarefa")]
    public void Tarefa_NovaTarefa_Sucesso()
    {
        //Arrange Act
        Tarefa tarefa = new("Tarefa 1", "Descrição da tarefa 1");

        //Assert
        Assert.True(tarefa is not null);
    }

    [Fact(DisplayName = "Falha Título Não Informado")]
    public void Tarefa_NovaTarefa_FalhaTituloNaoInformado()
    {
        //Arrange Act Assert
        Assert.Throws<TarefaTituloVazioException>(() =>
        {
            Tarefa tarefa = new("", "");
        });
    }

    [Fact(DisplayName = "Sucesso Iniciar Tarefa")]
    public void Tarefa_IniciarTarefa_Sucesso()
    {
        //Arrange
        Tarefa tarefa = new("Tarefa 1", "Descrição da tarefa 1");

        //Act
        tarefa.IniciarTarefa();

        //Assert
        Assert.True(tarefa is not null);
        Assert.Equal(Status.EmProgresso, tarefa.Status);
    }

    [Fact(DisplayName = "Sucesso Concluir Tarefa")]
    public void Tarefa_ConcluirTarefa_Sucesso()
    {
        //Arrange
        Tarefa tarefa = new("Tarefa 1", "Descrição da tarefa 1");

        //Act
        tarefa.ConcluirTarefa(null);

        //Assert
        Assert.True(tarefa is not null);
        Assert.Equal(Status.Concluida, tarefa.Status);
    }

    [Fact(DisplayName = "Falha Concluir Tarefa Data Conclusão Inferior Data Cadastro")]
    public void Tarefa_ConcluirTarefa_FalhaDataConclusaoInferiorDataCadastro()
    {
        //Arrange
        Tarefa tarefa = new("Tarefa 1", "Descrição da tarefa 1");

        //Act Assert
        Assert.Throws<TarefaDataConcluidoMenorDataCriadoException>(() => tarefa.ConcluirTarefa(DateTime.UtcNow.AddDays(-30)));
    }

    [Fact(DisplayName = "Sucesso Atualizar Tarefa")]
    public void Tarefa_AtualizarTarefa_Sucesso()
    {
        //Arrange
        Tarefa tarefa = new("Tarefa 1", "Descrição da tarefa 1");

        //Act
        tarefa.AtualizarTarefa("Tarefa 1 atualizada", "Descrição atualizada");

        //Assert
        Assert.True(tarefa is not null);
        Assert.Equal("Tarefa 1 atualizada", tarefa.Titulo);
        Assert.Equal("Descrição atualizada", tarefa.Descricao);
    }
}
