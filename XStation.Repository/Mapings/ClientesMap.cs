using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;

namespace XStation.Repository.Mapings
{

    public class ClientesMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(p => p.IdCliente);

            builder.Property(p => p.IdCliente).HasColumnName("IdCliente").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
            builder.Property(p => p.Cpf).HasColumnName("Cpf").HasMaxLength(11).IsRequired();
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(150).IsRequired();
            builder.Property(p => p.Senha).HasColumnName("Senha").HasMaxLength(150).IsRequired();
            builder.Property(p => p.Telefone1).HasColumnName("Telefone1").HasMaxLength(11).IsRequired();
            builder.Property(p => p.Telefone2).HasColumnName("Telefone2").HasMaxLength(11).IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnName("DataCriacao").IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnName("DataNascimento").IsRequired();                                    
            builder.Property(p => p.DataNascimento).HasColumnName("DataNascimento").IsRequired();


            builder.HasOne(u => u.Perfil) //Usuario TEM 1 Perfil
                .WithMany(p => p.Clientes) //Perfil TEM MUITOS Usuarios
                .HasForeignKey(u => u.IdPerfil); //chave estrangeira

        }
    }
}
