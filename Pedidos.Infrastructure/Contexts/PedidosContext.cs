using Microsoft.EntityFrameworkCore;
using Pedidos.Domain;
using System.Reflection;

namespace Pedidos.Infrastructure.Contexts
{
    public class PedidosContext : DbContext
    {
        public PedidosContext(DbContextOptions options) : base(options) {}

        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
