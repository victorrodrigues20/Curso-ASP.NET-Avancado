using BibliotecaMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BibliotecaMVC.Utils
{
    public class Listagens
    {
        private readonly ApplicationDbContext _context;

        public Listagens(ApplicationDbContext context)
        {
            this._context = context;
        }

        public SelectList Autores()
        {
            var qry = from a in _context.Autor.AsNoTracking()
                      orderby a.Nome
                      select new
                      {
                          a.AutorID,
                          a.Nome
                      };

            return new SelectList(qry.ToList(), "AutorID", "Nome");
        }

        public List<CheckBoxItemList> AutoresCheckBox()
        {
            var qry = from a in _context.Autor.AsNoTracking()
                      orderby a.Nome
                      select new CheckBoxItemList
                      {
                          Value = a.AutorID,
                          Text = a.Nome
                      };

            return qry.ToList();
        }
    }
}
