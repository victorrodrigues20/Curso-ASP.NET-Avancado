using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models
{
    public class Emprestimo
    {
        [Key]
        public int EmprestimoID { get; set; }

        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public string DataDevolucao { get; set; }

        public ICollection<LivroEmprestimo> LivroEmprestimo { get; set; }
    }
}
