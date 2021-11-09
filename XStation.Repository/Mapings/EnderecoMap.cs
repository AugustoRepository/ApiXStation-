using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;

namespace XStation.Repository.Mapings
{
    public class EnderecoMap  : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(p => p.IdEndereco);

            builder.Property(p => p.IdEndereco).HasColumnName("IdEndereco").IsRequired();
            builder.Property(p => p.Cep).HasColumnName("Cep").IsRequired();
            builder.Property(p => p.Logradouro).HasColumnName("Logradouro").IsRequired();
            builder.Property(p => p.Bairro).HasColumnName("Bairro").IsRequired();
            builder.Property(p => p.Cidade).HasColumnName("Cidade").IsRequired();
            builder.Property(p => p.Estado).HasColumnName("Estado").IsRequired();
            builder.Property(p => p.IdCliente).HasColumnName("IdCliente").IsRequired();
            builder.Property(p => p.IdFuncionario).HasColumnName("IdFuncionario").IsRequired();

            builder.HasOne(u => u.Cliente) //Usuario TEM 1 Perfil
                     .WithMany(p => p.Enderecos) //Perfil TEM MUITOS Usuarios
                     .HasForeignKey(u => u.IdCliente);



            builder.HasOne(u => u.Funcionario) //Usuario TEM 1 Perfil
                     .WithMany(p => p.Enderecos) //Perfil TEM MUITOS Usuarios
                     .HasForeignKey(u => u.IdFuncionario);


        }
    }
}
