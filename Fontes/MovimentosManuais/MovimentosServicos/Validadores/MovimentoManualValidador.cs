using FluentValidation;
using MovimentosManuais.Models;
using System;

namespace MovimentosServicos.Validadores
{
    public class MovimentoManualValidador : AbstractValidator<MovimentoManual>
    {
        public MovimentoManualValidador()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Objeto não encontrado.");
                    });

            RuleFor(c => c.DataMes)
                .NotEmpty().WithMessage("É necessário informar o Mês.")
                .NotNull().WithMessage("É necessário informar o Mês.");

            RuleFor(c => c.DataAno)
                .NotEmpty().WithMessage("É necessário informar o Ano.")
                .NotNull().WithMessage("É necessário informar o Ano.");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("É necessário informar o Valor.")
                .NotNull().WithMessage("É necessário informar o Valor.");

        }

    }
}
