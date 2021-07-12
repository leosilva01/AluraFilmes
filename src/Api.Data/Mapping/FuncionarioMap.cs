using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class FuncionarioMap : PessoaMap<FuncionarioEntity>
    {
       public override void Configure(EntityTypeBuilder<FuncionarioEntity> builder)
       {

              base.Configure(builder);

              builder.ToTable("staff");

              builder.HasKey(c => c.Id);

              builder.Property(c => c.Id)
                     .HasColumnName("staff_id");

              builder.Property(f => f.Login)
                     .HasColumnName("username")
                     .HasColumnType("varchar(16)")
                     .IsRequired();

              builder.Property(f => f.Senha)
                     .HasColumnName("password")
                     .HasColumnType("varchar(40)");




              }
    }
}