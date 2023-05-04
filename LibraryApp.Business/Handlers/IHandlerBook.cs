using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Handlers
{
    public interface IHandlerBook<T, U> 
        where T : class 
        where U : class
    {
        void Insert(T item);

        T Get(T item);

        IEnumerable<T> GetAll();

        void Delete(U item);

        IEnumerable<U> GetByFilter(U item);
    }
}
