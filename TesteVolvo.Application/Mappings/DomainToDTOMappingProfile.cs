using AutoMapper;
using TesteVolvo.Application.DTOs;
using TesteVolvo.Domain.Entities;

namespace TesteVolvo.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Truck, TruckDTO>().ReverseMap();
        }

    }
}
