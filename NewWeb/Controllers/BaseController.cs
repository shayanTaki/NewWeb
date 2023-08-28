using Microsoft.AspNetCore.Mvc;
using NewWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Controllers
{
    public class BaseController : Controller
    {
        
        private readonly ContaxDBlogin ContaxDBlogin;
        private readonly PlanningDBcontax PlanningDBcontax;
        private readonly CountaxInfoLogesticB CountaxInfoLogesticB;

        public BaseController(ContaxDBlogin ContaxDBlogin, PlanningDBcontax PlanningDBcontax,CountaxInfoLogesticB CountaxInfoLogesticB)
        {
            this.ContaxDBlogin = ContaxDBlogin;
            this.PlanningDBcontax = PlanningDBcontax;
            this.CountaxInfoLogesticB = CountaxInfoLogesticB;
        }
        public IActionResult Index()
        {



            //var vin1 = PlanningDBcontax.Tblvehicle.Where(x => x.VirtualType == "852s").ToList();
            //int CountKMCbody = vin1.Count;

            //var vin2 = PlanningDBcontax.Tblvehicle.Where(x => x.VirtualType != "852s").ToList();
            //int CountARMbody = vin1.Count;




            var TransSaipa = CountaxInfoLogesticB.tbliOLogisticInfoB.Where(x => x.TransTo == "SAIPA").ToList();
            var TransModiran = CountaxInfoLogesticB.tbliOLogisticInfoB.Where(x => x.TransTo == "MVM").ToList();
            ViewBag.TransSaipa = TransSaipa.Count;
            ViewBag.TransModiran = TransModiran.Count;

            //ViewBag.CountKMCbody = CountKMCbody;
            //ViewBag.CountARMbody = CountARMbody;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string vin)
        {


            var vin1 = PlanningDBcontax.Tblvehicle.Where(u => u.vin == vin).ToList();


            return View("index-post");
        }
    }
}
