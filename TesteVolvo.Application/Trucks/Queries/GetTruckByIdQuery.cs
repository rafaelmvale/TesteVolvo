using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;

namespace TesteVolvo.Application.Trucks.Queries
{
    public class GetTruckByIdQuery : IRequest<Truck>
    {
        public int Id { get; set; }
        public GetTruckByIdQuery(int id)
        {
            Id = id;

        }
    }
}
