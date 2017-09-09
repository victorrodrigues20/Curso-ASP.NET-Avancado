using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.ViewComponents
{
    public class ListagemLivrosViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ListagemLivrosViewComponent(ApplicationDbContext c)
        {
            _context = c;
        }

        public async Task<IViewComponentResult> InvokeAsync(int autorID)
        {
            var produtos = await GetListagemLivrosAsync(autorID);
            return View(produtos);
        }

        private Task<IEnumerable<Livro>> GetListagemLivrosAsync(int autorID)
        {
            var livros = _context.Livro.AsNoTracking()
                        .Include(l => l.LivroAutor)
                        .ThenInclude(li => li.Autor)
                        .OrderBy(l => l.Titulo);

            if (autorID != 0)
                livros.Where(x => x.LivroAutor.Any(y => y.AutorID == autorID));

            return Task.FromResult(livros.AsEnumerable());
        }
    }
}
