using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotekaMvc.Data;
using BibliotekaMvc.Models;

namespace BibliotekaMvc.Controllers
{
    public class BookInfoesController : Controller
    {
        private readonly BibliotekaContext _context;

        public BookInfoesController(BibliotekaContext context)
        {
            _context = context;
        }

        // GET: BookInfoes
        public async Task<IActionResult> Index()
        {
              return _context.BookInfo != null ? 
                          View(await _context.BookInfo.ToListAsync()) :
                          Problem("Entity set 'BibliotekaContext.BookInfo'  is null.");
        }

        // GET: BookInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookInfo == null)
            {
                return NotFound();
            }

            var bookInfo = await _context.BookInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookInfo == null)
            {
                return NotFound();
            }

            return View(bookInfo);
        }

        // GET: BookInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gatunek")] BookInfo bookInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookInfo);
        }

        // GET: BookInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookInfo == null)
            {
                return NotFound();
            }

            var bookInfo = await _context.BookInfo.FindAsync(id);
            if (bookInfo == null)
            {
                return NotFound();
            }
            return View(bookInfo);
        }

        // POST: BookInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gatunek")] BookInfo bookInfo)
        {
            if (id != bookInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookInfoExists(bookInfo.Id))
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
            return View(bookInfo);
        }

        // GET: BookInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookInfo == null)
            {
                return NotFound();
            }

            var bookInfo = await _context.BookInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookInfo == null)
            {
                return NotFound();
            }

            return View(bookInfo);
        }

        // POST: BookInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookInfo == null)
            {
                return Problem("Entity set 'BibliotekaContext.BookInfo'  is null.");
            }
            var bookInfo = await _context.BookInfo.FindAsync(id);
            if (bookInfo != null)
            {
                _context.BookInfo.Remove(bookInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookInfoExists(int id)
        {
          return (_context.BookInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
