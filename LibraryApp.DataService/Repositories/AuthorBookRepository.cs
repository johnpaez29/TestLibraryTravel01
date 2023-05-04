using LibraryApp.DataService.ModelsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DataService.Repositories
{
    public class AuthorBookRepository : IRepository<AutoresLibro>
    {
        private readonly LibreriaTravelContext _libraryContext;
        public AuthorBookRepository(LibreriaTravelContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public void Delete(AutoresLibro author)
        {
            throw new NotImplementedException();
        }

        public AutoresLibro Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutoresLibro> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<AutoresLibro> GetAllById(int isbn)
        {
            return _libraryContext.AutoresLibros.Where(autorLibro => autorLibro.LibroIsbn == isbn).ToList();
        }

        public IEnumerable<AutoresLibro> GetByFilter(Func<AutoresLibro, bool> filter)
        {
            return _libraryContext.AutoresLibros.Where(filter);
        }

        public void Insert(AutoresLibro author)
        {
            throw new NotImplementedException();
        }
    }
}
