using LibraryApp.Business.Handlers;
using LibraryApp.DataService.ModelsSql;
using LibraryApp.DataService.Repositories;
using LibraryApp.Model.DTO;
using LibraryApp.Model.Others;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace LibraryApp.Test
{
    public class Tests
    {
        private IHandlerBook<Libro, BookDto> _handler;
        private IRepository<Libro> _bookRepository;
        private IRepository<AutoresLibro> _authorsBook;
        private LibreriaTravelContext _context;
        public IConfigurationRoot Configuration { get; set; }
        [SetUp]
        public void Setup()
        {
            string path = Path.GetFullPath("../../../../Library App/appsettings.json");
            var builder = new ConfigurationBuilder()
                .AddJsonFile(path, optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<LibreriaTravelContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString(Constants.ConnectionStringSql));
            _context = new LibreriaTravelContext(optionsBuilder.Options);

            _bookRepository = new BookRepository(_context);

            var a = new LibreriaTravelContext();
            _authorsBook = new AuthorBookRepository(a);
            _handler = new BookHandler(_bookRepository, _authorsBook);
        }

        [Test]
        public void InsertBook()
        {
            try
            {
                _handler.Insert(
                    new Libro
                    {
                        Isbn = 0,
                        IdEditorial = 3,
                        NPaginas = "45",
                        Sinopsis = "El mundo al reves",
                        Titulo = "El mundo al reves",
                        AutoresLibros = new List<AutoresLibro>
                                {
                                    new AutoresLibro
                                    {
                                        IdAutor = 4
                                    }
                                }
                    });
            }
            catch (System.Exception e)
            {
                Assert.Fail(e.Message);
            }



            Assert.Pass("Ok");
        }
    }
}