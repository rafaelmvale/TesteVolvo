using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;

namespace TesteVolvo.Application.Trucks.Commands
{
    public abstract class TruckCommand : IRequest<Truck>
    {
        public DateTime YearManufacture { get; set; }
        public DateTime YearModel { get; set; }
        public int CategoryId { get; set; }
    }
}
