using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Models;

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

            //setando uma chave primeiro
            modelBuilder.Entity<VisitanteModel>().HasKey(x => x.Id);


            //
            modelBuilder.Entity<AdministradorModel>().ToTable("Administradores");

            //setando uma chave primeiro
            modelBuilder.Entity<AdministradorModel>().HasKey(x => x.Id);


            //nome da tabela banco
            modelBuilder.Entity<ResenhaModel>().ToTable("Resenhas");

            //setando uma chave primeiro
            modelBuilder.Entity<ResenhaModel>().HasKey(x => x.Id);



        }
    }
}
