using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models
{
    public class Livro
    {
        [Key]
        public int LivroID { get; set; }

        public string Titulo { get; set; }
    }
}
