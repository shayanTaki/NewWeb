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

        public IActionResult GzrshKoli()

        {
            string vin = "NA7NFG120HA100223";
            var vin1 = PlanningDBcontax.Tblvehicle.FirstOrDefault(u => u.vin == vin);
            string username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
            string user = username.Replace(" ", string.Empty);
            string shayan = "shayan";
                if (user == shayan) {
                    ViewData["vin"] = vin1;
                    ViewBag.vin = vin1.vin;
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
