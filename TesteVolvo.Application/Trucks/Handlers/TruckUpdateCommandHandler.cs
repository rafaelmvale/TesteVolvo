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
    public class TruckUpdateCommandHandler : IRequestHandler<TruckUpdateCommand, Truck>
    {
        private readonly ITruckRepository _truckRepository;
        public TruckUpdateCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository ?? throw new ArgumentNullException(nameof(truckRepository));
        }
        public async Task<Truck> Handle(TruckUpdateCommand request, CancellationToken cancellationToken)
        {
            var truck = await _truckRepository.GetByIdAsync(request.Id);

            if (truck == null)
            {
                throw new ApplicationException($"Entity could not be found");

            }
            else
            {
                truck.Update(request.YearManufacture, request.YearModel, request.CategoryId);

                return await _truckRepository.UpdateAsync(truck);
            }
        }
    }
}

