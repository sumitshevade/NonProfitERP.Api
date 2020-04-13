using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;

namespace App.Controllers
{
    [Authorize]
    public class HeadersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Headers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Headers.Where(x => x.DeletedById == null).ToListAsync());
        }

        // GET: Headers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var header = await _context.Headers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (header == null)
            {
                return NotFound();
            }

            return View(header);
        }

        // GET: Headers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Headers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title")] Header header)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                header.CreatedAt = DateTime.Now;
                header.CreatedById = userId;

                _context.Add(header);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(header);
        }

        // GET: Headers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var header = await _context.Headers.FindAsync(id);
            if (header == null)
            {
                return NotFound();
            }
            return View(header);
        }

        // POST: Headers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,UpdatedById,UpdatedAt")] Header header)
        public async Task<IActionResult> Edit(int id, [FromForm] Header header)
        {
            if (id != header.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    header.UpdatedAt = DateTime.Now;
                    header.UpdatedById = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    var excluded = new[] { "Id", "CreatedAt", "CreatedById", "DeletedById", "DeletedAt" };
                    var entry = _context.Entry(header);
                    entry.State = EntityState.Modified;
                    foreach (var property in excluded)
                    {
                        entry.Property(property).IsModified = false;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeaderExists(header.Id))
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
            return View(header);
        }

        // GET: Headers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var header = await _context.Headers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (header == null)
            {
                return NotFound();
            }

            return View(header);
        }

        // POST: Headers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var header = await _context.Headers.FindAsync(id);
            header.DeletedById = User.FindFirstValue(ClaimTypes.NameIdentifier);
            header.DeletedAt = DateTime.Now;
            var excluded = new[] { "Id", "Title", "CreatedAt", "CreatedById", "UpdatedById", "UpdatedAt" };
            var entry = _context.Entry(header);
            entry.State = EntityState.Modified;
            foreach (var property in excluded)
            {
                entry.Property(property).IsModified = false;
            }

            //_context.Headers.Remove(header);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeaderExists(int id)
        {
            return _context.Headers.Any(e => e.Id == id);
        }
    }
}
