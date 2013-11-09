using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CastleWindsorFluentSecurity.Controllers
{
    public class HomeController : CoreController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Restricted()
        {
            return View();
        }

    }
}
