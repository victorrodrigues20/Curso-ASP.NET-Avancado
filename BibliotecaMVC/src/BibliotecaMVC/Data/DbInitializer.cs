using BibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Se existir algum livro
            if (context.Livro.Any())
            {
                return;   // DB possui registros
            }

            var livros = new Livro[]
            {
                new Livro {Titulo = "PHP para quem conhece PHP",Quantidade = 10},
                new Livro {Titulo = "Internet das Coisas com ESP8266, Arduino e Raspberry",Quantidade = 10},
                new Livro {Titulo = "Gamification em Help Desk e Service Desk",Quantidade = 10},
                new Livro {Titulo = "Avaliação de segurança de redes",Quantidade = 10},
                new Livro {Titulo = "Desenvolvendo Jogos Mobile com HTML5",Quantidade = 10}
            };

            foreach (Livro l in livros)
            {
                context.Livro.Add(l);
            }

            var autores = new Autor[]
            {
                new Autor { Nome = "Sérgio de Oliveira" },
                new Autor { Nome = "Renato da Silva"},
                new Autor { Nome = "Paulo Sérgio Travolla"},
                new Autor { Nome = "Juliano Niederauer"},
                new Autor { Nome = "Roberto Cohen"},
                new Autor { Nome = "Chris McNab"},
                new Autor { Nome = "Luiz Fernando Estevarengo"}
            };

            foreach (Autor a in autores)
            {
                context.Autor.Add(a);
            }

            context.SaveChanges();
        }
    }
}
