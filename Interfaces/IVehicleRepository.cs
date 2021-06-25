using DealerTrack.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealerTrack.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<VehicleModel>> SaveAsync(IFormFile vehicles);
        Task<List<VehicleModel>> GetAllAsync();
    }
}
