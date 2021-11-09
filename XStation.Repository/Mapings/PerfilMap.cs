using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;

namespace XStation.Repository.Mapings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");

            builder.HasKey(p => p.IdPerfil);

            builder.Property(p => p.IdPerfil).HasColumnName("IdPerfil").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
        }
    }
}
