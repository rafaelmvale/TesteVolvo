using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;
using TesteVolvo.Domain.Interfaces;
using TesteVolvo.Infra.Data.Context;

namespace TesteVolvo.Infra.Data.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        ApplicationDBContext _truckContext;

        public TruckRepository(ApplicationDBContext context)
        {
            _truckContext = context;
        }
        public async Task<Truck> CreateAsync(Truck truck)
        {
            _truckContext.Add(truck);
            await _truckContext.SaveChangesAsync();
            return truck;
        }

        public async Task<Truck> GetByIdAsync(int? id)
        {
            return await _truckContext.Trucks.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Truck>> GetTruckAsync()
        {
            return await _truckContext.Trucks.ToListAsync();
        }

        public async Task<Truck> RemoveAsync(Truck truck)
        {
            _truckContext.Remove(truck);
            await _truckContext.SaveChangesAsync();
            return truck;
        }

        public async Task<Truck> UpdateAsync(Truck truck)
        {
            _truckContext.Update(truck);
            await _truckContext.SaveChangesAsync();
            return truck;

        }
    }
}
