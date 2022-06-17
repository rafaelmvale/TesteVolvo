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
    internal class TruckRemoveCommandHandler : IRequestHandler<TruckRemoveCommand, Truck>
    {
        private readonly ITruckRepository _truckRepository;
        public TruckRemoveCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository= truckRepository ?? throw new ArgumentNullException(nameof(truckRepository));

        }

        public async Task<Truck> Handle(TruckRemoveCommand request, CancellationToken cancellationToken)
        {
            var truck = await _truckRepository.GetByIdAsync(request.Id);

            if (truck == null)
            {
                throw new ApplicationException($"Entity coud not be found");
            }
            else
            {

                var result = await _truckRepository.RemoveAsync(truck);
                return result;
            }
        }
    }
}
