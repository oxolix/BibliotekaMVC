using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotekaMvc.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Imie")]
        public string? AutorImie { get; set; }
        [Display(Name = "Nazwisko")]
        public string? AutorNazwisko { get; set; }
        public ICollection<Book>? Books { get; set; }
        public string FullAutorName
        {
            get
            {
                return AutorImie + " " + AutorNazwisko;
            }
        }
    }
}
