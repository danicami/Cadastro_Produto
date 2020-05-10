using FluentValidation;
using MovimentosDominio.Interfaces;
using MovimentosManuais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovimentosServicos.Servicos
{
    public class MovimentoManualServico : IServico<MovimentoManual> 
    {
        private readonly IRepositorio<MovimentoManual> repository;

        public MovimentoManualServico(IRepositorio<MovimentoManual> _repository)
        {
            repository = _repository;

        }
        public void Excluir(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Delete(id);
        }

        public MovimentoManual Inserir<V>(MovimentoManual obj) where V : AbstractValidator<MovimentoManual>
        {
            Validate(obj, Activator.CreateInstance<V>());

            obj.CodigoUsuario = "TESTE";
            obj.DataLancamento = DateTime.Now;

            repository.Insert(obj);
            return obj;
        }

        public MovimentoManual Selecionar(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        public IList<MovimentoManual> SelecionaTodos()
        {
            return repository.SelectAll();
        }

        public MovimentoManual Editar<V>(MovimentoManual obj) where V : AbstractValidator<MovimentoManual>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        private void Validate(MovimentoManual obj, AbstractValidator<MovimentoManual> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
