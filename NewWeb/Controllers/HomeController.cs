using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWeb.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using BCrypt.Net;
using System;
using System.Text;
using System.Security.Cryptography;

namespace NewWeb.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ContaxDBlogin ContaxDBlogin;
        private readonly PlanningDBcontax PlanningDBcontax;

        public HomeController(ContaxDBlogin ContaxDBlogin, PlanningDBcontax PlanningDBcontax)
        {
            this.ContaxDBlogin = ContaxDBlogin;
            this.PlanningDBcontax = PlanningDBcontax;
        }





        

        


        public IActionResult Index()
        {
            return View();
        }


        
        public IActionResult Privacy()
        {
            var username = HttpContext.Session.GetString("Username");
            if (!string.IsNullOrEmpty(username))
            {
                    return View();
            }
            else
            {
                // کاربر احراز هویت نشده است، ریدایرکت به صفحه ورود
                return RedirectToAction("LoginNew");
            }

        }

        public IActionResult LoginNew()
        {
            return View();

            
        }
        [HttpPost]
        public IActionResult LoginNew(string username, string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "");

                var user = ContaxDBlogin.tblogin.FirstOrDefault(u => u.Users == username && u.Password == hash);

                if (user != null)
                {
                    HttpContext.Session.SetString("Username", user.Users);
                    return RedirectToAction("Index");
                }
                else
                {
                    //ViewData["Message"] = hash;
                    ViewData["Message"] = "Username does not exist";
                    return View("LoginNew");
                }
            }

        }
        public IActionResult AdminNew() {
            string username = HttpContext.Session.GetString("Username");
            //string user = username.Replace(" ", string.Empty);
            //string shayan = "shayan";
            if (!string.IsNullOrEmpty(username))
            {
                return View();
            }
            else
            {
                ViewData["Message"] = "کاربر احراز هویت نشده است، ریدایرکت به صفحه ورود";
                // کاربر احراز هویت نشده است، ریدایرکت به صفحه ورود
                return View("LoginNew");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // پاک کردن تمامی اطلاعات سشن
            return RedirectToAction("LoginNew", "Home"); // ریدایرکت به صفحه ورود
        }




        public IActionResult vinSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult vinSearch(string vin)
        {
            
            var vin1 = PlanningDBcontax.Tblvehicle.FirstOrDefault(u => u.vin == vin);
            ViewBag.vin = vin1.vin;
            ViewBag.Type = vin1.Type;
            ViewBag.MainLine = vin1.MainLine;
            ViewBag.EnterBIW = vin1.EnterBIW;
            ViewBag.BIW = vin1.BIW;
            ViewBag.MetalFinish = vin1.MetalFinish;
            ViewBag.EnterPaint = vin1.EnterPaint;
            ViewBag.Primer = vin1.Primer;
            ViewBag.TopCoat = vin1.TopCoat;
            ViewBag.ExitPaint = vin1.ExitPaint;
            ViewBag.EnterTrim = vin1.EnterTrim;
            ViewBag.ExitChassis = vin1.ExitChassis;
            ViewBag.FinalTrim = vin1.FinalTrim;
            ViewBag.ExitTrim = vin1.ExitTrim;
            
            return View("vinSearch1");
        }



        //لیست دوم و الگورتیم پیاده سازی ی آن




        
        public IActionResult SearchKoli()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SearchKoli1(string Type, string MainLine, string EnterBIW, string BIW,
                                    string MetalFinish, string EnterPaint, string Primer, string TopCoat, string ExitPaint,
                                    string EnterTrim, string ExitChassis, string FinalTrim, string ExitTrim)
        {
            if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && !string.IsNullOrEmpty(BIW)
                && !string.IsNullOrEmpty(MetalFinish) && !string.IsNullOrEmpty(EnterPaint) && !string.IsNullOrEmpty(Primer) && !string.IsNullOrEmpty(TopCoat) && !string.IsNullOrEmpty(ExitPaint) && !string.IsNullOrEmpty(EnterTrim)
                && !string.IsNullOrEmpty(ExitChassis) && !string.IsNullOrEmpty(FinalTrim) && !string.IsNullOrEmpty(ExitTrim))
            {
                // حالت هیچ ورودی پر شده

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                BIW = BIW.Replace("\t", "");
                MetalFinish = MetalFinish.Replace("\t", "");
                EnterPaint = EnterPaint.Replace("\t", "");
                Primer = Primer.Replace("\t", "");
                TopCoat = TopCoat.Replace("\t", "");
                ExitPaint = ExitPaint.Replace("\t", "");
                EnterTrim = EnterTrim.Replace("\t", "");
                ExitChassis = ExitChassis.Replace("\t", "");
                FinalTrim = FinalTrim.Replace("\t", "");
                ExitTrim = ExitTrim.Replace("\t", "");

                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
             u.Type == Type &&
             u.MainLine == MainLine &&
             u.EnterBIW == EnterBIW &&
             u.BIW == BIW &&
             u.MetalFinish == MetalFinish &&
             u.EnterPaint == EnterPaint &&
             u.Primer == Primer &&
             u.TopCoat == TopCoat &&
             u.ExitPaint == ExitPaint &&
             u.EnterTrim == EnterTrim &&
             u.ExitChassis == ExitChassis &&
            u.FinalTrim == FinalTrim &&
             u.ExitTrim == ExitTrim)
            .ToList();
                //foreach (var vin1 in vehicleList)
                //{
                //    ViewBag.vin = vin1.vin;
                //    ViewBag.Type = vin1.Type;
                //    ViewBag.MainLine = vin1.MainLine;
                //    ViewBag.EnterBIW = vin1.EnterBIW;
                //    ViewBag.BIW = vin1.BIW;
                //    ViewBag.MetalFinish = vin1.MetalFinish;
                //    ViewBag.EnterPaint = vin1.EnterPaint;
                //    ViewBag.Primer = vin1.Primer;
                //    ViewBag.TopCoat = vin1.TopCoat;
                //    ViewBag.ExitPaint = vin1.ExitPaint;
                //    ViewBag.EnterTrim = vin1.EnterTrim;
                //    ViewBag.ExitChassis = vin1.ExitChassis;
                //    ViewBag.FinalTrim = vin1.FinalTrim;
                //    ViewBag.ExitTrim = vin1.ExitTrim;


                //}
                ViewBag.vehicleList = vehicleList;
                return View("SearchKoliPost");
            }


            //###############################################################################################################

            else if (!string.IsNullOrEmpty(Type) && string.IsNullOrEmpty(MainLine) && string.IsNullOrEmpty(EnterBIW) && string.IsNullOrEmpty(BIW)
                && string.IsNullOrEmpty(MetalFinish) && string.IsNullOrEmpty(EnterPaint) && string.IsNullOrEmpty(Primer) && string.IsNullOrEmpty(TopCoat) && string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
                && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost1");
            }


            //###############################################################################################################

            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && string.IsNullOrEmpty(EnterBIW) && string.IsNullOrEmpty(BIW)
               && string.IsNullOrEmpty(MetalFinish) && string.IsNullOrEmpty(EnterPaint) && string.IsNullOrEmpty(Primer) && string.IsNullOrEmpty(TopCoat) && string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
               && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost2");
            }

            //###############################################################################################################
            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && string.IsNullOrEmpty(BIW)
               && string.IsNullOrEmpty(MetalFinish) && string.IsNullOrEmpty(EnterPaint) && string.IsNullOrEmpty(Primer) && string.IsNullOrEmpty(TopCoat) && string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
               && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine &&
                u.EnterBIW == EnterBIW).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost3");
            }
            //###############################################################################################################
            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && !string.IsNullOrEmpty(BIW)
              && string.IsNullOrEmpty(MetalFinish) && string.IsNullOrEmpty(EnterPaint) && string.IsNullOrEmpty(Primer) && string.IsNullOrEmpty(TopCoat) && string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
              && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                BIW = BIW.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine &&
                u.EnterBIW == EnterBIW &&
                u.BIW == BIW).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost4");
            }

            //###############################################################################################################
            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && !string.IsNullOrEmpty(BIW)
              && !string.IsNullOrEmpty(MetalFinish) && string.IsNullOrEmpty(EnterPaint) && string.IsNullOrEmpty(Primer) && string.IsNullOrEmpty(TopCoat) && string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
              && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                BIW = BIW.Replace("\t", "");
                MetalFinish = MetalFinish.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine &&
                u.EnterBIW == EnterBIW &&
                u.BIW == BIW &&
                u.MetalFinish == MetalFinish).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost5");
            }

            //###############################################################################################################
            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && !string.IsNullOrEmpty(BIW)
              && !string.IsNullOrEmpty(MetalFinish) && !string.IsNullOrEmpty(EnterPaint) && string.IsNullOrEmpty(Primer) && string.IsNullOrEmpty(TopCoat) && string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
              && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                BIW = BIW.Replace("\t", "");
                MetalFinish = MetalFinish.Replace("\t", "");
                EnterPaint = EnterPaint.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine &&
                u.EnterBIW == EnterBIW &&
                u.BIW == BIW &&
                u.MetalFinish == MetalFinish &&
                u.EnterPaint == EnterPaint).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost6");
            }
            //###############################################################################################################
            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && !string.IsNullOrEmpty(BIW)
              && !string.IsNullOrEmpty(MetalFinish) && !string.IsNullOrEmpty(EnterPaint) && !string.IsNullOrEmpty(Primer) && string.IsNullOrEmpty(TopCoat) && string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
              && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                BIW = BIW.Replace("\t", "");
                MetalFinish = MetalFinish.Replace("\t", "");
                EnterPaint = EnterPaint.Replace("\t", "");
                Primer = Primer.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine &&
                u.EnterBIW == EnterBIW &&
                u.BIW == BIW &&
                u.MetalFinish == MetalFinish &&
                u.EnterPaint == EnterPaint &&
                u.Primer == Primer).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost7");
            }

            //###############################################################################################################
            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && !string.IsNullOrEmpty(BIW)
              && !string.IsNullOrEmpty(MetalFinish) && !string.IsNullOrEmpty(EnterPaint) && !string.IsNullOrEmpty(Primer) && !string.IsNullOrEmpty(TopCoat) && string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
              && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                BIW = BIW.Replace("\t", "");
                MetalFinish = MetalFinish.Replace("\t", "");
                EnterPaint = EnterPaint.Replace("\t", "");
                Primer = Primer.Replace("\t", "");
                TopCoat = TopCoat.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine &&
                u.EnterBIW == EnterBIW &&
                u.BIW == BIW &&
                u.MetalFinish == MetalFinish &&
                u.EnterPaint == EnterPaint &&
                u.Primer == Primer &&
                u.TopCoat == TopCoat).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost7");
            }



            //###############################################################################################################
            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && !string.IsNullOrEmpty(BIW)
              && !string.IsNullOrEmpty(MetalFinish) && !string.IsNullOrEmpty(EnterPaint) && !string.IsNullOrEmpty(Primer) && !string.IsNullOrEmpty(TopCoat) && !string.IsNullOrEmpty(ExitPaint) && string.IsNullOrEmpty(EnterTrim)
              && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                BIW = BIW.Replace("\t", "");
                MetalFinish = MetalFinish.Replace("\t", "");
                EnterPaint = EnterPaint.Replace("\t", "");
                Primer = Primer.Replace("\t", "");
                TopCoat = TopCoat.Replace("\t", "");
                ExitPaint = ExitPaint.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine &&
                u.EnterBIW == EnterBIW &&
                u.BIW == BIW &&
                u.MetalFinish == MetalFinish &&
                u.EnterPaint == EnterPaint &&
                u.Primer == Primer &&
                u.TopCoat == TopCoat &&
                u.ExitPaint == ExitPaint).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost8");
            }
            //###############################################################################################################
            else if (!string.IsNullOrEmpty(Type) && !string.IsNullOrEmpty(MainLine) && !string.IsNullOrEmpty(EnterBIW) && !string.IsNullOrEmpty(BIW)
              && !string.IsNullOrEmpty(MetalFinish) && !string.IsNullOrEmpty(EnterPaint) && !string.IsNullOrEmpty(Primer) && !string.IsNullOrEmpty(TopCoat) && !string.IsNullOrEmpty(ExitPaint) && !string.IsNullOrEmpty(EnterTrim)
              && string.IsNullOrEmpty(ExitChassis) && string.IsNullOrEmpty(FinalTrim) && string.IsNullOrEmpty(ExitTrim))
            {

                Type = Type.Replace("\t", "");
                MainLine = MainLine.Replace("\t", "");
                EnterBIW = EnterBIW.Replace("\t", "");
                BIW = BIW.Replace("\t", "");
                MetalFinish = MetalFinish.Replace("\t", "");
                EnterPaint = EnterPaint.Replace("\t", "");
                Primer = Primer.Replace("\t", "");
                TopCoat = TopCoat.Replace("\t", "");
                ExitPaint = ExitPaint.Replace("\t", "");
                EnterTrim = EnterTrim.Replace("\t", "");
                var vehicleList = PlanningDBcontax.Tblvehicle.Where(u =>
                u.Type == Type &&
                u.MainLine == MainLine &&
                u.EnterBIW == EnterBIW &&
                u.BIW == BIW &&
                u.MetalFinish == MetalFinish &&
                u.EnterPaint == EnterPaint &&
                u.Primer == Primer &&
                u.TopCoat == TopCoat &&
                u.ExitPaint == ExitPaint &&
                u.EnterTrim == EnterTrim).ToList();
                ViewBag.vehicleList = vehicleList;

                return View("SearchKoliPost9");
            }
            else
            {
                return View();
            }

        }



            //###############################################################################################################











            public IActionResult GzrshKoli()

        {
            
            string username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
            string user = username.Replace(" ", string.Empty);
            string shayan = "shayan";
                if (user == shayan) {
                    string vin = "NA7NFG120HA100237";
                    var vin1 = PlanningDBcontax.Tblvehicle.FirstOrDefault(u => u.vin == vin);
                    ViewData["vin"] = vin1;
                    ViewBag.vin = vin1.vin;
                    ViewBag.ExtPDI = vin1.ExtPDI;
                    return View();
                }
                else
                {
                    return View("LoginNew");
                }
            }
            
            else
            {
                ViewData["Message"] = "کاربر احراز هویت نشده است، ریدایرکت به صفحه ورود";
                // کاربر احراز هویت نشده است، ریدایرکت به صفحه ورود
                return View("LoginNew");
            }
        }


       




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
