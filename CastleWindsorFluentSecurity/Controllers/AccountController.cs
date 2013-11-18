using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CastleWindsorFluentSecurity.Controllers
{
    public class AccountController : CoreController
    {
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult LogIn(Models.LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (SecurityProvider.UserCredentialsAreValid(model.UserName, model.Password))
                {
                    SecurityProvider.CreateSecuritySession(model.UserName, model.RememberMe);

                    return RedirectToLocal(returnUrl);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            SecurityProvider.DestroySecuritySession();
            return RedirectToAction("index", "home");
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult UpdatePassword(string user, string token)
        {
            return View();
        }




        #region Helper methods

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("index", "home", new { area = string.Empty });
            }
        }

        #endregion
    }
}
