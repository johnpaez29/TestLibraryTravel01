using Library_App.Models;
using LibraryApp.Business.Handlers;
using LibraryApp.DataService.ModelsSql;
using LibraryApp.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Library_App.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHandlerBook<Libro, BookDto> _handlerBook;
        private readonly IHandler<Editoriale> _handlerEditorial;
        private readonly IHandler<Autore> _handlerAuthors;

        private static IEnumerable<BookDto> _books;
        public InventoryController(
            ILogger<HomeController> logger,
            IHandlerBook<Libro, BookDto> handler,
            IHandler<Autore> handlerAuthors,
            IHandler<Editoriale> handlerEditorial)
        {
            _logger = logger;
            _handlerBook = handler;
            _handlerAuthors = handlerAuthors;
            _handlerEditorial = handlerEditorial;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Editorials = GetEditorials();
            ViewBag.Authors = GetAuthors();

            return View();
        }

        private IEnumerable<SelectListItem> GetAuthors(int? id = null)
        {
            IEnumerable<SelectListItem> items = _handlerAuthors.GetAll().Select(editorial =>
                new SelectListItem
                {
                    Value = editorial.IdAutor.ToString(),
                    Text = $"{editorial.Nombre} {editorial.Apellidos}"
                }).Append(
                    new SelectListItem
                    {
                        Value = string.Empty,
                        Text = "Seleccione Editorial...",
                        Selected = true
                    });

            return ValidateDataSelect(id, items);
        }

        private IEnumerable<SelectListItem> GetEditorials(int? id = null)
        {
            IEnumerable<SelectListItem> items = _handlerEditorial.GetAll().Select(editorial =>
                new SelectListItem
                {
                    Value = editorial.IdEditorial.ToString(),
                    Text = editorial.Nombre
                }).Append(
                    new SelectListItem
                    {
                        Value = string.Empty,
                        Text = "Seleccione Editorial...",
                        Selected = true
                    });
            return ValidateDataSelect(id, items);
        }

        private static IEnumerable<SelectListItem> ValidateDataSelect(int? id, IEnumerable<SelectListItem> items)
        {
            if (!id.HasValue)
            {
                return items;
            }
            List<SelectListItem> newItems = new();
            foreach (var item in items)
            {
                if (item.Value.Equals(id.ToString()))
                    item.Selected = true;
                else
                    item.Selected = false;

                newItems.Add(item);
            }
            return newItems;
        }

        [HttpPost]
        public IActionResult Get(FilterBookModel filterBook)
        {
            try
            {
                ViewBag.Editorials = GetEditorials();
                ViewBag.Authors = GetAuthors();

                if ((filterBook.Isbn ?? filterBook.NameBook) == null && (filterBook.AuthorName ?? filterBook.EditorialName) == null)
                {
                    ViewBag.Error = "Favor agregar al menos un filtro en la consulta.";
                    return View("Index");
                }

                if (!string.IsNullOrEmpty(filterBook.Isbn) && !int.TryParse(filterBook.Isbn, out int _))
                {
                    ViewBag.Error = "El filtro ISBN solo permite números y deben ser mayor a cero.";
                    return View("Index");
                }

                _books = _handlerBook.GetByFilter(
                    new BookDto
                    {
                        Isbn = filterBook.Isbn is null ? null : int.Parse(filterBook.Isbn),
                        NameBook = filterBook.NameBook,
                        EditorialId = filterBook.EditorialName,
                        AuthorId = filterBook.AuthorName
                    }).ToList();

                return View("Index", _books);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred", e);


                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try 
            {
                ViewBag.Editorials = GetEditorials();
                ViewBag.Authors = GetAuthors();

                _handlerBook.Delete(
                    new BookDto
                    {
                        Isbn = id
                    });
                _books = _books?.Where(book => book.Isbn != id) ?? Enumerable.Empty<BookDto>();

                return View("Index", _books);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred", e);

                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public IActionResult Form(int? id)
        {
            try
            {
                FormBookModel book = new();
                if (id != null)
                {
                    book = MapLibroModel(_handlerBook.Get(
                        new Libro
                        {
                            Isbn = id ?? 0
                        }));
                }
                ViewBag.Editorials = GetEditorials(book.EditorialName);
                ViewBag.Authors = GetAuthors(book.AuthorName);

                return View(book);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred", e);

                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpPost]
        public IActionResult SubmitForm(FormBookModel book)
        {
            try
            {
                ViewBag.Editorials = GetEditorials();
                ViewBag.Authors = GetAuthors();

                if (ModelState.IsValid)
                {
                    Libro bookInsert =
                        new Libro
                        {
                            Isbn = int.Parse(book.Isbn ?? "0"),
                            IdEditorial = book.EditorialName ?? 0,
                            NPaginas = book.PagesNumber,
                            Sinopsis = book.Synopsis,
                            Titulo = book.NameBook,
                            AutoresLibros = new List<AutoresLibro>
                                {
                                    new AutoresLibro
                                    {
                                        IdAutor = book.AuthorName ?? 0,
                                    }
                                }
                        };
                    _handlerBook.Insert(bookInsert);

                    return View("Index", _books);
                }
                else
                {
                    ViewBag.Error = "Favor llenar todos los campos.";
                    return View("Form", book);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred", e);

                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        private FormBookModel MapLibroModel(Libro book)
        {
            return book == null ? null : new FormBookModel 
            {
                NameBook = book.Titulo,
                AuthorName = book.AutoresLibros?.FirstOrDefault()?.IdAutor ?? 0,
                Synopsis = book.Sinopsis,
                EditorialName = book.IdEditorial,
                Isbn = book.Isbn.ToString(),
                PagesNumber = book.NPaginas
            };
        }
    }
}
