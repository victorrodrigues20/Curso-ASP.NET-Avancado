using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models
{
    public class Sistema
    {
        [Key]
        public int SistemaID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<SistemaUsuario> SistemaUsuarios { get; set; }
    }
}
