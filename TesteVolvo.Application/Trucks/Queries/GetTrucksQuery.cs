using MediatR;
using System.Collections.Generic;
using TesteVolvo.Domain.Entities;

namespace TesteVolvo.Application.Trucks.Queries
{
    public class GetTrucksQuery : IRequest<IEnumerable<Truck>>
    {
    }
}
