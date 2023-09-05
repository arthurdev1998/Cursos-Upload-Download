using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContexto.DataConfig
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
           
                builder.ToTable("ALUNOS");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Nome)
                    .HasColumnType("varchar(50)").IsRequired();

                builder.Property(x => x.Cpf)
                    .HasColumnType("varchar(50)").IsRequired();

                

            
        }
    }
}
