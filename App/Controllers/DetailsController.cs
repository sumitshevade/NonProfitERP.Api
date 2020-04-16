using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using Model;

namespace App.Controllers
{
    [Authorize]
    public class DetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Details.Include(d => d.Header);
            return View(await applicationDbContext.Where(x => x.DeletedById == null).ToListAsync());
        }

        // GET: Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details
                .Include(d => d.Header)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            ViewData["HeaderId"] = new SelectList(_context.Headers, "Id", "Title");
            return View();
        }

        // POST: Details/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeaderId,Value,ExtraField")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                detail.CreatedById = User.FindFirstValue(ClaimTypes.NameIdentifier);
                detail.CreatedAt = DateTime.Now;

                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HeaderId"] = new SelectList(_context.Headers, "Id", "CreatedById", detail.HeaderId);
            return View(detail);
        }

        // GET: Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            ViewData["HeaderId"] = new SelectList(_context.Headers, "Id", "Title", detail.HeaderId);
            return View(detail);
        }

        // POST: Details/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Detail detail)
        {
            if (id != detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(detail);

                    detail.UpdatedAt = DateTime.Now;
                    detail.UpdatedById = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    var excluded = new[] { "Id", "CreatedAt", "CreatedById", "DeletedById", "DeletedAt" };
                    var entry = _context.Entry(detail);
                    entry.State = EntityState.Modified;
                    foreach (var property in excluded)
                    {
                        entry.Property(property).IsModified = false;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExists(detail.Id))
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
            ViewData["HeaderId"] = new SelectList(_context.Headers, "Id", "CreatedById", detail.HeaderId);
            return View(detail);
        }

        // GET: Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details
                .Include(d => d.Header)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail = await _context.Details.FindAsync(id);
            
            detail.DeletedAt = DateTime.Now;
            detail.DeletedById = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var excluded = new[] { "Id", "HeaderId", "Value", "ExtraField", "CreatedAt", "CreatedById", "UpdatedById", "UpdatedAt" };
            var entry = _context.Entry(detail);
            entry.State = EntityState.Modified;
            foreach (var property in excluded)
            {
                entry.Property(property).IsModified = false;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailExists(int id)
        {
            return _context.Details.Any(e => e.Id == id);
        }
    }
}
