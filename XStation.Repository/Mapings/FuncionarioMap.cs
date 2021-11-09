using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;

namespace XStation.Repository.Mapings
{

    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(p => p.IdFuncionario);

            builder.Property(p => p.IdFuncionario).HasColumnName("IdFuncionario").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
            builder.Property(p => p.Cpf).HasColumnName("Cpf").HasMaxLength(11).IsRequired();
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(150).IsRequired();
            builder.Property(p => p.Senha).HasColumnName("Senha").HasMaxLength(150).IsRequired();
            builder.Property(p => p.Telefone1).HasColumnName("Telefone1").HasMaxLength(11).IsRequired();
            builder.Property(p => p.Telefone2).HasColumnName("Telefone2").HasMaxLength(11).IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnName("DataCriacao").IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnName("DataNascimento").IsRequired();


            builder.HasOne(u => u.Perfil) //Usuario TEM 1 Perfil
                .WithMany(p => p.Funcionarios) //Perfil TEM MUITOS Usuarios
                .HasForeignKey(u => u.IdPerfil); //chave estrangeira
        }
    }
}
