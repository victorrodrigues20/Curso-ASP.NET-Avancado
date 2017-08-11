using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaMVC.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }

        [StringLength(300)]
        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
