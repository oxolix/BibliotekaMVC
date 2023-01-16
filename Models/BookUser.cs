using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaMvc.Models
{
    public class BookUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }
        public DateTime? DataWyp { get; set; }= DateTime.Now;
        public DateTime? DataOd { get; set; }
        public ICollection<Book>? Books { get; set; }
        
    }
}
