using System.Threading.Tasks;
using MyVegaApi.Models;
using MyVegaApi.Persistence;

namespace MyVegaApi.Core
{
    public interface IVehicleRepository
    {
        VegaDbContext VegaDbContext { get; }

        void CreateVehicle(Vehicle vehicle);
        void DeleteVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
    }
}