using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Models
{
    public class StatusCarModel
    {
#nullable enable
        [Key]
        public int? StatusCarID { get; set; }
        public string? VIN { get; set; }
        public DateTime? CarINDate { get; set; }
        public bool CarInParking { get; set; }
    }
}
