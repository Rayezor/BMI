using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BMI.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BMI.Controllers
{
    public class BMIController : Controller
    {
        // GET: BMIController/Create
        [Display(Name = "BMI Result")]
        public ActionResult BMIResult()
        {
            return View();
        }

        // POST: BMIController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BMIResult(BMIs bmi)
        {
            ViewBag.BodyMassIndex = bmi.BodyMassIndex;
            ViewBag.BMICat = bmi.BMICat;
            ViewBag.BMIAdvice = bmi.BMIAdvice;
            return View(bmi);
        }
    }
}
