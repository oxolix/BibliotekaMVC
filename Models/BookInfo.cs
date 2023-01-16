using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaMvc.Models
{
    public class BookInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Gatunek { get; set; }
        public ICollection<Book>? Books { get; set; }


    }
}
