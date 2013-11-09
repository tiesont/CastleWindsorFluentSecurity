﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CastleWindsorFluentSecurity
{
    public class CoreController : Controller
    {
        /// <summary>
        /// Called when a request matches this controller, but no method with the specified action name is found in the controller.
        /// </summary>
        /// <param name="actionName">The name of the attempted action.</param>
        protected override void HandleUnknownAction(string actionName)
        {
            // Avoid IIS7 getting in the middle
            Response.TrySkipIisCustomErrors = true;

            IController errorsController = new Controllers.ErrorsController();
            var errorRoute = new RouteData();
            errorRoute.Values.Add("controller", "errors");
            errorRoute.Values.Add("action", "notfound");
            errorRoute.Values.Add("url", HttpContext.Request.Url.OriginalString);
            errorsController.Execute(new RequestContext(HttpContext, errorRoute));
        }
    }
}
