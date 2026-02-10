using AutoMapper;
using Pedidos.Application.DTOs.Requests;
using Pedidos.Application.DTOs.Responses;
using Pedidos.Domain;

namespace Pedidos.Application.Mappings
{
    public class PedidoMappingProfile : Profile
    {
        public PedidoMappingProfile()
        {
            CreateMap<Pedido, PedidoDto>();

            CreateMap<CreatePedidoDto, Pedido>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaActualizacion, opt => opt.Ignore());

            CreateMap<UpdatePedidoDto, Pedido>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaActualizacion, opt => opt.Ignore());
        }
    }
}
