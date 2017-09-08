using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaMVC.Data;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Livros
        public async Task<IActionResult> Index(string filtroPesquisa, string ordenacao)
        {
            ViewBag.TituloSortParm = String.IsNullOrEmpty(ordenacao) ? "titulo_desc" : "";

            ViewBag.filtroPesquisa = filtroPesquisa;

            var livros = from l in _context.Livro
                         select l;

            if (!String.IsNullOrEmpty(filtroPesquisa))
            {
                livros = livros.Where(s => s.Titulo.ToUpper().Contains(filtroPesquisa.ToUpper()));
            }

            switch (ordenacao)
            {
                case "titulo_desc":
                    livros = livros.OrderByDescending(s => s.Titulo);
                    break;
                default:
                    livros = livros.OrderBy(s => s.Titulo);
                    break;
            }

            return View(await livros.ToListAsync());
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.SingleOrDefaultAsync(m => m.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivroID,Quantidade,Titulo")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.SingleOrDefaultAsync(m => m.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LivroID,Quantidade,Titulo")] Livro livro)
        {
            if (id != livro.LivroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.LivroID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.SingleOrDefaultAsync(m => m.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livro.SingleOrDefaultAsync(m => m.LivroID == id);
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.LivroID == id);
        }
    }
}
