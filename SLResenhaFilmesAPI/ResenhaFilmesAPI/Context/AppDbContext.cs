using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ResenhaFilmesAPI.Context
{
    //classe resposavel por fazer a ponte entre as entidades criadas na models
    // com o banco de dados MySql para isso ela tem que herdar da classe.

    //IdentityUser é um tipo que vai representar o usuário.
    //Representa um usuário do Identity contendo varias propriedades padrão como PasswordHas.
    //para usar esse recurso vá para pasta Program.cs para habilitar o Identity
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        // representa as tabelas das classes criadas na Models
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<FilmeModel> Filmes { get; set; }

        public DbSet<ResenhaModel> Resenhas { get; set; }

        //Definindo um contrutor com a opção DbContextOptions passando para classe base que options
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Definindo os mapeamentos que as entidades criadas na Pasta models
        //Filme, Resenha, Usuário tem que ser meapeada para uma tabela com o nome que vamos definir.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>().ToTable("Usuarios");
            modelBuilder.Entity<UsuarioModel>().HasKey(x => x.UsuarioModelId);
            modelBuilder.Entity<UsuarioModel>()
                .HasIndex(v => v.Email)
                .IsUnique();
            modelBuilder.Entity<UsuarioModel>().Property(x => x.Nome).IsRequired().HasMaxLength(80);
            modelBuilder.Entity<UsuarioModel>().Property(x => x.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<UsuarioModel>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<UsuarioModel>().Property(x => x.Senha).IsRequired();

            // Configurações para a entidade ResenhaModel
            modelBuilder.Entity<ResenhaModel>().ToTable("Resenhas");
            modelBuilder.Entity<ResenhaModel>().HasKey(x => x.Id);
            modelBuilder.Entity<ResenhaModel>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Resenhas)
                .HasForeignKey(r => r.UsuarioModelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResenhaModel>()
                .HasOne(r => r.Filme)
                .WithMany(f => f.Resenhas)
                .HasForeignKey(r => r.IdFilme)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurações para a entidade FilmeModel
            modelBuilder.Entity<FilmeModel>().ToTable("Filmes");
            modelBuilder.Entity<FilmeModel>().HasKey(x => x.FilmeModelId);
            modelBuilder.Entity<FilmeModel>().Property(x => x.Titulo);
            modelBuilder.Entity<FilmeModel>().Property(x => x.Genero);
            modelBuilder.Entity<FilmeModel>().Property(x => x.Ano);


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FilmeModel>().HasData( 
                new FilmeModel
                {
                   FilmeModelId = 1,
                   Titulo = "A mão que balança o berço",
                   Genero = "Terror",
                   Ano = "1999"
                },
                new FilmeModel
                {
                    FilmeModelId = 1,
                    Titulo = "Ursinho pool",
                    Genero = "Desenho",
                    Ano = "1990"

                }
                
                );


            
        }
    }
}
