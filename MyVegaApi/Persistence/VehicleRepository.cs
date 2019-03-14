using MyVegaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyVegaApi.Core;

namespace MyVegaApi.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        public VegaDbContext VegaDbContext { get; }

        public VehicleRepository(VegaDbContext vegaDbContext)
        {
            VegaDbContext = vegaDbContext;
        }
        public async Task<Vehicle> GetVehicle(int id,bool includeRelated=true)
        {
            if(!includeRelated)
            { 
            return await VegaDbContext.Vehicles.FindAsync(id);
            }
            return await VegaDbContext.Vehicles.
                Include(v => v.Features).
                 ThenInclude(vf => vf.Feature).
                 Include(v => v.Model).
                    ThenInclude(m => m.Make).
                  SingleOrDefaultAsync(v => v.VehicleID == id);
        }
        public void DeleteVehicle(Vehicle vehicle)
        {
           // var vehicle = GetVehicle(id);
            VegaDbContext.Remove(vehicle);

        }
        public void CreateVehicle(Vehicle vehicle)
        {
            VegaDbContext.Add(vehicle);

        }
    }
}
