using LibraryApp.DataService.ModelsSql;
using LibraryApp.DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Handlers
{
    public class AuthorHandler : IHandler<Autore>
    {
        private readonly IRepository<Autore> _authorRepository;
        public AuthorHandler(IRepository<Autore> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public void Delete(Autore item)
        {
            throw new NotImplementedException();
        }

        public Autore Get(Autore item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autore> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public IEnumerable<Autore> GetByFilter(Autore item)
        {
            throw new NotImplementedException();
        }

        public void Insert(Autore item)
        {
            throw new NotImplementedException();
        }
    }
}
