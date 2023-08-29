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
        private readonly ContaxTopCoat ContaxTopCoat;

        public BaseController(ContaxDBlogin ContaxDBlogin, PlanningDBcontax PlanningDBcontax,CountaxInfoLogesticB CountaxInfoLogesticB, ContaxTopCoat ContaxTopCoat)
        {
            this.ContaxDBlogin = ContaxDBlogin;
            this.PlanningDBcontax = PlanningDBcontax;
            this.ContaxTopCoat = ContaxTopCoat;
            this.CountaxInfoLogesticB = CountaxInfoLogesticB;
            
        }
        public IActionResult Index()
        {

            DateTime today = DateTime.Now;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            int year = pc.GetYear(today);
            int month = pc.GetMonth(today);
            int day = pc.GetDayOfMonth(today);
            string persianDate = $"{year}/{month:D2}/{day:D2}";


            var vin1 = PlanningDBcontax.Tblvehicle.Where(x => x.VirtualType == "852s" && x.MainLine == persianDate).ToList();
            int CountKMCbody = vin1.Count;

            var vin2 = PlanningDBcontax.Tblvehicle.Where(x => x.VirtualType != "852s" && x.MainLine == persianDate).ToList();
            int CountARMbody = vin2.Count;


            var vin3 = PlanningDBcontax.Tblvehicle.Where(x => x.VirtualType == "742S" && x.ExitChassis == persianDate).ToList();
            int MontagKMC = vin3.Count;

            var vin4 = PlanningDBcontax.Tblvehicle.Where(x => x.VirtualType == "742S" && x.ExitChassis == persianDate).ToList();
            int MontagBamKO = vin4.Count;























            var KMC = ContaxTopCoat.TblTopCoat.Where(x => x.ID != null && x.DateTopCoat == persianDate).ToList();
            var TransSaipa = CountaxInfoLogesticB.tbliOLogisticInfoB.Where(x => x.TransTo == "SAIPA" && x.ExitDate == persianDate).ToList();
            var TransModiran = CountaxInfoLogesticB.tbliOLogisticInfoB.Where(x => x.TransTo == "MVM" && x.ExitDate == persianDate).ToList();







            ViewBag.PersianYear = year.ToString();
            ViewBag.PersianMonth = month.ToString("D2"); // به فرمت دو رقمی
            ViewBag.PersianDay = day.ToString("D2");     // به فرمت دو رقمی



            ViewBag.TransSaipa = TransSaipa.Count;
            ViewBag.TransModiran = TransModiran.Count;
            ViewBag.MontagKMC = MontagKMC;
            ViewBag.MontagBamKO = MontagBamKO;

            ViewBag.KMC = KMC.Count;


            ViewBag.CountKMCbody = CountKMCbody;
            ViewBag.CountARMbody = CountARMbody;
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
