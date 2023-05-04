using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.DataService.ModelsSql
{
    public partial class AutoresLibro
    {
        public int IdAutorLibro { get; set; }
        public int IdAutor { get; set; }
        public int LibroIsbn { get; set; }

        public virtual Autore IdAutorNavigation { get; set; }
        public virtual Libro LibroIsbnNavigation { get; set; }
    }
}
