using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class PessoaMap<T> : IEntityTypeConfiguration<T> where T : PessoaEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
       {

              builder.Property(c => c.PrimeiroNome)
                     .HasColumnName("first_name")
                     .HasColumnType("varchar(45)");
              
              builder.Property(c => c.UltimoNome)
                     .HasColumnName("last_name")
                     .HasColumnType("varchar(45)");

              builder.Property(c => c.Email)
                     .HasColumnName("email")
                     .HasColumnType("varchar(50)");

              builder.Property(c => c.Ativo)
                     .HasColumnName("active");

              builder.Property<DateTime>("last_update")
                     .HasColumnType("datetime")
                     .HasDefaultValueSql("Now()")
                     .IsRequired();
              }
    }
}