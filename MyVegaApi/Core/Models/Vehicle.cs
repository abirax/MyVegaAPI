using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyVegaApi.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int ModelID { get; set; }
        public Model Model { get; set; }
      
        [Required]
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<VehicleFeatures> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<VehicleFeatures>();
        }
    }
    [Table("VehicleFeature")]
    public class VehicleFeatures
    {
        public int VehicleID { get; set; }
        public int FeatureID { get; set; }
        public Vehicle Vehicle { get; set; }
        public Feature Feature { get; set; }

    }
}
