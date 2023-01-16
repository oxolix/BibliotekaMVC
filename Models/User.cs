using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaMvc.Models
{
    [Table("Users")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Email { get; set; }
        public UserAddress? Address { get; set; }
        public ICollection<BookUser>? BookUsers { get; set; }

        public string FullUserName
        {
            get
            {
                return Imie + " " + Nazwisko;
            }

        }
    }
}
