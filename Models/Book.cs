using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BibliotekaMvc.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string? Tytul { get; set; }
        public int? BookInfoId { get; set; }
        [ForeignKey("BookInfoId")]
        [Display(Name = "Gatunek")]
        public BookInfo? BookInfo { get; set; }
        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
		[Display(Name = "Autor")]
		public Author? Author { get; set; }
        public ICollection<User>? User { get; set; }
        

    }
}
