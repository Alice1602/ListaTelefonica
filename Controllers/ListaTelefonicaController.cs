using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda_Telefonica.Models;

namespace Agenda_Telefonica.Controllers
{
    public class ListaTelefonicaController : Controller
    {
        private readonly AgendaTelefonicaDbContext _context;

        public ListaTelefonicaController(AgendaTelefonicaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        
        public async Task<IActionResult> ShowSearchResults(String TermoDeBusca)
        {
            return View("Index", await _context.ListaTelefonica.Where(f => f.Nome.Contains(TermoDeBusca)).ToListAsync());
        }

        // GET: ListaTelefonica
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListaTelefonica.ToListAsync());
        }

        // GET: ListaTelefonica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaTelefonica = await _context.ListaTelefonica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listaTelefonica == null)
            {
                return NotFound();
            }

            return View(listaTelefonica);
        }

        // GET: ListaTelefonica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListaTelefonica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone")] ListaTelefonica listaTelefonica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaTelefonica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaTelefonica);
        }

        // GET: ListaTelefonica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaTelefonica = await _context.ListaTelefonica.FindAsync(id);
            if (listaTelefonica == null)
            {
                return NotFound();
            }
            return View(listaTelefonica);
        }

        // POST: ListaTelefonica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Telefone")] ListaTelefonica listaTelefonica)
        {
            if (id != listaTelefonica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaTelefonica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaTelefonicaExists(listaTelefonica.Id))
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
            return View(listaTelefonica);
        }

        // GET: ListaTelefonica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaTelefonica = await _context.ListaTelefonica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listaTelefonica == null)
            {
                return NotFound();
            }

            return View(listaTelefonica);
        }

        // POST: ListaTelefonica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaTelefonica = await _context.ListaTelefonica.FindAsync(id);
            if (listaTelefonica != null)
            {
                _context.ListaTelefonica.Remove(listaTelefonica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaTelefonicaExists(int id)
        {
            return _context.ListaTelefonica.Any(e => e.Id == id);
        }
    }
}
