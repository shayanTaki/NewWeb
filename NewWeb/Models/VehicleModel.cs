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


#nullable enable
        public int? Degree { get; set; }
        public int? ModelMil { get; set; }
        public bool? Ok4St { get; set; }
        public bool? Ok6St { get; set; }
        public bool? QcSt { get; set; }
        public bool? FinalSt { get; set; }
        public bool? ExportSt { get; set; }
        public bool? DeliverSt { get; set; }



        public string? DateVin { get; set; }
        public string? Type { get; set; }
        public string? VirtualType { get; set; }
        public string? Pack { get; set; }
        public string? PrdYear { get; set; }
        public string? ModelIR { get; set; }
        public string? MainLine { get; set; }
        public string? EnterBIW { get; set; }
        public string? BIW { get; set; }
        public string? MetalFinish { get; set; }
        public string? EnterPaint { get; set; }
        public string? Primer { get; set; }
        public string? TopCoat { get; set; }
        public string? ExitPaint { get; set; }
        public string? Ok4 { get; set; }

        public string? EnterTrim { get; set; }
        public string? ExitChassis { get; set; }
        public string? FinalTrim { get; set; }
        public string? Ok5 { get; set; }
        public string? Ok6 { get; set; }

        public string? ExitTrim { get; set; }
        public string? EntPDI { get; set; }
        public string? Final { get; set; }

        public string? Deliver { get; set; }

        public string? ExtPDI { get; set; }
        public string? Trans { get; set; }
        public string? ColorCode { get; set; }
        public string? Engine { get; set; }
        public string? GearBox { get; set; }
        public string? Airbag { get; set; }
        public string? Radio { get; set; }
        public string? Immobilizer { get; set; }
        public string? KeyNumber { get; set; }
        public string? Computer { get; set; }
        public string? OpCode { get; set; }
        public string? Fuel { get; set; }
        public string? Destination { get; set; }
        public string? KeyCode { get; set; }
        public string? Kilometer { get; set; }



    }
}
