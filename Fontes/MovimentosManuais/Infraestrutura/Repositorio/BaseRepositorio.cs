using Microsoft.EntityFrameworkCore;
using MovimentosDominio.Interfaces;
using MovimentosInfraestrutura.Contexto;
using MovimentosManuais.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovimentosInfraestrutura.Repositorio
{
    public class BaseRepositorio<T> : IRepositorio<T> where T : BaseModelo
    {
        private readonly ContextoAplicacao _context;

        public BaseRepositorio(ContextoAplicacao context)
        {
            _context = context;

        }

        public void Insert(T obj)
        {
            var local = _context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.CodigoProduto.Equals(obj.CodigoProduto));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(Select(id));
            _context.SaveChanges();
        }

        public IList<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return _context.Set<T>().Find(id);
        }

    }
}
