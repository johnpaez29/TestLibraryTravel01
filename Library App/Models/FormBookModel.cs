using System.ComponentModel.DataAnnotations;

namespace Library_App.Models
{
    public class FormBookModel
    {
        public string Isbn { get; set; }
        [Required]
        public string NameBook { get; set; }
        [Required]
        public string Synopsis { get; set; }

        [Required]
        public string PagesNumber { get; set; }

        [Required]
        public int? EditorialName { get; set; }

        public int? AuthorName { get; set; }
    }
}
