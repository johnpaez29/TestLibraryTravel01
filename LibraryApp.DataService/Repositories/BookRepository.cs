using LibraryApp.DataService.ModelsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DataService.Repositories
{
    public class BookRepository : IRepository<Libro>
    {
        private readonly LibreriaTravelContext _context;
        public BookRepository(LibreriaTravelContext context)
        {
            _context = context;
        }
        public void Delete(Libro item)
        {
            var autoresLibros = _context.AutoresLibros.Where(autorLibro => autorLibro.LibroIsbn == item.Isbn);

            _context.AutoresLibros.RemoveRange(autoresLibros);
            _context.Libros.Remove(item);
            _context.SaveChanges();
        }

        public Libro Get(int id)
        {
            Libro libro = _context.Libros.Find(id);
            return _context.Libros.Find(id);
        }

        public IEnumerable<Libro> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<AutoresLibro> GetAllById(int isbn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> GetByFilter(Func<Libro, bool> filter)
        {
            return _context.Libros.Where(filter);
        }

        public void Insert(Libro item)
        {
            Libro libro = _context.Libros.FirstOrDefault(libro => libro.Isbn == item.Isbn);

            if (libro != null)
            {
                _context.AutoresLibros.RemoveRange(_context.AutoresLibros.Where(libro => libro.LibroIsbn == item.Isbn));
                _context.Libros.Remove(libro);
            }

            _context.Libros.Add(item);

            _context.SaveChanges();
        }
    }
}
