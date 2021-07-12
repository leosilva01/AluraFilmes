using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ClienteMap : PessoaMap<ClienteEntity>
    {
        public override void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            
            base.Configure(builder);
    
            builder.ToTable("customer");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("customer_id");

            builder.Property<DateTime>("create_date")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("Now()")
                   .IsRequired();
        }
    }
}