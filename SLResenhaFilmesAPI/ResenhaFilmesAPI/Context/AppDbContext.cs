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

        public DbSet<AdministradorModel> Administradores { get; set; }

        public DbSet<VisitanteModel> Visitantes { get; set; }

        public DbSet<FilmeModel> Filmes { get; set; }

        public DbSet<ResenhaModel> Resenhas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //configurações de tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //nome da tabela banco
            modelBuilder.Entity<VisitanteModel>().ToTable("Visitantes");
            modelBuilder.Entity<VisitanteModel>().HasKey(x => x.Id);
            modelBuilder.Entity<VisitanteModel>()
               .HasIndex(v => v.Email)
               .IsUnique();
            modelBuilder.Entity<VisitanteModel>().Property(x => x.Nome).IsRequired();
            modelBuilder.Entity<VisitanteModel>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<VisitanteModel>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<VisitanteModel>().Property(x => x.Senha).IsRequired();


            modelBuilder.Entity<AdministradorModel>().ToTable("Administradores");
            modelBuilder.Entity<AdministradorModel>().HasKey(x => x.Id);
            modelBuilder.Entity<AdministradorModel>()
               .HasIndex(v => v.Email)
               .IsUnique();
            modelBuilder.Entity<AdministradorModel>().Property(x => x.Nome).IsRequired();
            modelBuilder.Entity<AdministradorModel>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<AdministradorModel>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<AdministradorModel>().Property(x => x.Senha).IsRequired();


            //nome da tabela banco
            modelBuilder.Entity<ResenhaModel>()
                .ToTable("Resenhas")
                .HasOne(r => r.Visitante)
                .WithMany(v => v.Resenhas)
                .HasForeignKey(r => r.IdVisitante)
                .HasConstraintName("Fk_Visitante_Resenha");

            modelBuilder.Entity<ResenhaModel>()
              .ToTable("Resenhas")
              .HasOne(r => r.Filme )
              .WithMany(f => f.Resenhas)
              .HasForeignKey(r => r.IdFilme)
              .HasConstraintName("Fk_Filme_Resenha");
            modelBuilder.Entity<ResenhaModel>().HasKey(x => x.Id);

            modelBuilder.Entity<FilmeModel>()
                .ToTable("Filmes");
            modelBuilder.Entity<FilmeModel>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<FilmeModel>().Property(x => x.Titulo).IsRequired();
            modelBuilder.Entity<FilmeModel>().Property(x => x.Genero).IsRequired();
            modelBuilder.Entity<FilmeModel>().Property(x => x.Ano).IsRequired();
        }
    }
}
