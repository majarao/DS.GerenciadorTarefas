using DS.GerenciadorTarefas.Application.Models;
using FluentValidation;

namespace DS.GerenciadorTarefas.Application;

public class TarefaInputModelValidator : AbstractValidator<TarefaInputModel>
{
    public TarefaInputModelValidator()
    {
        RuleFor(t => t.Titulo)
            .NotEmpty().WithMessage("Necessário informar o título")
            .NotNull().WithMessage("Necessário informar o título")
            .MaximumLength(100).WithMessage("Título não pode ter mais de 100 caracteres");

        RuleFor(t => t.Descricao)
            .MaximumLength(300).WithMessage("Descrição não pode ter mais de 300 caracteres");
    }
}
