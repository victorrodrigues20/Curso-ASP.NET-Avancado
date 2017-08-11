using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SistemaUsuario>()
                .HasKey(bc => new { bc.SistemaID, bc.UsuarioID });

            builder.Entity<SistemaUsuario>()
                .HasOne(bc => bc.Sistemas)
                .WithMany(b => b.SistemaUsuarios)
                .HasForeignKey(bc => bc.SistemaID);

            builder.Entity<SistemaUsuario>()
                .HasOne(bc => bc.Usuarios)
                .WithMany(c => c.SistemaUsuarios)
                .HasForeignKey(bc => bc.UsuarioID);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            base.OnModelCreating(builder);
        }

        public DbSet<Livro> Livro { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Sistema> Sistema { get; set; }
    }
}
