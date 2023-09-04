using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexto.DataConfig
{
    public class CursosConfiguration : IEntityTypeConfiguration<Cursos>
    {
        public void Configure(EntityTypeBuilder<Cursos> builder)
        {
            builder.ToTable("CURSOS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Titulo)
                .HasColumnType("varchar(50)").IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(50)").IsRequired();

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,2)").IsRequired();

        }
    }
}
