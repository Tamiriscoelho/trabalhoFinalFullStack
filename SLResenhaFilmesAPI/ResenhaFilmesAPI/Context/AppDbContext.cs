using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Models;
using System.IO;

namespace ResenhaFilmesAPI.Context
{
    //Herdar da classe DbContext EntityFramework
    //App representa o banco
    public class AppDbContext : DbContext

    {

        // representa as tabelas  das classes criadas na Models
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<FilmeModel> Filmes { get; set; }

        public DbSet<ResenhaModel> Resenhas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //configurações de tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>().ToTable("Usuarios");
            modelBuilder.Entity<UsuarioModel>().HasKey(x => x.IdUsuario);
            modelBuilder.Entity<UsuarioModel>()
                .HasIndex(v => v.Email)
                .IsUnique();
            modelBuilder.Entity<UsuarioModel>().Property(x => x.Nome).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(x => x.Senha).IsRequired();

            // Configurações para a entidade ResenhaModel
            modelBuilder.Entity<ResenhaModel>().ToTable("Resenhas");
            modelBuilder.Entity<ResenhaModel>().HasKey(x => x.Id);
            modelBuilder.Entity<ResenhaModel>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Resenhas)
                .HasForeignKey(r => r.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResenhaModel>()
                .HasOne(r => r.Filme)
                .WithMany(f => f.Resenhas)
                .HasForeignKey(r => r.IdFilme)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurações para a entidade FilmeModel
            modelBuilder.Entity<FilmeModel>().ToTable("Filmes");
            modelBuilder.Entity<FilmeModel>().HasKey(x => x.IdFilme);
            modelBuilder.Entity<FilmeModel>().Property(x => x.Titulo);
            modelBuilder.Entity<FilmeModel>().Property(x => x.Genero);
            modelBuilder.Entity<FilmeModel>().Property(x => x.Ano);
        }
    }
}
