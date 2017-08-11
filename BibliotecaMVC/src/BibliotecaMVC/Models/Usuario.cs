using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaMVC.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        public int? CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<SistemaUsuario> SistemaUsuarios { get; set; }
    }
}
