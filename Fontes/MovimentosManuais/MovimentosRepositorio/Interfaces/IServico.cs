using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosDominio.Interfaces
{
    public interface IServico<T> 
    {
        T Inserir<V>(T obj) where V : AbstractValidator<T>;

        T Editar<V>(T obj) where V : AbstractValidator<T>;

        void Excluir(int id);

        T Selecionar(int id);

        IList<T> SelecionaTodos();

    }
}
