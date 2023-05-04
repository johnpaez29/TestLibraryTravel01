using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Model.DTO
{
    public class BookDto
    {
        public int? Isbn { get; set; }

        public string NameBook { get; set; }

        public int? EditorialId { get; set; }

        public int? AuthorId { get; set; }

        public string EditorialNombre { get; set; }

        public string AuthorNombre { get; set; }
    }
}
