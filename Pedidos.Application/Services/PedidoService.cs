using AutoMapper;
using Pedidos.Application.DTOs.Requests;
using Pedidos.Application.DTOs.Responses;
using Pedidos.Application.Interfaces;
using Pedidos.Domain;
using Pedidos.Domain.Interfaces;

namespace Pedidos.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PedidoDto>> GetPedidos()
        {
            var result = await _repository.ListPedidos();
            return _mapper.Map<IEnumerable<PedidoDto>>(result);
        }

        public async Task<bool> CreatePedido(CreatePedidoDto request)
        {
            var newPedido = _mapper.Map<Pedido>(request);
            return await _repository.CreatePedido(newPedido);
        }

        public async Task<PedidoDto?> GetPedido(int id)
        {
            var pedido = await _repository.GetPedidoById(id);

            if (pedido == null)
                return null;

            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<bool> UpdatePedido(int id, UpdatePedidoDto request)
        {
            var pedido = await _repository.GetPedidoById(id);

            if (pedido != null)
            {
                _mapper.Map(request, pedido);
                return await _repository.UpdatePedido(pedido);
            }

            return false;
        }

        public async Task<bool> DeletePedido(int id)
        {
            var pedido = await _repository.GetPedidoById(id);

            if (pedido != null)
            {
                return await _repository.DeletePedido(id);
            }

            return false;
        }
    }
}
