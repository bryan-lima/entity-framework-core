using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(pedidoItem => pedidoItem.Id);
            builder.Property(pedidoItem => pedidoItem.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(pedidoItem => pedidoItem.Valor).IsRequired();
            builder.Property(pedidoItem => pedidoItem.Desconto).IsRequired();
        }
    }
}
