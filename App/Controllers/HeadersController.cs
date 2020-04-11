using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{
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
            var applicationDbContext = _context.Headers.Include(h => h.Organization);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Headers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var header = await _context.Headers
                .Include(h => h.Organization)
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Id,CreatedById")] Header header)
        {
            if (ModelState.IsValid)
            {
                var orgId = User.Claims.Where(x => x.Type == "OrganizationId").Select(c => c.Value).FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(orgId))
                {
                    header.OrganizationId = Convert.ToInt32(orgId);
                    header.CreatedById = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    _context.Add(header);
                    await _context.SaveChangesAsync();
                }
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
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "UpdatedById", header.OrganizationId);
            return View(header);
        }

        // POST: Headers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Id,UpdatedById")] Header header)
        {
            if (id != header.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(header);
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
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "CreatedById", header.OrganizationId);
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
                .Include(h => h.Organization)
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
            _context.Headers.Remove(header);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeaderExists(int id)
        {
            return _context.Headers.Any(e => e.Id == id);
        }
    }
}
