using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CastleWindsorFluentSecurity.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult General()
        {
            // NOTE: Uncomment the line below to include the HTTP status code in the response. Otherwise, it *should* return a 302.
            //Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }

        public ActionResult ServerError()
        {
            // NOTE: Uncomment the line below to include the HTTP status code in the response. Otherwise, it *should* return a 302.
            //Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View("general");
        }

        public ActionResult NotAuthorized()
        {
            // NOTE: Uncomment the line below to include the HTTP status code in the response. Otherwise, it *should* return a 302.
            //Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return View();
        }

        public ActionResult Forbidden()
        {
            // NOTE: Uncomment the line below to include the HTTP status code in the response. Otherwise, it *should* return a 302.
            //Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return View();
        }

        public ActionResult NotFound(string url = "")
        {
            // NOTE: Uncomment the line below to include the HTTP status code in the response. Otherwise, it *should* return a 302.
            //Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }
    }
}
