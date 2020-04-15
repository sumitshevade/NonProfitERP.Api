using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using App.Repository.Implementations;
using App.Services.Contracts;
using App.Services.Implementations;

namespace App.Controllers
{
    [Authorize]
    public class HeadersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHeaderService _headerService;

        public HeadersController(ApplicationDbContext context, IHeaderService headerService)
        {
            _context = context;
            _headerService = headerService;
        }

        // GET: Headers
        public async Task<IActionResult> Index()
        {
            return View(await _headerService.FindAsync());
        }

        // GET: Headers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var header = await _headerService.GetAsync(id.Value);
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
        public async Task<IActionResult> Create([FromForm] Header header)
        {
            if (ModelState.IsValid)
            {
                await _headerService.PostAsync(header, User);
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

            var header = await _headerService.GetAsync(id.Value);
            if (header == null)
            {
                return NotFound();
            }
            return View(header);
        }

        // POST: Headers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    await _headerService.UpdateAsync(id, header, User);
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

            var header = await _headerService.GetAsync(id.Value);
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
            await _headerService.DeleteAsync(id, User);
            return RedirectToAction(nameof(Index));
        }

        private bool HeaderExists(int id)
        {
            return _context.Headers.Any(e => e.Id == id);
        }
    }
}
