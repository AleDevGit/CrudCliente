using CrudCliente.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CrudCliente.Repositorio.Context
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Cliente> Clientes{get; set;}
        public DbSet<Endereco> Enderecos{get; set;}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.CPF)
                    .HasColumnName("CPF")
                    .HasMaxLength(15)
                    .IsUnicode(false).IsRequired();

                entity.Property(e => e.Nome)
                    .HasColumnName("Nome")
                    .HasMaxLength(30)
                    .IsUnicode(false).IsRequired();

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DataNascimento")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired();
            });
             modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Bairro)
                    .HasColumnName("Bairro")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Cidade)
                    .HasColumnName("Cidade")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Estado)
                .HasColumnName("Estado")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsRequired();
            });
        }
    }
    
}