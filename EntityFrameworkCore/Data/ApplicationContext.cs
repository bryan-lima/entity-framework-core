using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-B76722G\\SQLEXPRESS; Initial Catalog=EFCore; User ID=developer; Password=dev*10; Integrated Security=True; Persist Security Info=False; Pooling=False; MultipleActiveResultSets=False; Encrypt=False; Trusted_Connection=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(cliente => 
            {
                cliente.ToTable("Clientes");
                cliente.HasKey(cliente => cliente.Id);
                cliente.Property(cliente => cliente.Nome).HasColumnType("VARCHAR(80)").IsRequired();
                cliente.Property(cliente => cliente.Telefone).HasColumnType("CHAR(11)");
                cliente.Property(cliente => cliente.CEP).HasColumnType("CHAR(8)").IsRequired();
                cliente.Property(cliente => cliente.Estado).HasColumnType("CHAR(2)").IsRequired();
                cliente.Property(cliente => cliente.Cidade).HasMaxLength(60).IsRequired();

                cliente.HasIndex(c => c.Telefone).HasName("idx_cliente_telefone");
            });

            modelBuilder.Entity<Produto>(produto => 
            {
                produto.ToTable("Produtos");
                produto.HasKey(produto => produto.Id);
                produto.Property(produto => produto.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
                produto.Property(produto => produto.Descricao).HasColumnType("VARCHAR(60)");
                produto.Property(produto => produto.Valor).IsRequired();
                produto.Property(produto => produto.TipoProduto).HasConversion<string>();
            });

            modelBuilder.Entity<Pedido>(pedido => 
            {
                pedido.ToTable("Pedidos");
                pedido.Property(pedido => pedido.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                pedido.Property(pedido => pedido.Status).HasConversion<string>();
                pedido.Property(pedido => pedido.TipoFrete).HasConversion<int>();
                pedido.Property(pedido => pedido.Observacao).HasColumnType("VARCHAR(512)");

                pedido.HasMany(pedido => pedido.Itens)
                      .WithOne(pedido => pedido.Pedido)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PedidoItem>(pedidoItem =>
            {
                pedidoItem.ToTable("PedidoItens");
                pedidoItem.HasKey(pedidoItem => pedidoItem.Id);
                pedidoItem.Property(pedidoItem => pedidoItem.Quantidade).HasDefaultValue(1).IsRequired();
                pedidoItem.Property(pedidoItem => pedidoItem.Valor).IsRequired();
                pedidoItem.Property(pedidoItem => pedidoItem.Desconto).IsRequired();
            });
        }
    }
}
