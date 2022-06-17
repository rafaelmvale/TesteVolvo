using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;

namespace TesteVolvo.Domain.Interfaces
{
    public interface ITruckRepository
    {

        Task<IEnumerable<Truck>> GetTruckAsync();
        Task<Truck> GetByIdAsync(int? id);

        Task<Truck> CreateAsync(Truck truck);
        Task<Truck> UpdateAsync(Truck truck);
        Task<Truck> RemoveAsync(Truck truck);
    }
}
