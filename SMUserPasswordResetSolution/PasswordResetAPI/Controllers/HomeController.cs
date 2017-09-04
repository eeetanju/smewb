using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasswordResetAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult SifreReset()
        {
            ViewBag.Title = "Sifre Reset";

            return View();
        }
        [HttpPost]
        public ActionResult SifreReset(String userName)
        {
            ViewBag.Title = "Sifre Reset Post";
            BAL.SMOperator opr = new BAL.SMOperator();
            ViewBag.result=opr.ResetOperatorPass(userName);
                return View();
        }

    }
}
