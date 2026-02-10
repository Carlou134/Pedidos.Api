using Pedidos.Application.DTOs.Requests;
using Pedidos.Application.DTOs.Responses;

namespace Pedidos.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDto>> GetPedidos();
        Task<bool> CreatePedido(CreatePedidoDto request);
        Task<PedidoDto?> GetPedido(int id);
        Task<bool> UpdatePedido(int id, UpdatePedidoDto request);
        Task<bool> DeletePedido(int id);
    }
}
