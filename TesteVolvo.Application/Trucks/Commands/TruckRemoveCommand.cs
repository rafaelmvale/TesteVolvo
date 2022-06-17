using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;

namespace TesteVolvo.Application.Trucks.Commands
{
    public class TruckRemoveCommand : IRequest<Truck>
    {

        public int Id { get; set; }
        public TruckRemoveCommand(int id)
        {
            Id = id;

        }
    }
}
