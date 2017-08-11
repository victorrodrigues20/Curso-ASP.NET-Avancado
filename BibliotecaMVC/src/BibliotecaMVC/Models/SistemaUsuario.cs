using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models
{
    public class SistemaUsuario
    {
        public int SistemaID { get; set; }
        public Sistema Sistemas { get; set; }

        public int UsuarioID { get; set; }
        public Usuario Usuarios { get; set; }
    }
}
