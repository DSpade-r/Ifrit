using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ifrit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("applicant"))
            {
                return RedirectToAction("Index","Resumes");
            }
            if (User.IsInRole("employer"))
            {
                return RedirectToAction("Index", "Vacancies");
            }
            if (User.IsInRole("admin"))
            {
                return View();
            }            
            return View();
        }
    }
}