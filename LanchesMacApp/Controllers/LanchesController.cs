using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanchesMacApp.Data;
using LanchesMacApp.Models;

namespace LanchesMacApp.Controllers
{
    public class LanchesController : Controller
    {
        private readonly LanchesMacAppContext _context;

        public LanchesController(LanchesMacAppContext context)
        {
            _context = context;
        }

        // GET: Lanches
        public async Task<IActionResult> Index()
        {
            var lanchesMacAppContext = _context.Lanche.Include(l => l.Categoria);
            return View(await lanchesMacAppContext.ToListAsync());
        }

        // GET: Lanches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanche
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // GET: Lanches/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Set<Categoria>(), "CategoriaId", "CategoriaId");
            return View();
        }

        // POST: Lanches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,Estoque,CategoriaId")] Lanche lanche)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lanche);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Set<Categoria>(), "CategoriaId", "CategoriaId", lanche.CategoriaId);
            return View(lanche);
        }

        // GET: Lanches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanche.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Set<Categoria>(), "CategoriaId", "CategoriaId", lanche.CategoriaId);
            return View(lanche);
        }

        // POST: Lanches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,Estoque,CategoriaId")] Lanche lanche)
        {
            if (id != lanche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lanche);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancheExists(lanche.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Set<Categoria>(), "CategoriaId", "CategoriaId", lanche.CategoriaId);
            return View(lanche);
        }

        // GET: Lanches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = await _context.Lanche
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }

        // POST: Lanches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lanche = await _context.Lanche.FindAsync(id);
            _context.Lanche.Remove(lanche);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancheExists(int id)
        {
            return _context.Lanche.Any(e => e.Id == id);
        }
    }
}
