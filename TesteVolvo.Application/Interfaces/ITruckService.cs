using System.Collections.Generic;
using System.Threading.Tasks;
using TesteVolvo.Application.DTOs;

namespace TesteVolvo.Application.Interfaces
{
    public interface ITruckService
    {
        Task<IEnumerable<TruckDTO>> GetTrucksAsync();
        Task<TruckDTO> GetByIdAsync(int? id);
        Task Add(TruckDTO truckDTO);
        Task Update(TruckDTO truckDTO);
        Task Remove(int? id);
    }
}
