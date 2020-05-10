using Microsoft.EntityFrameworkCore;
using MovimentosDominio.Interfaces;
using MovimentosInfraestrutura.Contexto;
using MovimentosManuais.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovimentosInfraestrutura.Repositorio
{
    public class ListaRepositorio<T> : IRepositorio<T> where T : BaseModelo
    {

        private readonly ContextoAplicacao _context;

        public ListaRepositorio(ContextoAplicacao context)
        {
            _context = context;

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public T Select(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> SelectAll()
        {
            var query = _context.Query<T>().FromSql("EXECUTE LISTAMOVIMENTOS").ToList();

            return query;
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
