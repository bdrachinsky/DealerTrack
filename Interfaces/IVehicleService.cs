using DealerTrack.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealerTrack.Interfaces
{
    public interface IVehicleService
    {
        public Task<List<VehicleModel>> GetVehiclesAsync();
        public Task<List<VehicleModel>> ParseVehiclesAsync(IFormFile vehicles);
    }
}
