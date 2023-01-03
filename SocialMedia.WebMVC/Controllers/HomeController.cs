using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Your help page.";

            return View();
        }

        public ActionResult TermsOfService()
        {
            ViewBag.Message = "Your Terms of Service page.";

            return View();
        }

        public ActionResult Settings()
        {
            ViewBag.Message = "Your setting's page";

            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            ViewBag.Message = "Your Privacy Policy page.";

            return View();
        }
    }
}