using LibraryApp.DataService.ModelsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DataService.Repositories
{
    public class AuthorRepository : IRepository<Autore>
    {
        private readonly LibreriaTravelContext _libraryContext;
        public AuthorRepository(LibreriaTravelContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public void Delete(Autore author)
        {
            throw new NotImplementedException();
        }

        public Autore Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autore> GetAll()
        {
            return _libraryContext.Autores;
        }

        public ICollection<AutoresLibro> GetAllById(int isbn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autore> GetByFilter(Func<Autore, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Autore author)
        {
            throw new NotImplementedException();
        }
    }
}
