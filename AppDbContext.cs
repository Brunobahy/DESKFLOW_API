using DeskFlow.Models;

using Microsoft.EntityFrameworkCore;

namespace DeskFlow
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Categoria> Categoria => Set<Categoria>();
        public DbSet<Chamado> Chamado => Set<Chamado>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(categoria =>
            {

                categoria.ToTable("Tb_Categoria");

                categoria.HasKey(c => c.Id);
                categoria.Property(c => c.Id)
                .HasColumnName("IdCategoria")
                .HasColumnType("varchar(50)");

                categoria.Property(c => c.Nome)
                .HasColumnName("NomeCategoria")
                .HasColumnType("varchar(150)");
            });

            modelBuilder.Entity<Chamado>(chamado =>
            {
                chamado.HasKey(c => c.Id);

                chamado.Property(c => c.Titulo)
                .HasColumnName("TituloChamado")
                .HasColumnType("varchar(250)");

                chamado.Property(c => c.Descricao)
                .HasColumnName("DescricaoChamado")
                .HasColumnType("varchar(500)");

                chamado.Property(c => c.Prioridade)
                .HasColumnName("PrioridadeChamado")
                .HasColumnType("varchar(50)");

                chamado.Property(c => c.Status)
                .HasColumnName("StatusChamado")
                .HasColumnType("varchar(50)");

                chamado.Property(c => c.SolicitanteNome)
                .HasColumnName("SolicitanteChamado")
                .HasColumnType("varchar(150)");

                chamado.Property(c => c.Solucao)
                .HasColumnName("SolucaoChamado")
                .HasColumnType("varchar(500)");

            });

        }
    }

}