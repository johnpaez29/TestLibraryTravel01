using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.DataService.ModelsSql
{
    public partial class Libro
    {
        public Libro()
        {
            AutoresLibros = new HashSet<AutoresLibro>();
        }

        public int Isbn { get; set; }
        public int IdEditorial { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }

        public virtual Editoriale IdEditorialNavigation { get; set; }
        public virtual ICollection<AutoresLibro> AutoresLibros { get; set; }
    }
}
