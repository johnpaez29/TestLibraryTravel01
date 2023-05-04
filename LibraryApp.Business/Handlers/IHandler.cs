using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Handlers
{
    public interface IHandler<T> 
        where T : class
    {
        void Insert(T item);

        T Get(T item);

        IEnumerable<T> GetAll();

        void Delete(T item);

        IEnumerable<T> GetByFilter(T item);

    }
}
