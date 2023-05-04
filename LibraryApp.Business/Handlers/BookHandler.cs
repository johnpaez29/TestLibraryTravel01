using LibraryApp.DataService.ModelsSql;
using LibraryApp.DataService.Repositories;
using LibraryApp.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Handlers
{
    public class BookHandler : IHandlerBook<Libro, BookDto>
    {
        private readonly IRepository<Libro> _bookRepository;
        private readonly IRepository<AutoresLibro> _autoresLibroRepository;

        public BookHandler(
            IRepository<Libro> bookRepository,
            IRepository<AutoresLibro> autoresLibroRepository
            )
        {
            _bookRepository = bookRepository;
            _autoresLibroRepository = autoresLibroRepository;
        }

        public void Delete(BookDto item)
        {
            if (item.Isbn != 0)
            {
                Libro libro = _bookRepository.Get(item.Isbn ?? 0);

                _bookRepository.Delete(libro);
            }
        }

        public Libro Get(Libro item)
        {
            Libro libro = _bookRepository.Get(item.Isbn);

            libro.AutoresLibros = _autoresLibroRepository.GetAllById(item.Isbn);

            return libro;
        }

        public IEnumerable<Libro> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDto> GetByFilter(BookDto item)
        {
            List<AutoresLibro> bookAuthors = new();
            if ((item.AuthorId ?? 0) != 0)
            {
                bookAuthors = _autoresLibroRepository.GetByFilter(autorLibro => autorLibro.IdAutor == item.AuthorId).ToList();
            }

            Func<Libro, bool> filter = CreateFilter(item, bookAuthors);

            return _bookRepository.GetByFilter(filter).Select(book =>
            new BookDto
            {
                Isbn = book.Isbn,
                NameBook = book.Titulo,
                EditorialId = book.IdEditorial
            });
        }

        public void Insert(Libro item)
        {
            _bookRepository.Insert(item);
        }

        private static Func<Libro, bool> CreateFilter(BookDto item, IEnumerable<AutoresLibro> bookAuthors)
        {
            Func<Libro, bool> filter = libro =>
                ((item.Isbn ?? 0) == 0 || item.Isbn == libro.Isbn) &&
                 (string.IsNullOrEmpty(item.NameBook) || libro.Titulo.ToUpper().Contains(item.NameBook.ToUpper())) &&
                 ((item.EditorialId ?? 0) == 0 || libro.IdEditorial == item.EditorialId) &&
                 (!(bookAuthors?.Any() ?? false) || bookAuthors.Any(bookAuthor => bookAuthor.LibroIsbn == libro.Isbn));

            return filter;
        }

    }
}
