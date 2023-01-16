using BibliotekaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaMvc.Data
{
    public class BibliotekaContext :DbContext
    {
        public BibliotekaContext(DbContextOptions<BibliotekaContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; } = default!;
        public DbSet<UserAddress> UserAddress { get; set; } = default!;
        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<BookInfo> BookInfo { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<BookUser> BookUser { get; set; } = default!;
    }
}
