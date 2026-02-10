using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pedidos.Domain;
using Pedidos.Domain.Interfaces;
using Pedidos.Infrastructure.Contexts;

namespace Pedidos.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosContext _context;
        private readonly ILogger<PedidoRepository> _logger;

        public PedidoRepository(PedidosContext context, ILogger<PedidoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<Pedido>> ListPedidos()
        {
            try
            {
                return await _context.Pedido.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la lista de pedidos en la bd");
                throw;
            }
        }

        public async Task<bool> CreatePedido(Pedido pedido)
        {
            try
            {
                _context.Pedido.Add(pedido);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creando el pedido en la bd");
                throw;
            }
        }

        public async Task<Pedido?> GetPedidoById(int id)
        {
            try
            {
                return await _context.Pedido.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cargando la orden desde la bd");
                throw;
            }
        }

        public async Task<bool> UpdatePedido(Pedido pedido)
        {
            try
            {
                pedido.FechaActualizacion = DateTime.Now;
                _context.Update(pedido);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error actualizando el pedido");
                throw;
            }
        }

        public async Task<bool> DeletePedido(int id)
        {
            try
            {
                var order = await GetPedidoById(id);

                if (order != null)
                {
                    _context.Remove(order);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error actualizando el pedido en la bd");
                throw;
            }
        }
    }
}
