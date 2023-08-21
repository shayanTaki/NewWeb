using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Models
{
    public class VehicleModel
    {
       
        [Key]
        public string vin { get; set; }
        public string DateVin { get; set; }
    }
}
