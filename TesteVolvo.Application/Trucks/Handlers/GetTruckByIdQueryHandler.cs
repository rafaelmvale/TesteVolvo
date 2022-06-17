using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteVolvo.Application.Trucks.Queries;
using TesteVolvo.Domain.Entities;
using TesteVolvo.Domain.Interfaces;

namespace TesteVolvo.Application.Trucks.Handlers
{
    public class GetTruckByIdQueryHandler : IRequestHandler<GetTruckByIdQuery, Truck>
    {
        private readonly ITruckRepository _truckRepository;
        public GetTruckByIdQueryHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<Truck> Handle(GetTruckByIdQuery request, CancellationToken cancellationToken)
        {
            return await _truckRepository.GetByIdAsync(request.Id);
        }
    }
}
