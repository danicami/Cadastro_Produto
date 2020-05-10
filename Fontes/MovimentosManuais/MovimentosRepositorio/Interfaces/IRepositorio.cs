using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosDominio.Interfaces
{
    public interface IRepositorio<T>
    {
        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);

        T Select(int id);

        IList<T> SelectAll();

    }
}
