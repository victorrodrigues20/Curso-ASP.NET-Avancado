using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BibliotecaMVC.Data;

namespace BibliotecaMVC.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170923052357_AddCampoUsuario")]
    partial class AddCampoUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotecaMVC.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BibliotecaMVC.Models.Autor", b =>
                {
                    b.Property<int>("AutorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("AutorID");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("BibliotecaMVC.Models.Emprestimo", b =>
                {
                    b.Property<int>("EmprestimoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("DataDevolucao");

                    b.Property<string>("DataFim");

                    b.Property<string>("DataInicio");

                    b.Property<int>("UsuarioID");

                    b.HasKey("EmprestimoID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Emprestimo");
                });

            modelBuilder.Entity("BibliotecaMVC.Models.Livro", b =>
                {
                    b.Property<int>("LivroID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Foto");

                    b.Property<int>("Quantidade");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("LivroID");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("BibliotecaMVC.Models.LivroAutor", b =>
                {
                    b.Property<int>("AutorID");

                    b.Property<int>("LivroID");

                    b.HasKey("AutorID", "LivroID");

                    b.HasIndex("AutorID");

                    b.HasIndex("LivroID");

                    b.ToTable("LivroAutor");
                });

            modelBuilder.Entity("BibliotecaMVC.Models.LivroEmprestimo", b =>
                {
                    b.Property<int>("LivroID");

                    b.Property<int>("EmprestimoID");

                    b.HasKey("LivroID", "EmprestimoID");

                    b.HasIndex("EmprestimoID");

                    b.HasIndex("LivroID");

                    b.ToTable("LivroEmprestimo");
                });

            modelBuilder.Entity("BibliotecaMVC.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.Property<string>("Telefone");

                    b.HasKey("UsuarioID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BibliotecaMVC.Models.Emprestimo", b =>
                {
                    b.HasOne("BibliotecaMVC.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("BibliotecaMVC.Models.Usuario", "Usuario")
                        .WithMany("Emprestimo")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BibliotecaMVC.Models.LivroAutor", b =>
                {
                    b.HasOne("BibliotecaMVC.Models.Autor", "Autor")
                        .WithMany("LivroAutor")
                        .HasForeignKey("AutorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaMVC.Models.Livro", "Livro")
                        .WithMany("LivroAutor")
                        .HasForeignKey("LivroID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BibliotecaMVC.Models.LivroEmprestimo", b =>
                {
                    b.HasOne("BibliotecaMVC.Models.Emprestimo", "Emprestimo")
                        .WithMany("LivroEmprestimo")
                        .HasForeignKey("EmprestimoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaMVC.Models.Livro", "Livro")
                        .WithMany("LivroEmprestimo")
                        .HasForeignKey("LivroID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BibliotecaMVC.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BibliotecaMVC.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaMVC.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
