using DealerTrack.Entities;
using DealerTrack.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealerTrack.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleRepository vehicleRepository;
        public VehicleController(IVehicleRepository repository)
        {
            vehicleRepository = repository;
        }

        [HttpPost("/UploadVehicle")]
        [ProducesResponseType(typeof(IEnumerable<VehicleModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ProcessVehicleAsync(IFormFile postedFile)
        {
            var vehicles =  await vehicleRepository.SaveAsync(postedFile);

            return Ok(vehicles);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var vehicles = await vehicleRepository.GetAllAsync();
            if (vehicles == null || vehicles.Count == 0)
                return NoContent();
            return Ok(vehicles);
        }
    }
}
