using DealerTrack.Entities;
using DealerTrack.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace DealerTrack.Repositories
{
    public class VehicleTextFileRepository : IVehicleRepository
    {
        private readonly ILogger _logger;
        private readonly IVehicleService _vehicleService;

        public VehicleTextFileRepository(ILogger<VehicleTextFileRepository> logger, IVehicleService service)
        {
            _logger = logger;
            _vehicleService = service;
        }
        public async Task<List<VehicleModel>> GetAllAsync()
        {
            return await _vehicleService.GetVehiclesAsync();
        }

        public async Task<List<VehicleModel>> SaveAsync(IFormFile postedFile)
        {
            
            if (postedFile != null || postedFile.FileName.Contains(".csv"))
            {
                var result = await _vehicleService.ParseVehiclesAsync(postedFile);

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + Constants.fileName,
                    JsonConvert.SerializeObject(result));

                return result;
            }
            return null;
        }

        
    }
}
