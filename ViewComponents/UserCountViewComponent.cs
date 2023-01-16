using BibliotekaMvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaMvc.ViewComponents
{
    public class UserCountViewComponent : ViewComponent
    {
        private readonly BibliotekaContext _context;
        public UserCountViewComponent(BibliotekaContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var liczba = _context.User.Count();
            ViewData["userCount"] = liczba;
            return View("Component");
        }
    }
}
