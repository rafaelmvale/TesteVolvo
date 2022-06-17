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
    public class GetTrucksQueryHandler : IRequestHandler<GetTrucksQuery, IEnumerable<Truck>>
    {
        private readonly ITruckRepository _truckRepository;

        public GetTrucksQueryHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;

        }

        public async Task<IEnumerable<Truck>> Handle(GetTrucksQuery request, CancellationToken cancellationToken)
        {
            return await _truckRepository.GetTruckAsync();
        }
    }
}
