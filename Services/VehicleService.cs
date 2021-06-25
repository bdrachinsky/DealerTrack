using DealerTrack.Entities;
using DealerTrack.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DealerTrack.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ILogger _logger;
        public VehicleService (ILogger<VehicleService> logger)
        {
            _logger = logger;
        }

        public async Task<List<VehicleModel>> GetVehiclesAsync()
        {
            try
            {
                var json = await File.ReadAllTextAsync(AppDomain.CurrentDomain.BaseDirectory + @"\" + Constants.fileName);
                var vehicles = JsonConvert.DeserializeObject<List<VehicleModel>>(json);
                return vehicles;
            }
            catch (Exception ex)
            {
                //log here
                _logger.LogError($"There is some error at {DateTime.UtcNow.ToLongTimeString()}, {ex.Message} ");
                return null;
            }
        }

        public async Task<List<VehicleModel>> ParseVehiclesAsync(IFormFile postedFile)
        {
            try
            {
                Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                List<VehicleModel> vehicles = new List<VehicleModel>();
                using (var reader = new StreamReader(postedFile.OpenReadStream(), Encoding.GetEncoding("iso-8859-1")))
                {
                    bool isHeader = true;
                    while (reader.Peek() >= 0)
                    {
                        if (isHeader)
                            await reader.ReadLineAsync();
                        else
                        {
                            string[] csvLine = CSVParser.Split(await reader.ReadLineAsync());
                            vehicles.Add(new VehicleModel(csvLine));
                        }
                        isHeader = false;
                    }
                }
                return vehicles;
            }
            catch (Exception ex)
            {
                // log here
                _logger.LogError($"There is some error at {DateTime.UtcNow.ToLongTimeString()}, {ex.Message} ");
                return null;
            }
        }
    }
}
