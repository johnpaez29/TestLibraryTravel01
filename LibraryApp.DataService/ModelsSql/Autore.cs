using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.DataService.ModelsSql
{
    public partial class Autore
    {
        public Autore()
        {
            AutoresLibros = new HashSet<AutoresLibro>();
        }

        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public virtual ICollection<AutoresLibro> AutoresLibros { get; set; }
    }
}
