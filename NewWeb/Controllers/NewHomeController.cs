﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NewWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Controllers
{
    public class NewHomeController : Controller
    {

        private readonly ContaxDBlogin ContaxDBlogin;
        private readonly PlanningDBcontax PlanningDBcontax;

        public NewHomeController(ContaxDBlogin ContaxDBlogin, PlanningDBcontax PlanningDBcontax)
        {
            this.ContaxDBlogin = ContaxDBlogin;
            this.PlanningDBcontax = PlanningDBcontax;
        }

        public IActionResult Index()
        {
         
                return View();
        
           


        }


        [HttpPost]
        public ActionResult ProcessFormData()
        {
            //دریافت داده‌های فرم از درخواست POST
            bool Vin = Convert.ToBoolean(Request.Form["Vin"]);
            bool Type = Convert.ToBoolean(Request.Form["Type"]);
            bool MetalFinish = Convert.ToBoolean(Request.Form["MainLine"]);
            bool TopCoat = Convert.ToBoolean(Request.Form["enterBIW"]);
            bool ExitChassis = Convert.ToBoolean(Request.Form["ExitChassis"]);
            bool FinalTrim = Convert.ToBoolean(Request.Form["FinalTrim"]);
            bool Trans = Convert.ToBoolean(Request.Form["Trans"]);
            ////bool checkbox2 = Convert.ToBoolean(Request.Form["checkbox2"]);
            ////bool checkbox3 = Convert.ToBoolean(Request.Form["checkbox3"]);
            ////bool checkbox1 = Convert.ToBoolean(Request.Form["checkbox1"]);
            ////bool checkbox2 = Convert.ToBoolean(Request.Form["checkbox2"]);
            ////bool checkbox3 = Convert.ToBoolean(Request.Form["checkbox3"]);
            ////bool checkbox1 = Convert.ToBoolean(Request.Form["checkbox1"]);
            ////bool checkbox2 = Convert.ToBoolean(Request.Form["checkbox2"]);
            ////bool checkbox3 = Convert.ToBoolean(Request.Form["checkbox3"]);
            ////bool checkbox3 = Convert.ToBoolean(Request.Form["checkbox3"]);

            string VinData = Request.Form["VinData"];
            string TypeData = Request.Form["TypeData"];
            string MetalFinishData = Request.Form["MainLineData"];
            string TopCoatData = Request.Form["enterBIWdata"];
            string ExitChassisData = Request.Form["ExitChassisData"];
            string FinalTrimData = Request.Form["FinalTrimData"];
            string TransData = Request.Form["TransData"];



            // ایجاد یک دیکشنری برای نگهداری نام متغیرها و مقادیر بولین آنها
            //Dictionary<string, bool> formValues = new Dictionary<string, bool>();

            //// نمونه اضافه کردن مقادیر به دیکشنری
            //formValues["Vin"] = Convert.ToBoolean(Request.Form["Vin"]);
            //formValues["Type"] = Convert.ToBoolean(Request.Form["Type"]);
            //formValues["MetalFinish"] = Convert.ToBoolean(Request.Form["MainLine"]);
            //formValues["TopCoat"] = Convert.ToBoolean(Request.Form["enterBIW"]);
            //formValues["ExitChassis"] = Convert.ToBoolean(Request.Form["ExitChassis"]);
            //formValues["FinalTrim"] = Convert.ToBoolean(Request.Form["FinalTrim"]);
            //formValues["Trans"] = Convert.ToBoolean(Request.Form["Trans"]);






            //var vin1 = PlanningDBcontax.Tblvehicle.Where(x => x.vin == VinData).ToArray();
            //var TypeN = PlanningDBcontax.Tblvehicle.Where(x => x.vin == VinData).ToArray();
            //var metalN = PlanningDBcontax.Tblvehicle.Where(x => x.vin == VinData).ToArray();
            //var ExitN = PlanningDBcontax.Tblvehicle.Where(x => x.vin == VinData).ToArray();
            //var FinalN = PlanningDBcontax.Tblvehicle.Where(x => x.vin == VinData).ToArray();
            //var TransN = PlanningDBcontax.Tblvehicle.Where(x => x.vin == VinData).ToArray();






            //// حلقه foreach برای جداگانه بررسی متغیرها
            //foreach (var kvp in formValues)
            //{
            //    string variableName = kvp.Key;
            //    bool variableValue = kvp.Value;

            //    // اجرای عملیات مورد نظر بر اساس نام متغیر و مقدار بولین آن
            //    if (variableValue)
            //    {
            //       if (variableName == "Vin")
            //        {
            //             var vin2 = PlanningDBcontax.Tblvehicle.Where(x => x.vin == VinData).ToArray();
            //              vin1 = vin2;
            //            break;
            //        }
            //       else if(variableName == "Type")
            //        {
            //            var TypeBank = PlanningDBcontax.Tblvehicle.Where(x => x.Type == TypeData).ToArray();
            //            TypeN = TypeBank;
            //            continue;
            //        }
            //        else if (variableName == "MetalFinish")
            //        {
            //            var MetalFinishBank = PlanningDBcontax.Tblvehicle.Where(x => x.Type == TypeData).ToArray();
            //            metalN = MetalFinishBank;
            //            continue;
            //        }
            //        else if (variableName == "ExitChassis")
            //        {
            //            var ExitChassisBank = PlanningDBcontax.Tblvehicle.Where(x => x.Type == TypeData).ToArray();
            //            ExitN = ExitChassisBank;
            //            continue;
            //        }
            //        else if (variableName == "FinalTrim")
            //        {
            //            var FinalTrimBank = PlanningDBcontax.Tblvehicle.Where(x => x.Type == TypeData).ToArray();
            //            FinalN = FinalTrimBank;
            //            continue;
            //        }
            //        else if (variableName == "Trans")
            //        {
            //            var TransBank = PlanningDBcontax.Tblvehicle.Where(x => x.Type == TypeData).ToArray();
            //            TransN = TransBank;
            //            continue;
            //        }
            //        else
            //        {
            //            break;
            //        }

            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}

            //var Bank = PlanningDBcontax.Tblvehicle.ToArray();
            //var mashtork = PlanningDBcontax.Tblvehicle.ToArray();
            //if (TypeN != null)
            //{
            //    mashtork = mashtork.Intersect(TypeN).ToArray();
            //}
            //if (metalN != null)
            //{
            //    mashtork = mashtork.Intersect(metalN).ToArray();
            //}

            //if (ExitN != null)
            //{
            //    mashtork = mashtork.Intersect(ExitN).ToArray();
            //}

            //if (FinalN != null)
            //{
            //    mashtork = mashtork.Intersect(FinalN).ToArray();
            //}

            //if (TransN != null)
            //{
            //    mashtork = mashtork.Intersect(TransN).ToArray();
            //}

            /////////////////////////////////////////////////////////////////////////////////////////
            ///
            var mashtork = PlanningDBcontax.Tblvehicle.Where(x => x.VirtualType == TypeData ).ToArray();

            if (Vin)
            {
               var mashtork2 = PlanningDBcontax.Tblvehicle.FirstOrDefault(x => x.vin == VinData);
                ViewBag.vehicleList = mashtork2;
                return View("gozaresh_filterPostVin");
            }

            if (MetalFinish)
            {
                mashtork = mashtork.Where(u => u.MetalFinish == MetalFinishData).ToArray();
            }
            if (TopCoat)
            {
                mashtork = mashtork.Where(u => u.TopCoat == TopCoatData).ToArray();
            }

            if (ExitChassis)
            {
                mashtork = mashtork.Where(u => u.ExitChassis == ExitChassisData).ToArray();
            }
            if (FinalTrim)
            {
                mashtork = mashtork.Where(u => u.Final == FinalTrimData).ToArray();
            }

            if (Trans)
            {
                mashtork = mashtork.Where(u => u.Trans == TransData).ToArray();
            }

            // انجام عملیات پردازش بر روی داده‌های دریافتی
            // در اینجا می‌توانید با داده‌ها عملیات مورد نظر خود را انجام دهید
            ViewBag.vehicleList = mashtork;
            return View("gozaresh_filterPost");
        }

       
        public IActionResult NewSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewSearchPost()
        {
           
            bool virtualTypeBox = Convert.ToBoolean(Request.Form["virtualTypeBox"]);
            bool metalFinishBox = Convert.ToBoolean(Request.Form["metalFinishBox"]);
            bool TopcoatBox = Convert.ToBoolean(Request.Form["TopcoatBox"]);




            string virtualTypeBoxValue1 = Request.Form["virtualTypeBoxValue"];
            string metalFinishDate1 = Request.Form["metalFinishDate"];
            string TopcoatDate1 = Request.Form["TopcoatDate"];

            var mashtork = PlanningDBcontax.Tblvehicle.Where(x => x.VirtualType == virtualTypeBoxValue1).ToArray();

            if (metalFinishBox)
            {
                mashtork = mashtork.Where(u => u.MetalFinish == metalFinishDate1).ToArray();
            }

            if (TopcoatBox)
            {
                mashtork = mashtork.Where(u => u.TopCoat == TopcoatDate1).ToArray();
            }
            ViewBag.vehicleList1 = mashtork;
            return View();
        }


        [HttpPost]
        public IActionResult gozaresh_filterPost()
        {
            return View();
        }


        
    }
}
