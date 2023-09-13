using Microsoft.AspNetCore.Http;
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
        private readonly CountaxStatusCar CountaxStatusCar;

        public BaseController(ContaxDBlogin ContaxDBlogin, PlanningDBcontax PlanningDBcontax,CountaxInfoLogesticB CountaxInfoLogesticB, ContaxTopCoat ContaxTopCoat, CountaxStatusCar CountaxStatusCar)
        {
            this.ContaxDBlogin = ContaxDBlogin;
            this.PlanningDBcontax = PlanningDBcontax;
            this.ContaxTopCoat = ContaxTopCoat;
            this.CountaxInfoLogesticB = CountaxInfoLogesticB;
            this.CountaxStatusCar = CountaxStatusCar;

        }
        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
                string user = username.Replace(" ", string.Empty);
                string shayan = "shayan";
                return View();



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






                //parking 

                string formattedDate = today.ToString("d/MM/yyyy");




                var savedDates = CountaxStatusCar.StatusCar.Where(d => d.CarINDate.ToString().Substring(0, 10) == formattedDate && d.CarInParking == true).ToList();

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
            else
            {
                return Redirect("Home/LoginNew");
            }
        }

        [HttpPost]
        public IActionResult Index(string vin)
        {


            var vin1 = PlanningDBcontax.Tblvehicle.Where(u => u.vin == vin).ToList();


            return View("index-post");
        }
    }
}
