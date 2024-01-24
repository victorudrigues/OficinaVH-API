using Microsoft.EntityFrameworkCore;
using OficinaVH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaVH.Infra.Infrastructure.OficinaContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
           
        }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cliente).IsRequired();

                entity.HasMany(e => e.Carros).WithOne(c => c.Clientes).HasForeignKey(c => c.ClienteID);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Produto).IsRequired();
                entity.Property(e => e.Valor).IsRequired();
                entity.HasOne(e => e.Carro).WithMany(c => c.Produtos).HasForeignKey(e => e.Id);
            });

            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Modelo).IsRequired();
                entity.Property(e => e.Placa).IsRequired();
                entity.Property(e => e.Ano).IsRequired(false);
                entity.HasOne(e => e.Clientes).WithMany(c => c.Carros).HasForeignKey(e => e.ClienteID);
            });
        }
    }
}
