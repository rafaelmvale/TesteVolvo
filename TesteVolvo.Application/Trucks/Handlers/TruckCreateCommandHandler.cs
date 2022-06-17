using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteVolvo.Application.Trucks.Commands;
using TesteVolvo.Domain.Entities;
using TesteVolvo.Domain.Interfaces;

namespace TesteVolvo.Application.Trucks.Handlers
{
    public class TruckCreateCommandHandler : IRequestHandler<TruckCreateCommand, Truck>
    {
        private readonly ITruckRepository _truckRepository;

        public TruckCreateCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async Task<Truck> Handle(TruckCreateCommand request, CancellationToken cancellationToken)
        {
            var truck = new Truck(request.YearManufacture, request.YearModel);
            if (truck == null)
            {
                throw new ApplicationException($"Error creating entity");
            }
            else
            {
                truck.CategoryId = request.CategoryId;
                return await _truckRepository.CreateAsync(truck);
            }
        }
    }
}
