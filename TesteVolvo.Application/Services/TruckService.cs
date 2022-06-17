using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteVolvo.Application.DTOs;
using TesteVolvo.Application.Interfaces;
using TesteVolvo.Application.Trucks.Commands;
using TesteVolvo.Application.Trucks.Queries;

namespace TesteVolvo.Application.Services
{
    public class TruckService : ITruckService
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TruckService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TruckDTO>> GetTrucksAsync()
        {
            var trucksQuery = new GetTrucksQuery();

            if (trucksQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(trucksQuery);
            return _mapper.Map<IEnumerable<TruckDTO>>(result);
        }
        public async Task<TruckDTO> GetByIdAsync(int? id)
        {
            var truckByIdQuery = new GetTruckByIdQuery(id.Value);
            if (truckByIdQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(truckByIdQuery);

            return _mapper.Map<TruckDTO>(result);
        }

        public async Task Add(TruckDTO truckDTO)
        {
            var truckCreateCommand = _mapper.Map<TruckCreateCommand>(truckDTO);
            await _mediator.Send(truckCreateCommand);
        }


        public async Task Update(TruckDTO truckDTO)
        {
            var truckUpdateCommand = _mapper.Map<TruckUpdateCommand>(truckDTO);
            await _mediator.Send(truckUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var truckRemoveCommand = new TruckRemoveCommand(id.Value);
            if (truckRemoveCommand == null)
                throw new Exception($"Entity could not be loaded");

            await _mediator.Send(truckRemoveCommand);
        }

    }
}
