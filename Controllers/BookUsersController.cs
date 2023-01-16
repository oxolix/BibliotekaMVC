using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotekaMvc.Data;
using BibliotekaMvc.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace BibliotekaMvc.Controllers
{
    public class BookUsersController : Controller
    {
        private readonly BibliotekaContext _context;

        public BookUsersController(BibliotekaContext context)
        {
            _context = context;
        }

        // GET: BookUsers
        public async Task<IActionResult> Index(string searchUser)
        {    

            var bookUsers = _context.BookUser.Include(b => b.Book).Include(b => b.User);
            return View(await bookUsers.ToListAsync());
        }

        // GET: BookUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookUser == null)
            {
                return NotFound();
            }

            var bookUser = await _context.BookUser
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookUser == null)
            {
                return NotFound();
            }

            return View(bookUser);
        }

        // GET: BookUsers/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Tytul");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullUserName");
            return View();
        }

        // POST: BookUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,BookId,DataWyp,DataOd")] BookUser bookUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Tytul", bookUser.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullUserName", bookUser.UserId);
            return View(bookUser);
        }

        // GET: BookUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookUser == null)
            {
                return NotFound();
            }

            var bookUser = await _context.BookUser.FindAsync(id);
            if (bookUser == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Tytul", bookUser.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullUserName", bookUser.UserId);
            return View(bookUser);
        }

        // POST: BookUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BookId,DataWyp,DataOd")] BookUser bookUser)
        {
            if (id != bookUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookUserExists(bookUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Tytul", bookUser.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullUserName", bookUser.UserId);
            return View(bookUser);
        }

        // GET: BookUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookUser == null)
            {
                return NotFound();
            }

            var bookUser = await _context.BookUser
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookUser == null)
            {
                return NotFound();
            }

            return View(bookUser);
        }

        // POST: BookUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookUser == null)
            {
                return Problem("Entity set 'BibliotekaContext.BookUser'  is null.");
            }
            var bookUser = await _context.BookUser.FindAsync(id);
            if (bookUser != null)
            {
                _context.BookUser.Remove(bookUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookUserExists(int id)
        {
          return (_context.BookUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
