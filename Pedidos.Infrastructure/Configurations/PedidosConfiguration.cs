using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Infrastructure.Configurations
{
    public class PedidosConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.NumeroPedido).IsRequired();

            builder.Property(x => x.PrecioTotal).HasPrecision(18, 2);

            builder.Property(x => x.Estado).HasConversion<byte>();

            builder.Property(x => x.Observaciones).IsRequired();
        }
    }
}
