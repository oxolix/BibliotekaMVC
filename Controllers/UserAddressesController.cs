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
    public class UserAddressesController : Controller
    {
        private readonly BibliotekaContext _context;

        public UserAddressesController(BibliotekaContext context)
        {
            _context = context;
        }

        // GET: UserAddresses
        public async Task<IActionResult> Index()
        {
            var bibliotekaContext = _context.UserAddress.Include(u => u.User);
            return View(await bibliotekaContext.ToListAsync());
        }

        // GET: UserAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserAddress == null)
            {
                return NotFound();
            }

            var userAddress = await _context.UserAddress
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAddress == null)
            {
                return NotFound();
            }

            return View(userAddress);
        }

        // GET: UserAddresses/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullUserName");
            return View();
        }

        // POST: UserAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Miasto,Ulica,NrDomu,NrTelefonu")] UserAddress userAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullUserName", userAddress.UserId);
            return View(userAddress);
        }

        // GET: UserAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserAddress == null)
            {
                return NotFound();
            }

            var userAddress = await _context.UserAddress.FindAsync(id);
            if (userAddress == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullUserName", userAddress.UserId);
            return View(userAddress);
        }

        // POST: UserAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Miasto,Ulica,NrDomu,NrTelefonu")] UserAddress userAddress)
        {
            if (id != userAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAddressExists(userAddress.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FullUserName", userAddress.UserId);
            return View(userAddress);
        }

        // GET: UserAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserAddress == null)
            {
                return NotFound();
            }

            var userAddress = await _context.UserAddress
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAddress == null)
            {
                return NotFound();
            }

            return View(userAddress);
        }

        // POST: UserAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserAddress == null)
            {
                return Problem("Entity set 'BibliotekaContext.UserAddress'  is null.");
            }
            var userAddress = await _context.UserAddress.FindAsync(id);
            if (userAddress != null)
            {
                _context.UserAddress.Remove(userAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAddressExists(int id)
        {
          return (_context.UserAddress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
