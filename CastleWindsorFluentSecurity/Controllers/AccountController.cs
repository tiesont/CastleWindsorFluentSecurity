using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CastleWindsorFluentSecurity.Controllers
{
    public class AccountController : CoreController
    {
        
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult UpdatePassword(string user, string token)
        {
            return View();
        }
    }
}
