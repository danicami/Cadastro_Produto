using FluentValidation;
using MovimentosDominio.Interfaces;
using MovimentosManuais.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosServicos.Servicos
{
    public class BaseServico<T> : IServico<T> where T : BaseModelo
    {
        private readonly IRepositorio<T> repository;

        public BaseServico(IRepositorio<T> _repository)
        {
            repository = _repository;

        }
        public void Excluir(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Delete(id);
        }

        public T Inserir<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Selecionar(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        public IList<T> SelecionaTodos()
        {
            return repository.SelectAll();
        }

        public T Editar<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
