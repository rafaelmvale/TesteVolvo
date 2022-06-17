using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Application.DTOs;
using TesteVolvo.Application.Trucks.Commands;

namespace TesteVolvo.Application.Mappings
{
    internal class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<TruckDTO, TruckCreateCommand>();
            CreateMap<TruckDTO, TruckUpdateCommand>();
        }
    }
}
