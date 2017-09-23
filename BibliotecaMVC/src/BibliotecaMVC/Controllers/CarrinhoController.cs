using BibliotecaMVC.Data;
using BibliotecaMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarrinhoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Carrinho
        public ActionResult Index()
        {
            if (GetCarrinho() == null)
                SetCarrinho(new List<Livro>());

            //ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            return View(GetCarrinho());
        }

        // GET: Carrinho
        public ActionResult Adicionar(int? id)
        {
            List<Livro> listaLivros = GetCarrinho();

            var livro = _context.Livro.FirstOrDefault(x => x.LivroID == id);

            listaLivros.Add(livro);
            SetCarrinho(listaLivros);

            return View("Index", GetCarrinho());
        }

        // POST: EmprestarLivros
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmprestarLivros()
        {
            // Verificamos se o usuário está logado
            if (User.Identity.IsAuthenticated)
            {

                // Pegar ID do Usuário
                var userID = _userManager.GetUserId(HttpContext.User);

                // Criar empréstimo
                Emprestimo emprestimo = new Emprestimo()
                {
                    ApplicationUserId = userID,
                    DataInicio = DateTime.Now.ToString("dd/MM/yyyy"),
                    DataFim = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"),
                    UsuarioID = 1, // Fixo p/ não dar erro
                    LivroEmprestimo = new List<LivroEmprestimo>()
                };

                // Resgatar lista de livros no carrinho
                List<Livro> listaLivros = GetCarrinho();

                // Inserir a lista de livros na tabela LivroEmprestimo
                foreach (var item in listaLivros)
                {
                    LivroEmprestimo livroEmprestimo = new LivroEmprestimo();
                    livroEmprestimo.LivroID = item.LivroID;
                    livroEmprestimo.Emprestimo = emprestimo;

                    emprestimo.LivroEmprestimo.Add(livroEmprestimo);
                }

                // Inserir o novo empréstimo na tabela
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
            }
            return View("Index", GetCarrinho());
        }

        private List<Livro> GetCarrinho()
        {
            string carrinhoStr = HttpContext.Session.GetString("Carrinho");

            if (carrinhoStr == null)
                return new List<Livro>();

            return JsonConvert.DeserializeObject<List<Livro>>(carrinhoStr);
        }

        private void SetCarrinho(List<Livro> carrinho)
        {
            string carrinhoStr = JsonConvert.SerializeObject(carrinho);
            HttpContext.Session.SetString("Carrinho", carrinhoStr);
        }


    }
}