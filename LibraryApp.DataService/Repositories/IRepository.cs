//using LibraryApp.DataService.ModelsSql;
using LibraryApp.DataService.ModelsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DataService.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Insert(T author);

        IEnumerable<T> GetAll();

        T Get(int id);

        void Delete(T author);
        IEnumerable<T> GetByFilter(Func<T, bool> filter);
        ICollection<AutoresLibro> GetAllById(int isbn);
    }
}
