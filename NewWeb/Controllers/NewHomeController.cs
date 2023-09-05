using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Controllers
{
    public class NewHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessFormData()
        {
            // دریافت داده‌های فرم از درخواست POST
            bool checkbox1 = Convert.ToBoolean(Request.Form["checkbox1"]);
            bool checkbox2 = Convert.ToBoolean(Request.Form["checkbox2"]);
            bool checkbox3 = Convert.ToBoolean(Request.Form["checkbox3"]);
            string date1 = Request.Form["date1"];
            string date2 = Request.Form["date2"];
            string date3 = Request.Form["date3"];

            // انجام عملیات پردازش بر روی داده‌های دریافتی
            // در اینجا می‌توانید با داده‌ها عملیات مورد نظر خود را انجام دهید

            return Content("عملیات با موفقیت انجام شد");
        }

    }
}
