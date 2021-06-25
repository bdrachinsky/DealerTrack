using System;

namespace DealerTrack.Entities
{
    public class VehicleModel
    {
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string VehicleName { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public VehicleModel (string[] fileLine)
        {
            try
            {
                DealNumber = Convert.ToInt32(fileLine[0]);
                CustomerName = fileLine[1];
                DealershipName = fileLine[2];
                VehicleName = fileLine[3];
                Price = Convert.ToDecimal(fileLine[4].Remove(fileLine[4].Length - 1).Remove(0, 1).Replace(',', '.'));
                Date = Convert.ToDateTime(fileLine[5]);
            }
            catch (Exception ex)
            {
                //logging should be there
            }
        }

        public VehicleModel()
        {

        }

        public override string ToString()
        {
            return DealNumber.ToString() + ";" + CustomerName + ";" + DealershipName + ";" + VehicleName + ";" + Price.ToString() + ";" + Date.ToString();
        }

    }
}
