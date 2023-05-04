using LibraryApp.DataService.ModelsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DataService.Repositories
{
    public class EditorialRepository : IRepository<Editoriale>
    {
        private readonly LibreriaTravelContext _libraryContext;
        public EditorialRepository(LibreriaTravelContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
        public void Delete(Editoriale author)
        {
            throw new NotImplementedException();
        }

        public Editoriale Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Editoriale> GetAll()
        {
            return _libraryContext.Editoriales;
        }

        public ICollection<AutoresLibro> GetAllById(int isbn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Editoriale> GetByFilter(Func<Editoriale, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Editoriale author)
        {
            throw new NotImplementedException();
        }
    }
}
