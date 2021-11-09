using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;
using XStation.Repository.Mapings;

namespace XStation.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Perfil> Perfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento
            modelBuilder.ApplyConfiguration(new ClientesMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());

            //mapeando os campos UNIQUE de cada tabela..
            modelBuilder.Entity<Cliente>(entity => {
                entity.HasIndex(u => u.Cpf).IsUnique();
            });

            modelBuilder.Entity<Cliente>(entity => {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Funcionario>(entity => {
                entity.HasIndex(p => p.Cpf).IsUnique();
            });
            modelBuilder.Entity<Funcionario>(entity => {
                entity.HasIndex(p => p.Email).IsUnique();
            });
        }
    }
}

