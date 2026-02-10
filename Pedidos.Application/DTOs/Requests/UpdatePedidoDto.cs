using System.ComponentModel.DataAnnotations;

namespace Pedidos.Application.DTOs.Requests
{
    public class UpdatePedidoDto
    {
        [Required]
        public string NumeroPedido { get; set; } = string.Empty;
        [Required]
        public decimal PrecioTotal { get; set; }
        [Required]
        public DateTime FechaPedido { get; set; }
        [Required]
        [MaxLength(2)]
        public byte Estado { get; set; }
        [Required]
        public string Observaciones { get; set; } = string.Empty;
    }
}
