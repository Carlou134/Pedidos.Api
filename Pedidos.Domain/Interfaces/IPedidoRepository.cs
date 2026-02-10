namespace Pedidos.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IReadOnlyCollection<Pedido>> ListPedidos();
        Task<bool> CreatePedido(Pedido pedido);
        Task<bool> UpdatePedido(Pedido pedido);
        Task<bool> DeletePedido(int id);
        Task<Pedido?> GetPedidoById(int id);
    }
}
