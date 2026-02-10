using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.DTOs.Requests;
using Pedidos.Application.Interfaces;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetPedidos()
        {
            return Ok(await _pedidoService.GetPedidos());
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreatePedido([FromBody] CreatePedidoDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _pedidoService.CreatePedido(request);

            return (result) ? NoContent() : NotFound();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdatePedido(int id, [FromBody] UpdatePedidoDto request)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid PedidoId");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _pedidoService.UpdatePedido(id, request);

            return (result) ? NoContent() : NotFound();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeletePedido(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid PedidoId");
            }

            var result = await _pedidoService.DeletePedido(id);

            return (result) ? NoContent() : NotFound();
        }

        [HttpGet("list/{id}")]
        public async Task<ActionResult> GetPedido(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid PedidoId");
            }

            var result = await _pedidoService.GetPedido(id);

            if (result == null)
            {
                return NotFound("The order don't exists");
            }

            return Ok(result);
        }
    }
}
