using Pedidos.Domain;

namespace Pedidos.Application.DTOs.Responses
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public decimal PrecioTotal { get; set; }
        public DateTime FechaPedido { get; set; }
        public Estado Estado { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; }
    }
}
