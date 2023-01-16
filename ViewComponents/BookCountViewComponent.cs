using BibliotekaMvc.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace BibliotekaMvc.ViewComponents
{
    public class BookCountViewComponent:ViewComponent
    {
        private readonly BibliotekaContext _context;
        public BookCountViewComponent(BibliotekaContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var liczba = _context.Book.Count();
            ViewData["bookCount"] = liczba;
            return View("Component");
        }

    }
}
