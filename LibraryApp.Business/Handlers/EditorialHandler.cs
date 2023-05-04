using LibraryApp.DataService.ModelsSql;
using LibraryApp.DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Handlers
{
    public class EditorialHandler : IHandler<Editoriale>
    {
        private readonly IRepository<Editoriale> _editorialRepository;
        public EditorialHandler(IRepository<Editoriale> editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }
        public void Delete(Editoriale item)
        {
            throw new NotImplementedException();
        }

        public Editoriale Get(Editoriale item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Editoriale> GetAll()
        {
            return _editorialRepository.GetAll();
        }

        public IEnumerable<Editoriale> GetByFilter(Editoriale item)
        {
            throw new NotImplementedException();
        }

        public void Insert(Editoriale item)
        {
            throw new NotImplementedException();
        }
    }
}
