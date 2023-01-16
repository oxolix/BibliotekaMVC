using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BibliotekaMvc.Models
{
    [Table("UserAddresses")]
    public class UserAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Użytkownik")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public string? Miasto { get; set; }
        public string? Ulica { get; set; }
        [DisplayName("Nr Domu")]
        public int? NrDomu { get; set; }
        [MinLength(9), MaxLength(9)]
        [DisplayName("Nr Telefonu")]
        public string? NrTelefonu { get; set; }

    }
}
